using System.ComponentModel.DataAnnotations;

namespace HotelGestionale.Models
{
    public class Login
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Inserisci username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Inserisci password")]
        public string Password { get; set; }
    }
}
