﻿using DBEntities;
using Microsoft.EntityFrameworkCore;


namespace DBContext
{
    public class ReviewCommentContext: DbContext
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
            optionsBuilder.UseCosmos(
                       "https://localhost:8081",
                       "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                       databaseName: "OrdersDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<BookReview>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
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
