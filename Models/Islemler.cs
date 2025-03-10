using System.ComponentModel.DataAnnotations.Schema;

namespace AspProject1.Models
{
    public class Islemler
{
    public int IslemID { get; set; }
    public int AracID { get; set; }  // Foreign key
    public int BakimID { get; set; } // Foreign key
    public DateTime IslemTarihi { get; set; } = DateTime.Now;
    public string IslemNotu { get; set; }

    // Navigation Properties
    public Araclar Arac { get; set; }  // Navigation property to Araclar
    public BakimFiyatlari BakimFiyat { get; set; }  // Navigation property to BakimFiyatlari
}


}
