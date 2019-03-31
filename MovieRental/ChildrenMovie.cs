using System;

namespace MovieRental
{
    public class ChildrenMovie : Movie
    {
        public ChildrenMovie(String title) : base(title)
        { }

        protected override double BasicPrice { get => 1.5; }

        protected override double GetDailyPrice(int daysRented)
        {
            if (daysRented > 3)
                return (daysRented - 3) * BasicPrice;
            return 0;
        }

        public override int GetBonus(int daysRented)
        {
            return 0;
        }
    }
}
