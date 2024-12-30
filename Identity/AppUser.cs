using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EShopAPI.Identity;

public class AppUser: IdentityUser
{
    [MaxLength(70)]
    public string FullName { get; set; } = string.Empty;
}