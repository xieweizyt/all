// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("服务器启动");
try
{
    TcpListener listener = new TcpListener(IPAddress.Any, 9099);//设置端口号9099
    listener.Start(12);
    while (true)
    {
        try
        {
            Socket socket = listener.AcceptSocket();
            byte[] recByte = new byte[40960000];
            int bytes = socket.Receive(recByte, recByte.Length, 0);
            var recStr = Encoding.UTF8.GetString(recByte, 0, bytes);
            Console.WriteLine($"{DateTime.Now.ToString()}--来自客户端的消息：{recStr}");

            //往客户端发数据发送
            Console.WriteLine("**********服务端：请输入消息***************");
            string serverMsg = Console.ReadLine();
            byte[] res = System.Text.Encoding.UTF8.GetBytes(serverMsg);
            socket.Send(res);
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
catch (Exception)
{

    throw;
}
