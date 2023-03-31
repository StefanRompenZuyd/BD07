using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BD07.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Achternaam is verplicht.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Geboortedatum is verplicht.")]
        public DateTime Birthdate { get; set; }
        public bool TreatmentStatus { get; set; }
        public List<Persciption> Perscriptions { get; set; }
        public string MedicalInfo { get; set; }



    }
}
