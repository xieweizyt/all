using System.Text;

namespace ChatClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            CustomTcpSessionCenter.LoginedHanlder += LoginOK;
        }

        private void txt_login_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"µÇÂ¼£º{Thread.CurrentThread.ManagedThreadId}");
            string command = $"LoginCommand:{this.txt_UserName.Text},123";
            var comm = Encoding.UTF8.GetBytes($"{command}\r\n");
            ArraySegment<byte> buffer = new ArraySegment<byte>(comm);
            CustomTcpSessionCenter._AsyncTcpSession.Send(buffer);
        }

        private void LoginOK(JsonResult msg)
        {
            this.Invoke(() =>
            {
                this.Hide();
                MsgForm msgForm = new MsgForm(this.txt_UserName.Text);
                msgForm.Show();
            });
        }
    }
}