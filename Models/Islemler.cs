using System.ComponentModel.DataAnnotations.Schema;

namespace AspProject1.Models
{
    public class Islemler
{
    public int IslemID { get; set; }
    public int AracID { get; set; }  
    public int BakimID { get; set; } 
    public DateTime IslemTarihi { get; set; } = DateTime.Now;
    public string? IslemNotu { get; set; }

  
    public Araclar Arac { get; set; }  
    public BakimFiyatlari BakimFiyat { get; set; }  
}


}
