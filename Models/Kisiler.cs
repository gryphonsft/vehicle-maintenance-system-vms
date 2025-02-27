using System.ComponentModel.DataAnnotations;

namespace AspProject1.Models
{
    public class Kisiler
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }
    }
}
