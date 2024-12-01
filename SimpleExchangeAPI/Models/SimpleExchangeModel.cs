namespace SimpleExchangeAPI.Models
{
    public class SimpleExchangeModel
    {
        //public int Id { get; set; } 

        public decimal Amount { get; set; }

        public string? InputCurrency { get; set; }

        public string? OutputCurrency { get; set; }

        public decimal Value { get; set; }
    }
}
