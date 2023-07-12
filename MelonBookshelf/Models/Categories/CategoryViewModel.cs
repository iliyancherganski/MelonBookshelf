using MelonBookshelf.Business.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MelonBookshelf.Models.Categories
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {

        }
        public CategoryViewModel(List<string> categoryNames)
        {
            if (categoryNames == null)
            {
                CategoryNames = new List<string>();
            }
            else
            {
                CategoryNames = categoryNames;
            }
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public List<string> CategoryNames { get; set; } = new List<string>();
    }
}
