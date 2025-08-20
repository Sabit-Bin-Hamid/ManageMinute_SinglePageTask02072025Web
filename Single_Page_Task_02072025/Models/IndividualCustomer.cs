using System.ComponentModel.DataAnnotations;

namespace Single_Page_Task_02072025.Models
{
    public class IndividualCustomer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Individual customer name is required")]
        public string Name { get; set; }
    }
}
