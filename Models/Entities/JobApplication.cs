namespace JobMan.API.Models.Entities
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
    }
}
