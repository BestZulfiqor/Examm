using Domain.Entity;
using Domain.ApiResponse;

namespace Infrastructure.Interfaces;

public interface IClapService
{
    Task<ApiResponse<string>> AddClapAsync(Clap clap);
    Task<ApiResponse<string>> DeleteClapAsync(int Id);
    Task<ApiResponse<string>> UpdateClapAsync(Clap clap);
    Task<ApiResponse<Clap>> GetClapByIdAsync(int Id);
    Task<ApiResponse<List<Clap>>> GetClapsAsync();
}
