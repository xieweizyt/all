// See https://aka.ms/new-console-template for more information


using ChatServer;
using Microsoft.Extensions.Hosting;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

try
{
    //1.创建一个主机
    SuperSocketHostBuilder<StringPackageInfo> hostBuilder = (SuperSocketHostBuilder<StringPackageInfo>)SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>();

    //2.配置监听
    hostBuilder = (global::SuperSocket.SuperSocketHostBuilder<global::SuperSocket.ProtoBase.StringPackageInfo>)hostBuilder.ConfigureSuperSocket(options =>
    {
        options.Name = "ChatServer";
        options.Listeners = new List<ListenOptions> {
            new ListenOptions(){
                Ip = "Any",
                Port = 9799
            }
        };
    });

    //自定义解析参数数据
    hostBuilder.UsePackageDecoder<CustomPackageDecoder>();

    //配置Session
    hostBuilder.UseSession<TelnetSession>();

    //配置自定义的AppService
    hostBuilder.UseHostedService<TelnetService<StringPackageInfo>>();

    //配置命令
    {
        hostBuilder.UseCommand<StringPackageInfo>(options =>
        {
            options.AddCommand<SendMsgCommand>();
            options.AddCommand<LoginCommand>();
            //otptions.AddCommandAssembly();
        });
    }
    hostBuilder.UseInProcSessionContainer();

    //3.Build一下得到配置好的主机
    IHost host = hostBuilder.Build();  
    //4.启动主机
    host.StartAsync();

    Console.Read();
}
catch (Exception)
{

    throw;
}
