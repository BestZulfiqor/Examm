namespace WebApplication1;
using Domain.ApiResponse;
using Domain.Entity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CommentController
{
    private readonly CommentService _commentService = new();
    [HttpGet]
    public async Task<ApiResponse<List<Comment>>> GetCommentsAsync()
    {
        var users = await _commentService.GetCommentsAsync();
        return users;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Comment>> GetCommentByIdAsync(int id)
    {
        var user = await _commentService.GetCommentByIdAsync(id);
        return user;
    }

    [HttpPost]
    public async Task<ApiResponse<string>> AddCommentAsync(Comment comment)
    {
        var result = await _commentService.AddCommentAsync(comment);
        return result;
    }

    [HttpPut]
    public async Task<ApiResponse<string>> UpdateCommentAsync(Comment comment)
    {
        var result = await _commentService.UpdateCommentAsync(comment);
        return result;
    }

    [HttpDelete]
    public async Task<ApiResponse<string>> DeleteCommentAsync(int id)
    {
        var result = await _commentService.DeleteCommentAsync(id);
        return result;
    }
}
