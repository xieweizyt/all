using SuperSocket.ProtoBase;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    /// <summary>
    /// 自定义参数处理规则;
    /// 1.实现这个接口
    /// 2.让当前规则生效
    /// </summary>
    public class CustomPackageDecoder : IPackageDecoder<StringPackageInfo>
    {
        public StringPackageInfo Decode(ref ReadOnlySequence<byte> buffer, object context)
        {
            var text = buffer.GetString(new UTF8Encoding(false));
            var parts = text.Split(':', 2);

            string key = parts[0]; //命令名称
            string body = parts[1];//参数---是以逗号分割
            string[] paras = body.Split(",");



            return new StringPackageInfo
            {
                Key = key,
                Body = body,
                Parameters = paras
            };
        }
    }
}
