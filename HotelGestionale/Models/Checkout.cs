namespace HotelGestionale.Models
{
    public class Checkout
    {
        public Prenotazioni Prenotazione { get; set; }
        public List<Servizi> Servizi { get; set; }
    }
}
