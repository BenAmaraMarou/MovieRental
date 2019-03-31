using System;

namespace MovieRental
{
    public class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(String title): base(title)
        {  }

        protected override double BasicPrice { get => 0; }

        protected override double GetDailyPrice(int daysRented)
        {
            return daysRented * 3;
        }

        public override int GetBonus(int daysRented)
        {
            if (daysRented > 1)
                return 1;
            return 0;
        }
    }
}
