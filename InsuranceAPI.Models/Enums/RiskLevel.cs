using System.ComponentModel.DataAnnotations;

namespace InsuranceAPI.Models.Enums
{
    public enum RiskLevel
    {
        [Display(Name = "Bajo")]
        Bajo = 1,
        [Display(Name = "Medio")]
        Medio,
        [Display(Name = "Medio-Alto")]
        MedioAlto,
        [Display(Name = "Alto")]
        Alto
    }
}
