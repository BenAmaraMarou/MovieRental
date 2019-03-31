using NUnit.Framework;

namespace MovieRental.Tests
{
    public class CustomerTest
    {
        private const string CustomerName = "Sallie";
        private const string RegularMovie = "Gone with the Wind";
        private const string NewReleaseMovie = "Star Wars";
        private const string ChildrenMovie = "Madagascar";

        [TestCase(1)]
        [TestCase(2)]
        public void Should_rent_regular_movie_for_less_than_2_days(int days)
        {
            Movie movie = new RegularMovie(RegularMovie);
            Rental rental = new Rental(movie, days);
            Customer customer =
                    new CustomerBuilder()
                            .WithName(CustomerName)
                            .WithRentals(rental)
                            .Build();
            var expectedUnitPrice = 2;
            var expectedRenterPoint = 1;
            string expected =
                "Rental Record for " + CustomerName + "\n" +
                "\t" + RegularMovie + "\t" + expectedUnitPrice + "\n" +
                "Amount owed is " + expectedUnitPrice + "\n" +
                "You earned " + expectedRenterPoint + " frequent renter points";

            string statement = customer.Statement();

            Assert.AreEqual(expected, statement);
        }

        [Test]
        public void Should_rent_regular_movie_for_more_than_2_days()
        {
            var days = 3;
            Movie movie = new RegularMovie(RegularMovie);
            Rental rental = new Rental(movie, days);
            Customer customer =
                    new CustomerBuilder()
                            .WithName(CustomerName)
                            .WithRentals(rental)
                            .Build();
            var regularUnitPrice = 2;
            var expectedRenterPoint = 1;
            string expected =
                "Rental Record for " + CustomerName + "\n" +
                "\t" + RegularMovie + "\t" + (regularUnitPrice + (days - 2) * 1.5).ToString() + "\n" +
                "Amount owed is " + (regularUnitPrice + (days - 2) * 1.5).ToString() + "\n" +
                "You earned " + expectedRenterPoint + " frequent renter points";

            string statement = customer.Statement();

            Assert.AreEqual(expected, statement);
        }

        [Test]
        public void Should_rent_new_release_for_3_days()
        {
            Movie movie = new NewReleaseMovie(NewReleaseMovie);
            Rental rental = new Rental(movie, 3); // 3 day rental
            Customer customer =
                    new CustomerBuilder()
                            .WithName(CustomerName)
                            .WithRentals(rental)
                            .Build();
            string expected = "Rental Record for " + CustomerName + "\n" +
                    "\t" + NewReleaseMovie + "\t" + 9 + "\n" +
                    "Amount owed is " + 9 + "\n" +
                    "You earned " + 2 + " frequent renter points";

            string statement = customer.Statement();

            Assert.AreEqual(expected, statement);
        }

        [Test]
        public void Should_rent_new_release_for_1_day()
        {
            Movie movie = new NewReleaseMovie(NewReleaseMovie);
            Rental rental = new Rental(movie, 1);
            Customer customer =
                    new CustomerBuilder()
                            .WithName(CustomerName)
                            .WithRentals(rental)
                            .Build();
            string expected = "Rental Record for " + CustomerName + "\n" +
                    "\t" + NewReleaseMovie + "\t" + 3 + "\n" +
                    "Amount owed is " + 3 + "\n" +
                    "You earned " + 1 + " frequent renter points";

            string statement = customer.Statement();

            Assert.AreEqual(expected, statement);
        }

        [Test]
        public void Should_rent_children_movie_for_3_days()
        {
            Movie movie = new ChildrenMovie(ChildrenMovie);
            Rental rental = new Rental(movie, 3); // 3 day rental
            Customer customer
                    = new CustomerBuilder()
                    .WithName(CustomerName)
                    .WithRentals(rental)
                    .Build();
            string expected = "Rental Record for " + CustomerName + "\n" +
                    "\t" + ChildrenMovie + "\t" + 1.5 + "\n" +
                    "Amount owed is " + 1.5 + "\n" +
                    "You earned " + 1 + " frequent renter points";

            string statement = customer.Statement();

            Assert.AreEqual(expected, statement);
        }

        [Test]
        public void StatementForManyMovies()
        {
            Movie movie1 = new ChildrenMovie("Madagascar");
            Rental rental1 = new Rental(movie1, 6); // 6 day rental
            Movie movie2 = new NewReleaseMovie("Star Wars");
            Rental rental2 = new Rental(movie2, 2); // 2 day rental
            Movie movie3 = new RegularMovie("Gone with the Wind");
            Rental rental3 = new Rental(movie3, 8); // 8 day rental
            Customer customer
                    = new CustomerBuilder()
                    .WithName("David")
                    .WithRentals(rental1, rental2, rental3)
                    .Build();
            string expected = "Rental Record for David\n" +
                    "\tMadagascar\t6\n" +
                    "\tStar Wars\t6\n" +
                    "\tGone with the Wind\t11\n" +
                    "Amount owed is 23\n" +
                    "You earned 4 frequent renter points";

            string statement = customer.Statement();

            Assert.AreEqual(expected, statement);
        }


        //TODO make test for price breaks in code.
    }
}
