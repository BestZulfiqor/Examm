namespace WebApplication1;
using Domain.ApiResponse;
using Domain.Entity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ArticleController
{
    private readonly ArticleService _articleService = new();
    [HttpGet]
    public async Task<ApiResponse<List<Article>>> GetArticlesAsync()
    {
        var users = await _articleService.GetArticlesAsync();
        return users;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Article>> GetArticleByIdAsync(int id)
    {
        var user = await _articleService.GetArticleByIdAsync(id);
        return user;
    }

    [HttpPost]
    public async Task<ApiResponse<string>> AddArticleAsync(Article article)
    {
        var result = await _articleService.AddArticleAsync(article);
        return result;
    }

    [HttpPut]
    public async Task<ApiResponse<string>> UpdateCommentAsync(Article article)
    {
        var result = await _articleService.UpdateArticleAsync(article);
        return result;
    }

    [HttpDelete]
    public async Task<ApiResponse<string>> DeleteArticleAsync(int id)
    {
        var result = await _articleService.DeleteArticleAsync(id);
        return result;
    }
}
