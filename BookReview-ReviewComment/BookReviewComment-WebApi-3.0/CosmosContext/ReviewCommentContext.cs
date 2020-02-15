using DBEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Cosmos;

namespace DBContext
{
    public class ReviewCommentContext : DbContext
    {
        public ReviewCommentContext()
        {
        }

        public ReviewCommentContext(DbContextOptions<ReviewCommentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookReview> BookReview { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseCosmos(
                    "https://localhost:8081",
                    "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                    databaseName: "BookReviewComments");
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");
            modelBuilder.HasDefaultContainer("BookReviewComments");
            modelBuilder.Entity<BookReview>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedOn);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.ReviewComments).HasMaxLength(1000);
                entity.Property(e => e.ReviewedBy).HasMaxLength(50);
            });
        }
    }
}