using System.Security.Claims;
using Application.Contracts.Identity;
using Application.Models;
using Application.Services.Utils;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Application.Services.AuthentificationServices;


public class AuthService(
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration configuration,
    UtilsService utilsService,
    SignInManager<User> signInManager)
    : IAuthService // This is the implementation of the IAuthService interface
{
    private readonly IConfiguration _configuration = configuration;

    public async Task<(int, string)> Registration(RegistrationModel model, string role)
    {
        var userExist = await userManager.FindByNameAsync(model.UserName);
        if (userExist != null)
        {
            return (0, "User already exists!");
        }

        Console.WriteLine("Email is aaaaaa: " + model.EmailAddress);

        var emailExist = await userManager.FindByEmailAsync(model.EmailAddress);
        if (emailExist != null)
        {
            return (0, "Email already exists!");
        }


        var new_user = User.Create(
            model.UserName,
            model.EmailAddress,
            model.Address,
            model.PhoneNumber
        );


        if (new_user.IsSuccess == false)
        {
            Console.WriteLine(new_user.Error);
            return (0, new_user.Error);
        }


        IdentityResult result;
        var newUserValue = new_user.Value;
        try
        {
            result = await userManager.CreateAsync(newUserValue, model.Password);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (0, e.Message);
        }


        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }


        await roleManager.CreateAsync(new IdentityRole(role));
        await userManager.AddToRoleAsync(newUserValue, role);

        var emailDomain = model.EmailAddress.Split('@')[1];



        return (1, "User created successfully!");
    }

    public async Task<(int, string)> Login(LoginModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return (0, "User not found!");
        }

        if (!await userManager.CheckPasswordAsync(user, model.Password))
        {
            return (0, "Invalid credentials");
        }


        //attach the roles
        var userRoles = await userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };


        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }


        var token = utilsService.GenerateToken(authClaims);


        return (1, token);
    }
}