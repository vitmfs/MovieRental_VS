using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.PaymentProviders;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		private readonly IPaymentProviderResolver _paymentResolver;

		public RentalFeatures(MovieRentalDbContext movieRentalDb, IPaymentProviderResolver _paymentResolver)
		{
			_movieRentalDb = movieRentalDb;
			this._paymentResolver = _paymentResolver;
        }

		//TODO: make me async :(
		public async Task<Rental> SaveAsync(Rental rental)
		{
			double pricePerDay = 5.0;
            double priceToPay = rental.DaysRented * pricePerDay;

			var paymentProvider = _paymentResolver.Resolve(rental.PaymentMethod);
			var wasPaymentSuccessful = await paymentProvider.Pay(priceToPay);

			if (!wasPaymentSuccessful)
			{
				throw new InvalidOperationException("Payment was not successful");
            }

            _movieRentalDb.Rentals.Add(rental);
			await _movieRentalDb.SaveChangesAsync();
			return rental;
		}

		//TODO: finish this method and create an endpoint for it
		public IEnumerable<Rental> GetRentalsByCustomerName(string customerName)
		{
			return _movieRentalDb.Rentals.Where(c => c.Customer.Name == customerName);
		}

	}
}
