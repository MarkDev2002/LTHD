using System.ComponentModel.DataAnnotations;

namespace FirstModelBinding.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public decimal? Rate { get; set; }
        public int Rating { get; set; }
    }
}
