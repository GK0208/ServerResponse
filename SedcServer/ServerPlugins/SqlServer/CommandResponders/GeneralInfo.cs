using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServerInterfaces;

namespace ServerPlugins.SqlServer.CommandResponders
{
    public class GeneralInfo: ICommandResponder
    {
        private string ConnectionString { get; set; }

        public GeneralInfo(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<Response> GetResponse()
        {
            var cnn = new SqlConnection(ConnectionString);
            cnn.Open();
            var command = new SqlCommand("select @@version", cnn);
            var result = (await command.ExecuteScalarAsync()).ToString();

            JObject body = new JObject
            {
                ["Version"] = result
            };

            return new Response
            {
                ContentType = ContentTypes.JsonApplication,
                ResponseCode = ResponseCode.Ok,
                Type = ResponseType.Text,
                Body = body.ToString()
            };
        }
    }
}
