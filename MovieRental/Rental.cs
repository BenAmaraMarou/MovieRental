namespace MovieRental
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }
                
        public double GetPrice()
        {
            return _movie.GetPrice(_daysRented);
        }

        public int GetRenterPoints()
        {
            return 1 + _movie.GetBonus(_daysRented);
        }

        public string Statement()
        {
            return "\t" + _movie.GetTitle() + "\t" + GetPrice() + "\n";
        }
    }    
}
