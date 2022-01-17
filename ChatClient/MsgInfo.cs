namespace ChatClient
{
    public class MsgInfo
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public string? Msg { get; set; }

        /// <summary>
        /// 发送消息时间
        /// </summary>
        public string? SendTime { get; set; }


        /// <summary>
        /// 接收方
        /// </summary>
        public string? ToUser { get; set; }

        /// <summary>
        /// 发送方
        /// </summary>
        public string? FromUser { get; set; }
    }
}