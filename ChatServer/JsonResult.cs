using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class JsonResult
    {
        /// <summary>
        /// 命令类型
        /// </summary>
        public CommandTypeEnum CType { get; set; }

        /// <summary>
        /// 是否操作成功
        /// </summary>
        public bool Suc { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Msg { get; set; }
    }

    public enum CommandTypeEnum
    {
        LoginResult = 1, //登录
        SendFrMsg = 2,//发送消息
        HeartBeat = 3// 心跳
    }
}
