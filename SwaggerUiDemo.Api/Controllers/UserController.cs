using Microsoft.AspNetCore.Mvc;

namespace SwaggerUiDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Get All Users.
    /// </summary>
    /// <returns>List of All Users</returns>
    /// <remarks>
    /// There is no persistence here, just in-memory.
    /// </remarks>
    [HttpGet("GetAll")]
    public List<User> GetAll()
    {
        return _userService.GetAll();
    }

    /// <summary>
    /// Gets the user record corresponding to the supplied ID.
    /// </summary>
    /// <param name="id">ID in Guid format</param>
    /// <returns>user record</returns>
    /// <remarks>
    /// Guid format is: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.
    /// More information at:
    ///   * https://docs.microsoft.com/en-us/dotnet/api/system.guid?view=net-6.0
    ///   * http://guid.one/guid
    /// </remarks>
    [HttpGet("Get")]
    public User Get(Guid id)
    {
        return _userService.Get(id);
    }

    /// <summary>
    /// Creates new user from given Parameters.
    /// </summary>
    /// <param name="username">Username</param>
    /// <param name="email">Email</param>
    /// <param name="password">Password</param>
    /// <returns>Newly created user</returns>
    /// <remarks>
    /// Guid is generated automatically and returned in response.
    /// </remarks>
    [HttpPost("Create")]
    public User Create(string username, string email, string password)
    {
        var user = new User
        {
            Username = username,
            Email = email,
            Password = password
        };
        return _userService.Create(user);
    }
}