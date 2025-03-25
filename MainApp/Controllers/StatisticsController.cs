namespace WebApplication1;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController
{
    private readonly StatisticService _statisticsService = new();
    [HttpGet]
    public async Task<ApiResponse<List<Article>>> GetArticlesAsync(int id)
    {
        var users = await _statisticsService.GetUserArticlesAsync(id);
        return users;
    }
    [HttpGet]
    public async Task<ApiResponse<List<Article>>> GetArticleRecentCommentsAsync(int id)
    {
        var users = await _statisticsService.GetArticleRecentCommentsAsync(id);
        return users;
    }
    [HttpGet]
    public async Task<ApiResponse<List<Article>>> GetArticleClapsCountAsync(int id)
    {
        var users = await _statisticsService.GetArticleClapsCountAsync(id);
        return users;
    }
    [HttpGet]
    public async Task<ApiResponse<List<Task4>>> GetRecentArticlesAsync()
    {
        var users = await _statisticsService.GetRecentArticlesAsync();
        return users;
    }
    [HttpGet]
    public async Task<ApiResponse<List<int>>> GetUserStatsAsync(int id)
    {
        var users = await _statisticsService.GetUserStatsAsync(id);
        return users;
    }
}
