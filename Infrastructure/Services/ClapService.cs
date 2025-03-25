using Infrastructure.Interfaces;
using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entity;
using Infrastructure.Data;
namespace Infrastructure.Services;

public class ClapService : IClapService
{
    private readonly DataContext _dataContext = new();
    public async Task<ApiResponse<List<Clap>>> GetClapsAsync()
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from Claps";
        var result = await conn.QueryAsync<Clap>(sql);
        return new ApiResponse<List<Clap>>(result.ToList());
    }
    public async Task<ApiResponse<Clap>> GetClapByIdAsync(int Id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from Claps where id = @id";
        var result = await conn.QueryFirstOrDefaultAsync<Clap>(sql, new{id = Id});
        return new ApiResponse<Clap>(result);
    }
    public async Task<ApiResponse<string>> AddClapAsync(Clap clap)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"insert into Claps (article_Id, user_Id, count, created_at)
        values
        (@articleId, @userId, @count, @createdat)";
        var result = await conn.ExecuteAsync(sql, clap);
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("Clap added");
    }
    public async Task<ApiResponse<string>> UpdateClapAsync(Clap clap)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"update Claps set article_Id = @articleId, user_Id = @userId, count = @count, created_at = @createdat
        where id = @id";
        var result = await conn.ExecuteAsync(sql, clap);
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("Clap updated");
    }
    public async Task<ApiResponse<string>> DeleteClapAsync(int Id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"delete from Claps where id = @id";
        var result = await conn.ExecuteAsync(sql, new{Id = Id});
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("Clap deleted");
    }
}
