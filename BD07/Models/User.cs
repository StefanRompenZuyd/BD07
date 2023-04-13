using BD07.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BD07.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Achternaam is verplicht.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Geboortedatum is verplicht.")]
        public DateTime Birthdate { get; set; }
        [EnumDataType(typeof(TreatmentStatusEnum))]
        public TreatmentStatusEnum TreatmentStatus { get; set; }
        public List<Presciption> Persciptions { get; set; }
        public string MedicalInfo { get; set; }
    }
}
