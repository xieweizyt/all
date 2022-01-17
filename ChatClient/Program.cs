namespace ChatClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            CustomTcpSessionCenter.InitAsyncTcpSession();
            Application.Run(new Login());
        }
    }
}