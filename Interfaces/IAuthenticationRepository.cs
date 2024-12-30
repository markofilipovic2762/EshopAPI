using EShopAPI.Dtos;

namespace EShopAPI.Interfaces;

public interface IAuthenticationRepository
{
    Task<IResult> LoginAsync(LoginDto loginDto);
}