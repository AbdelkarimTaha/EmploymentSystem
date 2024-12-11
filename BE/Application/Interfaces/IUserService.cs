using Application.Dtos;

namespace Application.Interfaces;

public interface IUserService
{
    Task<object> LoginAsync(string username, string password);
    Task<object> RegisterAsync(RegisterDto model);
}
