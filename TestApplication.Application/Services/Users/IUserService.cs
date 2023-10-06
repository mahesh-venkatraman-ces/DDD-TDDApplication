using TestApplication.Contracts.UserDetails;

namespace TestApplication.Application.Services.Users
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }
}
