using Domain.Entity;
using Domain.ApiResponse;

namespace Infrastructure.Interfaces;

public interface IUserService
{
    Task<ApiResponse<string>> AddUserAsync(User user);
    Task<ApiResponse<string>> DeleteUserAsync(int Id);
    Task<ApiResponse<string>> UpdateUserAsync(User user);
    Task<ApiResponse<User>> GetUserByIdAsync(int Id);
    Task<ApiResponse<List<User>>> GetUsersAsync();
}
