using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace JobMap.API.Models.Entities
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //nav props
        public ICollection<JobApplication> Applications { get; set; }

    }
}
