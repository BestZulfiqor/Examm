using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CommentService : ICommentService
{
    private readonly DataContext _dataContext = new();
    public async Task<ApiResponse<List<Comment>>> GetCommentsAsync()
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from comments";
        var result = await conn.QueryAsync<Comment>(sql);
        return new ApiResponse<List<Comment>>(result.ToList());
    }
    public async Task<ApiResponse<Comment>> GetCommentByIdAsync(int Id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = "select * from Comments where id = @id";
        var result = await conn.QueryFirstOrDefaultAsync<Comment>(sql, new{id = Id});
        return new ApiResponse<Comment>(result);
    }
    public async Task<ApiResponse<string>> AddCommentAsync(Comment comment)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"insert into Comments (article_Id, user_Id, content, created_at)
        values
        (@articleId, @userId, @content, @createdat)";
        var result = await conn.ExecuteAsync(sql, comment);
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("Comment added");
    }
    public async Task<ApiResponse<string>> UpdateCommentAsync(Comment comment)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"update comments set article_Id = @articleId, user_Id = @userId, content = @content, created_at = @createdat
        where id = @id";
        var result = await conn.ExecuteAsync(sql, comment);
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("Comment updated");
    }
    public async Task<ApiResponse<string>> DeleteCommentAsync(int Id)
    {
        using var conn = await _dataContext.GetConnectionAsync();
        conn.Open();
        var sql = @"delete from Comments where id = @id";
        var result = await conn.ExecuteAsync(sql, new{Id = Id});
        return result == 0
            ? new ApiResponse<string>(HttpStatusCode.BadRequest, "Something went wrong")
            : new ApiResponse<string>("Comment deleted");
    }
}
