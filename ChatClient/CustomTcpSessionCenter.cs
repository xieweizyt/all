using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class CustomTcpSessionCenter
    {
        /// <summary>
        /// 客户端和服务器之间的桥梁，所有的传输都要通过它来完成
        /// 
        /// Nuget引入：SuperSocket.ClientEngine
        /// </summary>
        public static AsyncTcpSession _AsyncTcpSession;

        public static void InitAsyncTcpSession()
        {
            ///链接服务器必须的IP+端口配置---可以配置在配置文件中
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Convert.ToInt32(9799));

            _AsyncTcpSession = new AsyncTcpSession();
            _AsyncTcpSession.Connect(endPoint); //按照配置发起链接

            _AsyncTcpSession.DataReceived += ReacedMethod;//
            _AsyncTcpSession.Connected += Connected;

            //考虑
            //1.消息如何发到服务器上去？---命令
            //2.服务器发到客户端的消息，在客户端如何接受的~---通过事件驱动 
            // AsyncTcpSession提供了一个事件：DataReceived，就可以对DataReceived+= 和DataReceived 事件参数吻合的方法；如果服务器有消息发过来，就会去执行这个方法了

            //_AsyncTcpSession.Send("命令：参数");

        }

        /// <summary>
        /// 登录成功后，就触发这个事件
        /// </summary>
        public static event Action<JsonResult> LoginedHanlder;

        /// <summary>
        /// 服务端有消息发过来
        /// </summary>

        public static event Action<JsonResult> SendFrMsgHanlder;

        /// <summary>
        /// 这个方法就是专门用来处理来自于服务器的数据的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ReacedMethod(object? sender, DataEventArgs e)
        {
            string str = Encoding.Default.GetString(e.Data).Replace("\0", "");
            //可能会有不同的命令发给我服务器以后，服务器也是对应不同的命令的发回来的数据 
            JsonResult jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonResult>(str);

            Console.WriteLine($"来自于服务器的消息：{str}");

            switch (jsonResult.CType) //在这里就要做不同的动作
            {
                case CommandTypeEnum.LoginResult:
                    if (jsonResult.Suc)
                    {
                        LoginedHanlder?.Invoke(jsonResult);
                    }
                    break;
                case CommandTypeEnum.SendFrMsg:
                    if (jsonResult.Suc)
                    {
                        SendFrMsgHanlder?.Invoke(jsonResult);
                    }

                    break;
                case CommandTypeEnum.HeartBeat:
                    break;
                default:
                    break;
            }

            //Action<JsonResult> action = CommandList.FirstOrDefault(c => c.Key == jsonResult.CType).Value;
            //action.Invoke(jsonResult);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        public static void SendMsg(string msg)
        {
            if (_AsyncTcpSession.IsConnected == false)
            {
                Console.WriteLine("链接已断开~~");
                InitAsyncTcpSession();
            }

            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes($"{msg}\r\n"));
            _AsyncTcpSession.Send(buffer);
        }

        /// <summary>
        /// 链接成功后，会触发这个方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Connected(object? sender, EventArgs e)
        {
            Console.WriteLine("链接已建立~~");
        }
    }
}
