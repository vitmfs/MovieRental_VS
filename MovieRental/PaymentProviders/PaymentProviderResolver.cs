namespace MovieRental.PaymentProviders
{
    public class PaymentProviderResolver : IPaymentProviderResolver
    {
        private readonly IEnumerable<IPaymentProvider> _paymentProviders;

        public PaymentProviderResolver(IEnumerable<IPaymentProvider> paymentProviders)
        {
            _paymentProviders = paymentProviders;
        }

        public IPaymentProvider Resolve(string paymentMethod)
        {
            var provider = _paymentProviders.FirstOrDefault(p => p.Name.Equals(paymentMethod, StringComparison.OrdinalIgnoreCase));

            if (provider == null)
            {
                throw new InvalidOperationException($"Payment provider {paymentMethod} not supported");
            }

            return provider;
        }
    }
}
