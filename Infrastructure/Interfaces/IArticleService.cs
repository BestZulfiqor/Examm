using Domain.Entity;
using Domain.ApiResponse;

namespace Infrastructure.Interfaces;

public interface IArticleService
{
    Task<ApiResponse<string>> AddArticleAsync(Article article);
    Task<ApiResponse<string>> DeleteArticleAsync(int Id);
    Task<ApiResponse<string>> UpdateArticleAsync(Article article);
    Task<ApiResponse<Article>> GetArticleByIdAsync(int Id);
    Task<ApiResponse<List<Article>>> GetArticlesAsync();
}
