namespace UMS.Models.ViewModels.Menu
{
    using System.ComponentModel.DataAnnotations;

    public class AddProfileMenu
    {
        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Достъп до услуга:")]
        public string System { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Роля/Права/Достъп")]
        public string Role { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
