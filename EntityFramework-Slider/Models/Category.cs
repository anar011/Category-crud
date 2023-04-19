using Microsoft.Build.Framework;

namespace EntityFramework_Slider.Models
{
    public class Category:BaseEntity
    {
      /*  [Required]*/    /// Data mecburi sekilde olmalidir//
        public string? Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
