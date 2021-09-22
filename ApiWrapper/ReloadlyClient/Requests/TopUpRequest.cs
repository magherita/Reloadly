namespace ApiWrapper.Requests
{
    public class RecipientPhone
    {
        public string CountryCode { get; set; }
        public string Number { get; set; }
    }

    public class SenderPhone
    {
        public string CountryCode { get; set; }
        public string Number { get; set; }
    }

    public class TopUpRequest
    {
        public string OperatorId { get; set; }
        public string Amount { get; set; }
        public bool UseLocalAmount { get; set; }
        public string CustomIdentifier { get; set; }
        public RecipientPhone RecipientPhone { get; set; }
        public SenderPhone SenderPhone { get; set; }
    }
    
}