namespace ApiWrapper.ReloadlyClient.Responses
{
    public class GetAccessTokenResponse
    {
        public string Access_Token { get; set; }

        public string Scope { get; set; }

        public int Expires_In { get; set; }

        public string Token_Type { get; set; }
    }
}