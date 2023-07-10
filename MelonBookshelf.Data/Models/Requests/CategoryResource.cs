using System.ComponentModel.DataAnnotations.Schema;

namespace MelonBookshelf.Data.Models.Requests
{
    public class CategoryResource
    {
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!; 

        [ForeignKey(nameof(Resource))]
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; } = null!;
    }
}
