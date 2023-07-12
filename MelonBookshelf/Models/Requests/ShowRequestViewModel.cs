using MelonBookshelf.Data.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace MelonBookshelf.Models.Requests
{
    public class ShowRequestViewModel
    {
        public ShowRequestViewModel(ShowRequestDto r)
        {
            Id = r.Id;
            Categories = r.Categories;
            Title = r.Title;
            Author = r.Author;
            Status = r.Status.ToString();
            Priority = r.Priority.ToString();
            DateAdded = r.DateAdded;
            UsersUpvoted = r.UsersUpvoted.ToList();
            Upvotes = UsersUpvoted.Count();
        }

        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public IEnumerable<string> Categories { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public string Priority { get; set; } = null!;

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public IEnumerable<string> UsersUpvoted { get; set; }

        [Required]
        public int Upvotes { get; set; }
    }
}