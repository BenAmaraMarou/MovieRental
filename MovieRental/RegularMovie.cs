using System;

namespace MovieRental
{
    public class RegularMovie : Movie
    {
        public RegularMovie(String title) : base(title)
        { }

        protected override double BasicPrice { get => 2; }

        protected override double GetDailyPrice(int daysRented)
        {
            if (daysRented > 2)
                return (daysRented - 2) * 1.5;
            return 0;
        }

        public override int GetBonus(int daysRented)
        {
            return 0;
        }
    }
}
