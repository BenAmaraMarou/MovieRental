using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{
    public class RentalRecord
    {
        private List<Rental> _rentals = new List<Rental>();
        
        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public double Total()
        {
            return _rentals.Sum(rental => rental.GetPrice());
        }

        public double RenterPoints()
        {
            return _rentals.Sum(rental => rental.GetRenterPoints());
        }

        public string Statement()
        {
            return _rentals.Aggregate(string.Empty, (current, next) => current + next.Statement());
        }
    }
}
