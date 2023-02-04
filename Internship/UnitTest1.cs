using Vessels;

namespace VesselTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Ferry_init() //tests if the ferry is initialized correctly
        {
            var ferry = new Ferry("Båt 1", "2012", 100, 50);
            Assert.Equal(100, ferry.Passengers);
            Assert.Equal("Båt 1", ferry.GetName());
            Assert.Equal("Ferry", ferry.GetVesselType());
        }

        [Fact]
        public void Test_Tugboat_init() //tests if the tugboat is initialized correctly
        {
            var Tugboat = new Tugboat("Båt 2", "2013", 1000, 50);
            Assert.Equal(1000, Tugboat.GetMaxForce());
            Assert.Equal("Båt 2", Tugboat.GetName());
            Assert.Equal("2013", Tugboat.GetYearBuilt());
            Assert.Equal("Tugboat", Tugboat.GetVesselType());
        }  

        [Fact]
        public void Test_Submarine_init() //tests if the submarine is initialized correctly
        {
            var Submarine = new Submarine("Båt 3", "2014", 10000, 50);
            Assert.Equal(10000, Submarine.GetMaxDepth());
            Assert.Equal("Båt 3", Submarine.GetName());
            Assert.Equal("2014", Submarine.GetYearBuilt());
            Assert.Equal("Submarine", Submarine.GetVesselType());
        }

        [Fact]
        public void Test_Ferry_speed() //test that the speed is correct and can be changed by input in submarine
        {
            double knots = 50 * 1.94384; //convert m/s to knots
            string str_knots = knots.ToString() + " knots"; //convert to string

            var ferry = new Ferry("Båt 1", "2012", 100, 50);

            Assert.Equal("50 m/s", ferry.GetSpeed("m/s")); //test m/s
            Assert.Equal(str_knots, ferry.GetSpeed("knots")); // test knots
        }

        [Fact]
        public void Test_Tugboat_speed() //test that the speed is correct and can be changed by input in submarine
        {
            double knots = 50 * 1.94384; //convert m/s to knots
            string str_knots = knots.ToString() + " knots"; //convert to string

            var tugboat = new Tugboat("Båt 1", "2012", 100, 50);

            Assert.Equal("50 m/s", tugboat.GetSpeed("m/s")); //test m/s
            Assert.Equal(str_knots, tugboat.GetSpeed("knots")); // test knots
        }

        [Fact]
        public void Test_Submarine_speed() //test that the speed is correct and can be changed by input in submarine
        {
            double knots = 50 * 1.94384; //convert m/s to knots
            string str_knots = knots.ToString() + " knots"; //convert to string

            var submarine = new Submarine("Båt 1", "2012", 100, 50);

            Assert.Equal("50 m/s", submarine.GetSpeed("m/s")); //test m/s
            Assert.Equal(str_knots, submarine.GetSpeed("knots")); // test knots
        }

        [Fact]
        public void Test_ferry_year_exceptions()
        {
            Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "1999", 100, 50)); //test if the ferry is too old
            Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "1940", 100, 50)); //test if the ferry is too old
            Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "1930", 100, 50)); //test if the ferry is too old
            Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "1970", 100, 50)); //test if the ferry is too old
            Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "", 100, 50)); //test exception for when year is empty
        }

        [Fact]
        public void Test_ferry_name_exceptions()
        {
            Assert.Throws<ArgumentException>(() => new Ferry("", "1960", 100, 50)); //test name == NULL exception
            Assert.Throws<ArgumentException>(() => new Ferry(null, "2000", 100, 50)); //test year == NULL exception
        }

        [Fact]
        public void Test_tugobat_exceptions()
        {
            Assert.Throws<ArgumentException>(() => new Tugboat("Båt 1", "1999", 100, 50)); //test if the tugboat is too old
            Assert.Throws<ArgumentException>(() => new Tugboat("Båt 1", "1940", 100, 50)); //test if the tugboat is too old
            Assert.Throws<ArgumentException>(() => new Tugboat("Båt 1", "1930", 100, 50)); //test if the tugboat is too old
            Assert.Throws<ArgumentException>(() => new Tugboat("Båt 1", "1970", 100, 50)); //test if the tugboat is too old
            Assert.Throws<ArgumentException>(() => new Tugboat("Båt 1", "", 100, 50)); //test exception for when year is empty
        }

        [Fact]
        public void Test_tugboat_name_exceptions()
        {
            Assert.Throws<ArgumentException>(() => new Tugboat("", "1960", 100, 50)); //test name == NULL exception
            Assert.Throws<ArgumentException>(() => new Tugboat(null, "2000", 100, 50)); //test year == NULL exception
        }

        [Fact]
        public void Test_submarine_year_exceptions()
        {
            Assert.Throws<ArgumentException>(() => new Submarine("Båt 1", "1999", 100, 50)); //test if the submarine is too old
            Assert.Throws<ArgumentException>(() => new Submarine("Båt 1", "1940", 100, 50)); //test if the submarine is too old
            Assert.Throws<ArgumentException>(() => new Submarine("Båt 1", "1930", 100, 50)); //test if the submarine is too old
            Assert.Throws<ArgumentException>(() => new Submarine("Båt 1", "1970", 100, 50)); //test if the submarine is too old
            Assert.Throws<ArgumentException>(() => new Submarine("Båt 1", "", 100, 50)); //test exception for when year is empty
        }

        [Fact]
        public void Test_submarine_name_exceptions()
        {
            Assert.Throws<ArgumentException>(() => new Submarine("", "1960", 100, 50)); //test name == NULL exception
            Assert.Throws<ArgumentException>(() => new Submarine(null, "2000", 100, 50)); //test year == NULL exception
        }

        [Fact]
        public void Test_speed_exceptions()
        {
            Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "1960", 100, 50).GetSpeed("")); //test if the speed is empty
            Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "1960", 100, 50).GetSpeed(null)); //test if the speed is null
            Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "1960", 100, 50).GetSpeed("km/h")); //test if the speed is km/h
        }
        //dont need to test for types as they are set in the constructor and will never be null
        [Fact]
        public void Test_exception_messages() //if string is null it will just print standard message
        {
            var exception = Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "1999", 100, 50));
            Assert.Equal("Vessel is too old", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => new Ferry("", "1940", 100, 50));
            Assert.Equal("Name cannot be null or empty", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "", 100, 50));
            Assert.Equal("Year cannot be null or empty", exception.Message);

            string format = "m/h";
            exception = Assert.Throws<ArgumentException>(() => new Ferry("Båt 1", "2015", 100, 50).GetSpeed(format));
            Assert.Equal("The " + format + " format string is not supported.", exception.Message);
        }

        [Fact]
        public void Test_VesselInfo() //creates 3 different vessels and tests their info
        {
            var ferry = new Ferry("Båt 1", "2012", 100, 50);
            var tugboat = new Tugboat("Båt 2", "2012", 100, 70);
            var submarine = new Submarine("Båt 3", "2012", 100, 90);

            
            Vessel[] array = new Vessel[] {ferry, tugboat, submarine};
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString());
                Assert.Equal("Båt " + (i + 1), array[i].GetName());
                Assert.Equal("2012", array[i].GetYearBuilt());
                if (i == 0)
                {
                    Assert.Equal("50 m/s", array[i].GetSpeed("m/s"));
                }
                else if (i == 1)
                {
                    Assert.Equal("70 m/s", array[i].GetSpeed("m/s"));
                }
                else if (i == 2)
                {
                    Assert.Equal("90 m/s", array[i].GetSpeed("m/s"));
                }
            }
        }

    }
}