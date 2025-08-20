
using System.ComponentModel.DataAnnotations;

namespace Single_Page_Task_02072025.Models
{
    public class CorporateCustomer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Corporate customer name is required")]
        public string Name { get; set; }
    }
}
