using IdentityV4.Api.Models;

namespace IdentityV4.Api.Services
{
    public class UserService : IUserService
    {
        private List<UserModel> users => new()
    {
        new UserModel { Id = 1, Name = "Test", BirthDate = new DateTime(1905, 10, 10), City = "Ankara", Email = "test@test.com", Gender = "Man", Username = "test", Roles = { "Admin" } },
        new UserModel { Id = 2, Name = "Albert Camus", BirthDate = new DateTime(1899, 10, 10), City = "Ankara", Email = "albert@test.com", Gender = "Man", Username = "albert", Roles = { "Author" } },
        new UserModel { Id = 3, Name = "Frank Herbert", BirthDate = new DateTime(1930, 10, 10), City = "Ankara", Email = "frank@test.com", Gender = "Man", Username = "frank", Roles = { "Editor" } },
        new UserModel { Id = 4, Name = "Isaac Asimov", BirthDate = new DateTime(1940, 10, 10), City = "Ankara", Email = "asimov@test.com", Gender = "Man", Username = "asimov", Roles = { "Editor", "Author" } },
        new UserModel { Id = 5, Name = "Tolstoy", BirthDate = new DateTime(1936, 10, 10), City = "Ankara", Email = "tolstoy@test.com", Gender = "Man", Username = "tolstoy", Roles = { "Editor", "Reader" } },
        new UserModel { Id = 6, Name = "Ursula", BirthDate = new DateTime(1945, 10, 10), City = "Ankara", Email = "ursula@test.com", Gender = "Woman", Username = "ursula", Roles = { "Editor", "Master" } },
    };
        public UserModel? GetById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }
        public UserModel? GetByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }
    }
    public interface IUserService
    {
        UserModel? GetById(int id);
        UserModel? GetByUsername(string username);
    }
}
