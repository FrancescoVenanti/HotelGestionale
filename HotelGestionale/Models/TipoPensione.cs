using System.ComponentModel.DataAnnotations;

namespace HotelGestionale.Models
{
    public class TipoPensione
    {
        public int ID { get; set; }
        [Display(Name = "Tipo Pensione")]
        [Required(ErrorMessage = "Il tipo pensione è obbligatorio")]
        public string Tipologia { get; set; }
        [Display(Name = "Prezzo")]
        public double ?Prezzo { get; set; }
    }
}
