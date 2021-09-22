using System.Collections.Generic;

namespace ApiWrapper.ReloadlyClient.Responses
{
    public class ErrorResponse
    {
        public string TimeStamp { get; set; }

        public string Message { get; set; }

        public string Path { get; set; }

        public string ErrorCode { get; set; }

        public string InfoLink { get; set; }

        public List<string> Details { get; set; }
    }
}