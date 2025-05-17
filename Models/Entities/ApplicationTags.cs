using Azure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobMap.API.Models.Entities
{
    public class ApplicationTags
    {
        public Guid ApplicationId { get; set; }
        public JobApplication Application { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
