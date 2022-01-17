// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Text;

Console.WriteLine("客户端启动");
try
{
    using (TcpClient client = new TcpClient())
    {
        client.Connect("localhost", 9099);//端口号9099  //建立链接
        using (NetworkStream stream = client.GetStream())
        {

            while (true)
            {
                Console.WriteLine("**********客户端：请输入消息***************");
                string clientMsg = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(clientMsg);
                //1.这里是写入需要传递给服务端的数据,第一个参数是传入的字符数组，第二个是从哪个开始的偏移量，第三个是写入的数据大小长度
                stream.Write(data, 0, data.Length);
                byte[] recByte = new byte[40960000];
                var bytes = stream.Read(recByte, 0, recByte.Length);
                string recStr = Encoding.UTF8.GetString(recByte, 0, bytes);
                Console.WriteLine($"来自于服务器的消息：{recStr}--{DateTime.Now.ToString()}");
            }
        }
    }
}
catch (Exception)
{

    throw;
}
