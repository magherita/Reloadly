using System.Collections.Generic;

namespace ApiWrapper.ReloadlyClient.Responses
{
    public class Response<TResponse>
    {
        public int StatusCode { get; set; }

        public TResponse Data { get; set; }

        public ErrorResponse Error { get; set; }
    }
}