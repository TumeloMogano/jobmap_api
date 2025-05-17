using System.ComponentModel.DataAnnotations;

namespace JobMap.API.Models.Entities
{
    public class HiringLikelihood
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        //nav props
        public ICollection<JobApplication> Applications { get; set; }
    }
}
