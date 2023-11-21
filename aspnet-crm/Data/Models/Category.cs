using System.ComponentModel.DataAnnotations;

namespace aspnet_crm.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Category name can not be empty!")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public List<Company> Companies { get; set; }
    }
}
