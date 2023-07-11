using MelonBookshelf.Data.Models.Enums;
using MelonBookshelf.Data.Models.Resources.Actions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MelonBookshelf.Data.Models.Requests
{
    public class ResourceRequest
    {
        public ResourceRequest()
        {
            CategoryRequests = new List<CategoryRequest>();
            RequestFollows = new List<RequestFollow>();
            RequestUpvotes = new List<RequestUpvote>();
        }

        [Key]
        public int Id { get; set; }

        // UserId - the Guid user Id
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        [MaxLength(40)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        public RequestStatus Status { get; set; }

        [Required]
        public RequestPriority Priority { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [MaxLength(200)]
        public string Justification { get; set; } = null!;

        [MaxLength(200)]
        public string? RejectionJustification { get; set; }

        public virtual ICollection<CategoryRequest> CategoryRequests { get; set; } = null!;
        public virtual ICollection<RequestFollow> RequestFollows { get; set; } = null!;
        public virtual ICollection<RequestUpvote> RequestUpvotes { get; set; } = null!;
    }
}
