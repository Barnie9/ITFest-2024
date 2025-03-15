using API.Models.Auth;
using API.Entities;
using API.Mappers;
using API.Repositories;
using API.Utils;

namespace API.Services.Implementation;

public class AuthService(IUserRepository userRepository) : IAuthService
{
    public async Task<bool> RegisterAsync(RegisterModel registerModel)
    {
        User user = UserMapper.MapRegisterModelToUserEntity(registerModel);

        user.Roles =
        [
            new Role
            {
                Name = "User",
            }
        ];

        await userRepository.CreateAsync(user);

        return true;
    }

    public async Task<AuthResponseModel?> LoginAsync(LoginModel loginModel)
    {
        User? user;
        if (loginModel.Username != null)
        {
            user = await userRepository.GetByUsernameAsync(loginModel.Username);
        }
        else if (loginModel.Email != null)
        {
            user = await userRepository.GetByEmailAsync(loginModel.Email);
        }
        else
        {
            return null;
        }

        if (user == null || !BCrypt.Net.BCrypt.EnhancedVerify(loginModel.Password, user.PasswordHash))
        {
            return null;
        }

        return new AuthResponseModel
        {
            Token = JwtUtil.GenerateToken(user),
            RefreshToken = user.RefreshToken
        };
    }

    public async Task<AuthResponseModel?> RefreshTokenAsync(string refreshToken)
    {
        User? user = await userRepository.GetByRefreshTokenAsync(refreshToken);
        if (user == null)
        {
            return null;
        }

        if (user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            return new AuthResponseModel
            {
                Token = JwtUtil.GenerateToken(user),
                RefreshToken = JwtUtil.GenerateRefreshToken()
            };
        }

        return new AuthResponseModel
        {
            Token = JwtUtil.GenerateToken(user),
            RefreshToken = user.RefreshToken
        };
    }
}