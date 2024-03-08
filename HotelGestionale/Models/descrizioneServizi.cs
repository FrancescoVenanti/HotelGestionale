using System.ComponentModel.DataAnnotations;

namespace HotelGestionale.Models
{
    // enum per i servizi offerti da''hotel, viene utilizzato per la creazione di un nuovo servizio
    public enum descrizioneServizi
    {
        [Display(Name = "Colazione in camera")]
        ColazioneInCamera,
        [Display(Name = "Bevande e cibo nel minibar")]
        BevandeECibo,
        [Display(Name = "Internet")]
        Internet,
        [Display(Name = "Letto aggiuntivo")]
        LettoAggiuntivo,
        [Display(Name = "Culla")]
        Culla,
    }
}
