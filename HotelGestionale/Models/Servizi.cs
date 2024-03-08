using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelGestionale.Models
{
    public class Servizi
    {
        public int ID { get; set; }
        [Display(Name = "Descrizione")]
        [Required(ErrorMessage = "La descrizione è obbligatorio")]
        public string Descrizione { get; set; }
        [Display(Name = "Prezzo")]
        public double ?Prezzo { get; set; }
        [Display(Name = "Data Servizio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataServizio { get; set; }

        [Display(Name = "Prenotazione")]
        [ForeignKey("Prenotazione")]
        public int IDPrenotazione { get; set; }
        public Prenotazioni? Prenotazione { get; set; }
    }
}
