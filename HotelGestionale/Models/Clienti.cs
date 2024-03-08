using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelGestionale.Models
{
    public class Clienti
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il campo Cognome è obbligatorio")]
        public string Cognome { get; set; }
        [Display(Name = "Codice Fiscale")]
        [Required(ErrorMessage = "Il campo Codice Fiscale è obbligatorio")]
        [MaxLength(16, ErrorMessage = "Il campo Codice Fiscale deve essere di 16 caratteri")]
        public string CodiceFiscale { get; set; }
        [Display(Name = "citta")]
        [Required(ErrorMessage = "Il campo Città è obbligatorio")]
        public string Citta { get; set; }
        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Il campo Provincia è obbligatorio")]
        public string Provinvia { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Il campo Email è obbligatorio")]
        [Remote("EmailValidator", "Home", ErrorMessage = "L'Email non e' valida")]
        public string Email { get; set; }
        [Display(Name = "Telefono")]
        [MaxLength(10, ErrorMessage = "Il campo Telefono deve essere di 10 caratteri")]
        
        public string ?Telefono { get; set; }
        [Display(Name = "Cellulare")]
        [Required(ErrorMessage = "Il campo Cellulare è obbligatorio")]
        [MaxLength(10, ErrorMessage = "Il campo Cellulare deve essere di 10 caratteri")]
        public string Cellulare { get; set; }
        
    }
}
