using Application.Models;


namespace Application.Contracts.Identity;

public interface IAuthService
{
    public Task<(int, string)> Registration(RegistrationModel model, string role);

    public Task<(int, string)> Login(LoginModel model);
}