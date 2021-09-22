namespace ApiWrapper
{
    public static class EndPoints
    {
        public static string GetAccessToken = "oauth/token";
        public static string ViewBalance = "accounts/balance";
        public static string autodetectOperator = "operators/auto-detect/phone/{phone}/countries/{countryisocode}";
        public static string TopUp = "topups";
        public static string TopUpStatus = "/topups-async";
    }
}