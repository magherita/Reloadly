using System;
using System.Text.Json.Serialization;

namespace ApiWrapper.FlutterwaveClient.Requests
{
    public class Authorization
    {
        public string Mode { get; set; }
        public string Pin { get; set; }
    }

    public class ChargeCardRequest
    {
        public string Card_Number { get; set; }

        public string Cvv { get; set; }

        public string Expiry_Month { get; set; }

        public string Expiry_Year { get; set; }

        public string Currency { get; set; }

        public string Amount { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Tx_Ref { get; set; } = Guid.NewGuid().ToString();// you

        [JsonIgnore]
        public string Redirect_Url { get; set; } = "";
        //public Authorization Authorization { get; set; }
    }


}