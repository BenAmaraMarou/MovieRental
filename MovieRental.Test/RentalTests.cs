using NUnit.Framework;

namespace MovieRental.Test
{
    public class RentalTests
    {
        private const string DummyMovie = "Some movie";
        private const int NoDays = 0;
        private const int OneDay = 1;
        private const int TwoDays = 2;
        private const int ThreeDays = 3;
        private const int AnyDays = 5;
        private const int MoreThanOneDay = 10;
        private const int MoreThanTwoDays = 20;
        private const int MoreThanThreeDays = 30;

        [TestCase(OneDay)]
        [TestCase(TwoDays)]
        public void Price_of_regular_movie_rent_for_less_than_two_days(int days)
        {
            var rental = new Rental(new RegularMovie(DummyMovie), days);

            var actual = rental.GetPrice();

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void Price_of_regular_movie_rent_for_more_than_two_days()
        {
            var rental = new Rental(new RegularMovie(DummyMovie), MoreThanTwoDays);

            var actual = rental.GetPrice();

            Assert.AreEqual(2 + (MoreThanTwoDays - 2) * 1.5, actual);
        }

        [Test]
        public void Price_of_new_release_rental()
        {
            var rental = new Rental(new NewReleaseMovie(DummyMovie), AnyDays);

            var actual = rental.GetPrice();

            Assert.AreEqual(AnyDays * 3, actual);
        }

        [TestCase(OneDay)]
        [TestCase(TwoDays)]
        [TestCase(ThreeDays)]
        public void Price_of_regular_movie_rent_for_less_than_three_days(int days)
        {
            var rental = new Rental(new ChildrenMovie(DummyMovie), days);

            var actual = rental.GetPrice();

            Assert.AreEqual(1.5, actual);
        }
        
        [Test]
        public void Price_of_regular_movie_rent_for_more_than_three_days()
        {
            var rental = new Rental(new ChildrenMovie(DummyMovie), MoreThanThreeDays);

            var actual = rental.GetPrice();

            Assert.AreEqual(1.5 + (MoreThanThreeDays - 3)*1.5, actual);
        }

        [Test]
        public void Should_add_one_renter_point_for_regular_movie()
        {
            var rental = new Rental(new RegularMovie(DummyMovie), AnyDays);

            var actual = rental.GetRenterPoints();

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void Should_add_one_renter_point_for_children_movie()
        {
            var rental = new Rental(new ChildrenMovie(DummyMovie), AnyDays);

            var actual = rental.GetRenterPoints();

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void Should_add_one_renter_point_for_new_release_less_than_two_days()
        {
            var rental = new Rental(new NewReleaseMovie(DummyMovie), OneDay);

            var actual = rental.GetRenterPoints();

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void Should_add_two_renter_points_for_new_release_more_than_one_day()
        {
            var rental = new Rental(new NewReleaseMovie(DummyMovie), MoreThanOneDay);

            var actual = rental.GetRenterPoints();

            Assert.AreEqual(2, actual);
        }
    }
}
