namespace aspnet_crm.Data.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Giro { get; set; }
        public string ImageURL { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
