namespace SwaggerUiDemo.Api.Controllers;

public interface IUserService
{
    List<User> GetAll();

    User Get(Guid id);

    User Create(User user);
}

public class UserService : IUserService
{
    private readonly Dictionary<Guid, User> _users = new();
    
    public List<User> GetAll()
    {
        return _users.Values.ToList();
    }

    public User Get(Guid id)
    {
        return _users[id];
    }

    public User Create(User user)
    {
        _users.Add(user.Id, user);
        return user;
    }
}