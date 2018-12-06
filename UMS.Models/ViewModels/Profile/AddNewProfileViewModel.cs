namespace UMS.Models.ViewModels.Profile
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class AddNewProfileViewModel
    {
        [Required]
        [Display(Name = "Направление")]
        public string SelectedHeading { get; set; }
        public IEnumerable<SelectListItem> Headings { get; set; }

       [Display(Name = "Управление")]
       public string SelectedDirection { get; set; }
       public IEnumerable<SelectListItem> Directions { get; set; }
       
       [Display(Name = "Дирекция")]
       public string SelectedDirectorate { get; set; }
       public IEnumerable<SelectListItem> Directorates { get; set; }
       
       [Required]
       [Display(Name = "Позиция")]
       public string SelectedPosition { get; set; }
       public IEnumerable<SelectListItem> Positions { get; set; }
    }
}
