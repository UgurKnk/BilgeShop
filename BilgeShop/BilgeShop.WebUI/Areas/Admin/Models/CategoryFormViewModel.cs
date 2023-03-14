using System.ComponentModel.DataAnnotations;

namespace BilgeShop.WebUI.Areas.Admin.Models
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ad")] // Name'i Türkçeye çevirme.
        [Required(ErrorMessage ="Kategori adını girmek zorunludur.")]
        public string Name { get; set; }

        [Display(Name="Açıklama")] // Description Türekçeye çevirdik.

        public string? Description { get; set; }
        // ? ile required olma durumunu kaldırabilir.
    }
}
