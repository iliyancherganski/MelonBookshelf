using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MelonBookshelf.Data.Models;
using MelonBookshelf.Data.Models.Requests;
using MelonBookshelf.Data.Models.Resources;
using Microsoft.EntityFrameworkCore;
using MelonBookshelf.Data.Models.Resources.Actions;

namespace MelonBookshelf.Data
{
    public class BookshelfDbContext : IdentityDbContext
    {
        public BookshelfDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Resource> Resources { get; set; } = null!;
        public DbSet<CategoryResource> CategoriesResources { get; set; } = null!;
        public DbSet<ResourceRequest> ResourcesRequests { get; set; } = null!;
        public DbSet<CategoryRequest> CategoriesRequests { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<RequestFollow> RequestFollows { get; set; } = null!;
        public DbSet<RequestUpvote> RequestUpvotes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestFollow>()
                .HasKey(x => new
                {
                    x.UserId,
                    x.RequestId
                });

            modelBuilder
                .Entity<RequestFollow>()
                .HasOne(e => e.ResourceRequest)
                .WithMany(e => e.RequestFollows)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<RequestUpvote>()
                .HasOne(e => e.ResourceRequest)
                .WithMany(e => e.RequestUpvotes)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RequestUpvote>()
                .HasKey(x => new
                {
                    x.UserId,
                    x.RequestId
                });

            modelBuilder.Entity<CategoryResource>()
                .HasKey(x => new
                {
                    x.CategoryId,
                    x.ResourceId
                });
            modelBuilder.Entity<CategoryRequest>()
                .HasKey(x => new
                {
                    x.RequestId,
                    x.CategoryId
                });


            base.OnModelCreating(modelBuilder);
        }
    }
}