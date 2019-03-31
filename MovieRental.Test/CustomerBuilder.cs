using System;
using System.Collections.Generic;

namespace MovieRental.Tests
{
    public class CustomerBuilder
    {
        private const String DefaultName = "Roberts";

        private String _name = DefaultName;
        private List<Rental> _rentals = new List<Rental>();

        public Customer Build()
        {
            Customer result = new Customer(_name);

            foreach (Rental rental in _rentals)
            {
                result.AddRental(rental);
            }
            return result;
        }

        public CustomerBuilder WithName(String name)
        {
            _name = name;
            return this;
        }

        public CustomerBuilder WithRentals(params Rental[] rentals)
        {
            _rentals.AddRange(rentals);
            return this;
        }
    }
}