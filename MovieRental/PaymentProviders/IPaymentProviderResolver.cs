namespace MovieRental.PaymentProviders
{
    public interface IPaymentProviderResolver
    {
        IPaymentProvider Resolve(string paymentMethod);
    }
}
