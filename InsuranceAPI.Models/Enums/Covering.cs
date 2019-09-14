using System.ComponentModel.DataAnnotations;

namespace InsuranceAPI.Models.Enums
{
    public enum Covering
    {
        [Display(Name = "Terremoto")]
        Terremoto,
        [Display(Name = "Incendio")]
        Incendio,
        [Display(Name = "Robo")]
        Robo,
        [Display(Name = "Pérdida")]
        Perdida
    }
}
