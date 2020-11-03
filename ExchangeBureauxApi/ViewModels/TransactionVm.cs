namespace ExchangeBureauxApi.ViewModels
{
    public class TransactionVm
    {
        public string CurrencyIdentifier { get; set; }

        public double AmountToConvert { get; set; }

        public int UserId { get; set; }

    }
}
