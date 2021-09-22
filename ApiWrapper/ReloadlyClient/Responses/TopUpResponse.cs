// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
public class BalanceInfo
{
    public double OldBalance { get; set; }
    public double NewBalance { get; set; }
    public string CurrencyCode { get; set; }
    public string CurrencyName { get; set; }
    public string UpdatedAt { get; set; }
}

public class TopUpResponse
{
    public int TransactionId { get; set; }
    public string OperatorTransactionId { get; set; }
    public string CustomIdentifier { get; set; }
    public string RecipientPhone { get; set; }
    public string RecipientEmail { get; set; }
    public string SenderPhone { get; set; }
    public string CountryCode { get; set; }
    public int OperatorId { get; set; }
    public string OperatorName { get; set; }
    public int Discount { get; set; }
    public string DiscountCurrencyCode { get; set; }
    public int RequestedAmount { get; set; }
    public string RequestedAmountCurrencyCode { get; set; }
    public double DeliveredAmount { get; set; }
    public string DeliveredAmountCurrencyCode { get; set; }
    public string TransactionDate { get; set; }
    public string PinDetail { get; set; }
    public BalanceInfo BalanceInfo { get; set; }
}