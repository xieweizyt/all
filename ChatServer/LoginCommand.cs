using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class LoginCommand : IAsyncCommand<TelnetSession, StringPackageInfo>, ICommand
    {

        /// <summary>
        /// 客户端可以通过当前这个命令来 基于IAppSession 发送消息给服务端
        /// </summary>
        /// <param name="session"></param>
        /// <param name="package"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async ValueTask ExecuteAsync(TelnetSession session, StringPackageInfo package)
        {
            string userName = package.Parameters[0];
            string userPass = package.Parameters[1];
            session.UserName = userName;
            //验证用户名密码
            JsonResult jsonResult = new JsonResult()
            {
                CType = CommandTypeEnum.LoginResult,
                Suc = true
            };
            session.SendMsg(jsonResult);
            await Task.CompletedTask;
        }
    }
}
