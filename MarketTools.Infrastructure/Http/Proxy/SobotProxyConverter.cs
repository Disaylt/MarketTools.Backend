using MarketTools.Application.Interfaces.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Proxy
{
    internal class SobotProxyConverter : IProxyConverter
    {
        public IWebProxy Convert(string value)
        {
            string[] twoHalfValues = value.Split('@');
            string[] hostAndPort = twoHalfValues[0].Split(':');
            string[] userAndPass = twoHalfValues[1].Split(':');

            return new WebProxy(hostAndPort[0], int.Parse(hostAndPort[1]))
            {
                Credentials = new NetworkCredential(userAndPass[0], userAndPass[1])
            };
        }
    }
}