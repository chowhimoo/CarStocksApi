using CarStocksApi.Models;

namespace CarStocksApi.Interfaces
{
    public interface IAuthService
    {
        Task<(int, string)> Registeration(Register model, string role);
        Task<(int, string)> Login(LoginRequest model);
    }
}
