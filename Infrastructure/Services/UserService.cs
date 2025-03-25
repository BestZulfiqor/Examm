using Domain.Entity;
using Domain.ApiResponse;
using Infrastructure.Interfaces;
using Infrastructure.Data;
using Dapper;
using System.Net;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly DataContext _dataContext = new();
    public async Task<ApiResponse<List<User>>> GetUsersAsync()
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from users";
        var result = await conn.QueryAsync<User>(sql);
        return new ApiResponse<List<User>>(result.ToList());
    }
    public async Task<ApiResponse<User>> GetUserByIdAsync(int Id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from users where id = @id";
        var result = await conn.QueryFirstOrDefaultAsync<User>(sql, new{id = Id});
        return new ApiResponse<User>(result);
    }
    public async Task<ApiResponse<string>> AddUserAsync(User user)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"insert into users (username, email, password_hash, bio, created_at)
        values
        (@username, @email, @passwordhash, @bio, @createdat)";
        var result = await conn.ExecuteAsync(sql, user);
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("User added");
    }
    public async Task<ApiResponse<string>> UpdateUserAsync(User user)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"update users set username = @username, email = @email, password_hash = @passwordhash, bio = @bio, created_at = @createdat
        where id = @id";
        var result = await conn.ExecuteAsync(sql, user);
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("User updated");
    }
    public async Task<ApiResponse<string>> DeleteUserAsync(int Id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"delete from users where id = @id";
        var result = await conn.ExecuteAsync(sql, new{Id = Id});
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("User deleted");
    }
}