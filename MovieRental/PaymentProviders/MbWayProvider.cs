namespace MovieRental.PaymentProviders
{
    public class MbWayProvider : IPaymentProvider
    {
        public string Name => "MbWay";
        public Task<bool> Pay(double price)
        {
            // Dummy implementation
            return Task.FromResult<bool>(true);
        }
    }
}
