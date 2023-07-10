using System.ComponentModel.DataAnnotations;

namespace MelonBookshelf.Data.Models.Requests
{
    public class Resource
    {
        public Resource()
        {
            CategoryResources = new List<CategoryResource>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = null!;

        // Status - 
        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public string OfficialPageUrl { get; set; } = null!;

        [Required]
        public string Details { get; set; } = null!;

        public virtual ICollection<CategoryResource> CategoryResources { get; set; }
    }
}
