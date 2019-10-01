using ServerInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerPlugins.SqlServer.CommandResponders
{
     
        class NoConectivity : ICommandResponder
        {
            public async Task<Response> GetResponse()
            {
                return new Response
                {
                    ContentType = ContentTypes.PlainText,
                    ResponseCode = ResponseCode.WebServerIsDown,
                    Type = ResponseType.Text,
                    Body = "Can not connect to the server !"
                };
            }
        }
    
}
