using System.ComponentModel.DataAnnotations;
using MehdiShop.Resources;

namespace MehdiShop.Models;

public class RegisterViewModel
{
    [Required(ErrorMessageResourceName = "Validation_InputIsRequired", ErrorMessageResourceType = typeof(ClientResource))]
    [MaxLength(200)]
    [EmailAddress(ErrorMessageResourceName = "Validation_InputIsNotValid", ErrorMessageResourceType = typeof(ClientResource))]
    [Display(Name = "ایمیل")]
    public string Email { get; set; }
    
    [Required(ErrorMessageResourceName = "Validation_InputIsRequired", ErrorMessageResourceType = typeof(ClientResource))]
    [MaxLength(50)]
    [DataType(DataType.Password)]
    [Display(Name = "کلمه عبور")]
    public string Password { get; set; }
    
    [Required(ErrorMessageResourceName = "Validation_InputIsRequired", ErrorMessageResourceType = typeof(ClientResource))]
    [MaxLength(50)]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessageResourceName = "Validation_TwoInputIsNotMatched", ErrorMessageResourceType = typeof(ClientResource))]
    [Display(Name = "تکرار کلمه عبور")]
    public string RePassword { get; set; }
}