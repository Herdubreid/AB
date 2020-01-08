using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Test
{
    class E1 : Celin.AIS.Server
    {
        public E1(IConfiguration config, ILogger logger)
            : base(config["baseUrl"], logger)
        {
            AuthRequest.username = config["username"];
            AuthRequest.password = config["password"];
        }
    }
}
