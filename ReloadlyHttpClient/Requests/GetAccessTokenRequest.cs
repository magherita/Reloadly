namespace ReloadlyHttpClient.Requests
{
    public class GetAccessTokenRequest
    {
        public string Client_Id { get; set; }

        public string Client_Secret { get; set; }

        public string Grant_Type { get; set; }

        public string Audience { get; set; }
    }
}
