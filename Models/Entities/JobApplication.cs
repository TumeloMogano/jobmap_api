using System.ComponentModel.DataAnnotations;

namespace JobMap.API.Models.Entities
{
    public class JobApplication
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? RoleTitle { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string? MainContactName { get; set; } = string.Empty;
        public string? MainContactEmail { get; set; } = string.Empty;
        public string? MainContactPhone { get; set; } = string.Empty;
        public int HiringLikelihoodId { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? DateApplied { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string? SalaryExpectationRange { get; set; }
        public string? RequiredDocumentation { get; set; } = string.Empty;
        public bool IsClosed { get; set; } = false;
        public string? Notes { get; set; } = string.Empty;

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //nav props
        public Status Status { get; set; }
        public HiringLikelihood HiringLikelihood { get; set; }
        public ICollection<ApplicationTags> ApplicationTags { get; set; }
    }
}
