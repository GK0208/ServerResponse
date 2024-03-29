﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServerInterfaces;

namespace ServerPlugins
{
    public class NotFoundPostProcessor : IResponsePostProcessor
    {
        public bool IsInterested(Response response, ILogger logger)
        {
            return response.ResponseCode == ResponseCode.NotFound;
        }

        public Task<Response> Process(Response response, ILogger logger)
        {
            response.Type = ResponseType.Text;
            response.ContentType = ContentTypes.HtmlText;
            response.Body = "PATH NOT FOUND";
            return Task.FromResult(response);
        }
    }
}
