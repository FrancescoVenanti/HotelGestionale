using System.ComponentModel.DataAnnotations;

namespace HotelGestionale.Models
{
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
