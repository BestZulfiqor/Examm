using Infrastructure.Interfaces;
using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entity;
using Infrastructure.Data;
namespace Infrastructure.Services;
public class ArticleService : IArticleService
{
    private readonly DataContext _dataContext = new();
    public async Task<ApiResponse<List<Article>>> GetArticlesAsync()
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from Articles";
        var result = await conn.QueryAsync<Article>(sql);
        return new ApiResponse<List<Article>>(result.ToList());
    }
    public async Task<ApiResponse<Article>> GetArticleByIdAsync(int Id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from Articles where id = @id";
        var result = await conn.QueryFirstOrDefaultAsync<Article>(sql, new { id = Id });
        return new ApiResponse<Article>(result);
    }
    public async Task<ApiResponse<string>> AddArticleAsync(Article article)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"insert into Articles (user_Id, title, content, description, created_at, status)
        values
        (@userId, @title, @content, @description, @createdat, @status)";
        var result = await conn.ExecuteAsync(sql, article);
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("Article added");
    }
    public async Task<ApiResponse<string>> UpdateArticleAsync(Article article)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"update Articles set user_Id = @userId, title = @title, content = @content, description = @description, created_at = @createdat, status = @status
        where id = @id";
        var result = await conn.ExecuteAsync(sql, article);
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("Article updated");
    }
    public async Task<ApiResponse<string>> DeleteArticleAsync(int Id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"delete from Articles where id = @id";
        var result = await conn.ExecuteAsync(sql, new { Id = Id });
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("Article deleted");
    }
}
