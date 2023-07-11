using MelonBookshelf.Models.Choosable;
using System.ComponentModel.DataAnnotations;

namespace MelonBookshelf.Models.Requests
{
    public class RequestEditViewModel
    {
        [Required]
        public List<int> CategoryIds { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public int Priority { get; set; }

        [Required]
        public string? Justification { get; set; } = null!;

        [Required]
        public List<string> Categories { get; set; } = null!;

        [Required]
        public List<string> Priorities { get; set; } = null!;
    }
}
