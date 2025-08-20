using System.ComponentModel.DataAnnotations;

namespace Single_Page_Task_02072025.Models
{
    public class ProductService
    {
        [Key]
        public int ProductServiceId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string? Name { get; set; }
        public string? Unit { get; set; }
    }
}
