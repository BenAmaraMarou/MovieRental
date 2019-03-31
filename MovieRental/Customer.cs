namespace MovieRental
{
    public class Customer
    {
        private string _name;
        private RentalRecord _rentalRecord = new RentalRecord();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentalRecord.AddRental(rental);
        }
        
        public string Statement()
        {
            return $"Rental Record for {_name}\n" +
                $"{_rentalRecord.Statement()}" +
                $"Amount owed is {_rentalRecord.Total()}\n" +
                $"You earned {_rentalRecord.RenterPoints()} frequent renter points";
        }
    }
}
