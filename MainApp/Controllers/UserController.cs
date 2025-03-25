using Domain.ApiResponse;
using Domain.Entity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly UserService _userService = new();
    [HttpGet]
    public async Task<ApiResponse<List<User>>> GetUsersAsync()
    {
        var users = await _userService.GetUsersAsync();
        return users;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<User>> GetUserByIdAsync(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return user;
    }

    [HttpPost]
    public async Task<ApiResponse<string>> AddUserAsync(User user)
    {
        var result = await _userService.AddUserAsync(user);
        return result;
    }

    [HttpPut]
    public async Task<ApiResponse<string>> UpdateUserAsync(User user)
    {
        var result = await _userService.UpdateUserAsync(user);
        return result;
    }

    [HttpDelete]
    public async Task<ApiResponse<string>> DeleteUserAsync(int id)
    {
        var result = await _userService.DeleteUserAsync(id);
        return result;
    }
}
