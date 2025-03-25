using Domain.Entity;
using Domain.ApiResponse;

namespace Infrastructure.Interfaces;

public interface ICommentService
{
    Task<ApiResponse<string>> AddCommentAsync(Comment comment);
    Task<ApiResponse<string>> DeleteCommentAsync(int Id);
    Task<ApiResponse<string>> UpdateCommentAsync(Comment comment);
    Task<ApiResponse<Comment>> GetCommentByIdAsync(int Id);
    Task<ApiResponse<List<Comment>>> GetCommentsAsync();
}
