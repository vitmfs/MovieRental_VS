namespace MovieRental.PaymentProviders
{
    public class PayPalProvider : IPaymentProvider
    {
        public string Name => "PayPal";
        public Task<bool> Pay(double price)
        {
            // Dummy implementation
            return Task.FromResult<bool>(true);
        }
    }
}
