namespace WebApplication1;
using Domain.ApiResponse;
using Domain.Entity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClapController
{
    private readonly ClapService _clapService = new();
    [HttpGet]
    public async Task<ApiResponse<List<Clap>>> GetClapsAsync()
    {
        var users = await _clapService.GetClapsAsync();
        return users;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Clap>> GetClapByIdAsync(int id)
    {
        var user = await _clapService.GetClapByIdAsync(id);
        return user;
    }

    [HttpPost]
    public async Task<ApiResponse<string>> AddClapAsync(Clap clap)
    {
        var result = await _clapService.AddClapAsync(clap);
        return result;
    }

    [HttpPut]
    public async Task<ApiResponse<string>> UpdateClapAsync(Clap clap)
    {
        var result = await _clapService.UpdateClapAsync(clap);
        return result;
    }

    [HttpDelete]
    public async Task<ApiResponse<string>> DeletClapAsync(int id)
    {
        var result = await _clapService.DeleteClapAsync(id);
        return result;
    }
}
