using System;

namespace MovieRental
{
    public abstract class Movie
    {
        private String _title;

        public Movie(String title)
        {
            _title = title;
        }

        public String GetTitle()
        {
            return _title;
        }

        public double GetPrice(int daysRented)
        {
            return BasicPrice + GetDailyPrice(daysRented);
        }

        protected abstract double BasicPrice { get; }

        protected abstract double GetDailyPrice(int daysRented);

        public abstract int GetBonus(int daysRented);
    }
}
