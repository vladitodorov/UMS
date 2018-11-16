namespace UMS.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле {0} е задължително.")]
        [Display(Name = "Потребителско име")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Поле {0} е задължително.")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле {0} е задължително.")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле {0} е задължително.")]
        [StringLength(100, ErrorMessage = "{0}-та трябва да бъде не по-малко от {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори парола")]
        [Compare("Password", ErrorMessage = "Паролата и паролата за потвърждение не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}
