namespace UMS.Models.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Tекуща парола")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Новата парола трябва да бъде най-малко {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори парола")]
        [Compare("NewPassword", ErrorMessage = "Новата парола и паролата за потвърждение не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}
