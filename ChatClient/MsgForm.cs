using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class MsgForm : Form
    {
        private string? CurrentUserName;
        public MsgForm(string name)
        {
            InitializeComponent();
            this.lblCurrentUser.Text = name;
            CurrentUserName = name;
            CustomTcpSessionCenter.SendFrMsgHanlder += GetResult;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string datetime = DateTime.Now.ToString();
            string touser = this.txtToUser.Text;
            string fromuser = CurrentUserName;
            string msg = this.txtMsgContent.Text;

            Console.WriteLine($"登录：{Thread.CurrentThread.ManagedThreadId}");
            string command = $"SENDMSG:{datetime},{touser},{fromuser},{msg}";
            var comm = Encoding.UTF8.GetBytes($"{command}\r\n");
            ArraySegment<byte> buffer = new ArraySegment<byte>(comm);
            CustomTcpSessionCenter._AsyncTcpSession.Send(buffer);
        }

        /// <summary>
        /// 接受发过来的消息
        /// </summary>
        /// <param name="msg"></param>
        public void GetResult(JsonResult msg)
        {
            MsgInfo msgInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<MsgInfo>(msg.Msg);
            this.txtHisterMsgContent.Text += $"\r\n ";
            this.txtHisterMsgContent.Text += $"\r\n {msgInfo.SendTime}";
            this.txtHisterMsgContent.Text += $"\r\n {msgInfo.FromUser}:{msgInfo.Msg}";
        }
    }
}
