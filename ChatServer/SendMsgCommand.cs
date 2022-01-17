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
    public class SendMsgCommand : IAsyncCommand<TelnetSession, StringPackageInfo>, ICommand
    {
        /// <summary>
        /// SendMsgCommand：
        /// 四个参数
        /// 1.发送时间
        /// 2.touser 发给谁
        /// 3.谁发送的
        /// 4.发送的消息内容
        /// </summary>
        /// <param name="session"></param>
        /// <param name="package"></param>
        /// <returns></returns>
        public async ValueTask ExecuteAsync(TelnetSession session, StringPackageInfo package)
        {
            string datetime = package.Parameters[0];
            string touser = package.Parameters[1];
            string fromuser = package.Parameters[2];
            string msg = package.Parameters[3];
            ISessionContainer sessionContainer = session.Server.GetSessionContainer();
            IEnumerable<IAppSession> appSessionList = sessionContainer.GetSessions();

            TelnetSession toUserSession = null;

            //遍历所有的session 查找当前name对应的session
            foreach (var appSession in appSessionList)
            {
                TelnetSession telnetSession = (TelnetSession)appSession;
                if (telnetSession.UserName.Equals(touser))
                {
                    toUserSession = telnetSession;
                    break;
                }
            }

            if (toUserSession != null)
            {
                JsonResult jsonResult = new JsonResult()
                {
                    CType = CommandTypeEnum.SendFrMsg,
                    Msg = Newtonsoft.Json.JsonConvert.SerializeObject(new MsgInfo()
                    {
                        FromUser = fromuser,
                        Msg = msg,
                        SendTime = datetime,
                        ToUser = touser,
                    }),
                    Suc = true
                };
                toUserSession.SendMsg(jsonResult);
            }
            else
            {

            }
            await Task.CompletedTask;
        }
    }
}
