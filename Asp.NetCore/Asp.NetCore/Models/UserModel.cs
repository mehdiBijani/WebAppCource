using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore.Models;

public class UserModel
{
    [Required]
    [Display(Name = "نام")]
    public string FullName { get; set; }
    [Required]
    [Display(Name = "نام کاربری")]
    public string UserName { get; set; }
    [Required]
    [Display(Name = "رمز ورود")]
    public long Password { get; set; }
}