using Microsoft.Extensions.Options;
using SuperSocket;
using SuperSocket.Channel;
using SuperSocket.ProtoBase;
using SuperSocket.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class TelnetService<StringPackageInfo> : SuperSocketService<StringPackageInfo>
    {
        public TelnetService(IServiceProvider serviceProvider, IOptions<ServerOptions> serverOptions) : base(serviceProvider, serverOptions)
        {
        }

        /// <summary>
        /// 当服务已打开
        /// </summary>
        /// <returns></returns>
        protected override ValueTask OnStartedAsync()
        {
            Console.WriteLine($"{typeof(TelnetService<StringPackageInfo>)}...服务已打开");
            return base.OnStartedAsync();
        }


        protected override ValueTask OnStopAsync()
        {
            Console.WriteLine($"{typeof(TelnetService<StringPackageInfo>)}...服务已停止");
            return base.OnStopAsync();
        }


        protected override object CreatePipelineContext(IAppSession session)
        {
            return base.CreatePipelineContext(session);
        }


        /// <summary>
        ///当新用户请求来了后
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="channel"></param>
        protected override void OnNewClientAccept(IChannelCreator listener, IChannel channel)
        {
            base.OnNewClientAccept(listener, channel);
        }

        /// <summary>
        /// Session成功链接后
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        protected override ValueTask OnSessionConnectedAsync(IAppSession session)
        {
            return base.OnSessionConnectedAsync(session);
        }

        /// <summary>
        /// 当Session断开后
        /// </summary>
        /// <param name="session"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override ValueTask OnSessionClosedAsync(IAppSession session, CloseEventArgs e)
        {
            return base.OnSessionClosedAsync(session, e);
        }

        /// <summary>
        /// 链接异常后发生
        /// </summary>
        /// <param name="session"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected override ValueTask<bool> OnSessionErrorAsync(IAppSession session, PackageHandlingException<StringPackageInfo> exception)
        {
            return base.OnSessionErrorAsync(session, exception);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        protected override ValueTask FireSessionClosedEvent(AppSession session, CloseReason reason)
        {
            //Console.WriteLine("FireSessionConnectedEvent 已执行");
            return base.FireSessionClosedEvent(session, reason);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        protected override ValueTask FireSessionConnectedEvent(AppSession session)
        {
            //Console.WriteLine("FireSessionConnectedEvent 已执行~~~");
            return base.FireSessionConnectedEvent(session);
        }
    }
}
