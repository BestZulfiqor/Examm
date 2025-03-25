using Dapper;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entity;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class StatisticService
{
    private readonly DataContext _dataContext = new();
    public async Task<ApiResponse<List<Article>>> GetUserArticlesAsync(int id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from articles where user_id = @id";
        var result = await conn.QueryAsync<Article>(sql, new { id = id });
        return new ApiResponse<List<Article>>(result.ToList());
    }

    public async Task<ApiResponse<List<Article>>> GetArticleRecentCommentsAsync(int id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from comments where article_id = @id order by id desc limit 5";
        var result = await conn.QueryAsync<Article>(sql, new { id = id });
        return new ApiResponse<List<Article>>(result.ToList());
    }

    public async Task<ApiResponse<List<Article>>> GetArticleClapsCountAsync(int id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select count(*) from claps where article_id = @id";
        var result = await conn.QueryAsync<Article>(sql, new{id = id});
        return new ApiResponse<List<Article>>(result.ToList());
    }

    public async Task<ApiResponse<List<Task4>>> GetRecentArticlesAsync()
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"select a.id, u.username, a.title, a.content, a.description, a.created_At  
                from articles as a join users as u on a.user_id = u.id
                where status = 'published' order by id desc limit 10";
        var result = await conn.QueryAsync<Task4>(sql);
        return new ApiResponse<List<Task4>>(result.ToList());
    }

    public async Task<ApiResponse<List<int>>> GetUserStatsAsync(int id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"select count(*) from articles where user_id = @id";
        var sql2 = "select count(*) from comments where user_id = @id";
        var result = await conn.QueryAsync<int>(sql);
        result = await conn.QueryAsync<int>(sql2);
        return new ApiResponse<List<int>>(result.ToList());
    }
}
