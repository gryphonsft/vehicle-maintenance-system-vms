using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
namespace AspProject1.Models
{
    public class Araclar
    {
        [Key]
        public int AracID { get; set; }

        [Required(ErrorMessage = "Plaka alanı boş geçilemez")]
        public string? Plaka { get; set; }

        [Required(ErrorMessage = "Marka alanı boş geçilemez")]
        public string? Marka { get; set; }
        [Required(ErrorMessage = "Model alanı boş geçilemez")]


        public string? Model { get; set; }
        [Required(ErrorMessage = "Yıl alanı boş geçilemez")]


        public int Yil { get; set; }
        [Required(ErrorMessage = "Bakım notu adı alanı boş geçilemez")]

        public string? BakimNotu { get; set; }
        [Required(ErrorMessage = "Müşteri adı alanı boş geçilemez")]

        public string? MusteriAdi { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş geçilemez")]
        public string? Telefon { get; set; }

        public virtual List<Islemler> Islemler { get; set; } = new List<Islemler>();


    }
}
