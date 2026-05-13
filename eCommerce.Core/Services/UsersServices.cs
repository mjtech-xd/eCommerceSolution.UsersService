using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class UsersServices(IUserRepository userRepository) : IUserService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        ApplicationUser? user = await userRepository.GetUserByEmailAndPassword(request.Email, request.Password);
        if (user == null)
            return null;
        
        GenderOptions gender = Enum.Parse<GenderOptions>(user.Gender ?? "Male");
        return new AuthenticationResponse(user.UserId, user.Email, user.Password, user.PersonName,
            gender, "token", Success: true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {
        var newUser = new ApplicationUser
        {
            UserId = Guid.NewGuid(),
            Email = request.Email,
            Password = request.Password,
            PersonName = request.PersonName,
            Gender = request.Gender.ToString() 
        };

        ApplicationUser? user = await userRepository.AddUser(newUser);
        if (user == null)
            return null;

        return new AuthenticationResponse(user.UserId, user.Email, user.Password, user.PersonName,
            request.Gender, "token", Success: true);
    }
}