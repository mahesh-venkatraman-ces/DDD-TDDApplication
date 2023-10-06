using TestApplication.Contracts.UserDetails;

namespace TestApplication.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User
                {
                    Id=1,
                        Name="Test User 1",
                        Address=new Address()
                        {
                            Street = "Menamkulam",
                            City = "Trivandrum",
                            ZipCode = "695582"
                        },
                        Email="test.user.1@test.com"
                },
                new User
                {
                    Id=1,
                        Name="Test User 2",
                        Address=new Address()
                        {
                            Street = "Kowdiar",
                            City = "Trivandrum",
                            ZipCode = "695003"
                        },
                        Email="test.user.2@test.com"
                },
                new User
                {
                    Id=1,
                        Name="Test User 3",
                        Address=new Address()
                        {
                            Street = "Peroorkada",
                            City = "Trivandrum",
                            ZipCode = "695005"
                        },
                        Email="test.user.3@test.com"
                }
            };
    }
}
