using System.ComponentModel.DataAnnotations;

namespace Curso_ASP.Models.View_Model
{
    public class CategoryViewModel
    {
        //Required es para que sea obligatorio, y display para que el usuario vea otro nombre
        [Required]
        [Display(Name = "Nombre")]
        public string NameBrand { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int Brandld { get; set; }
    }
}
