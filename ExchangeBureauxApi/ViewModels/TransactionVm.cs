namespace ExchangeBureauxApi.ViewModels
{
    public class TransactionVm
    {
        public string Description { get; set; }
        
        public string CurrencyIdentifier { get; set; }

        public int UserId { get; set; }

        public double AmountToConvert { get; set; }

    }
}
