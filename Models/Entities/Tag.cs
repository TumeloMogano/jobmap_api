using System.ComponentModel.DataAnnotations;

namespace JobMap.API.Models.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //nav props
        public ICollection<ApplicationTags> ApplicationTags { get; set; }
    }
}
