using BookStore.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Service
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                        .HasMany(x => x.Books)
                        .WithOne(x => x.Author)
                        .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<BookCategory>()
                        .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
                        .HasOne(bc => bc.Book)
                        .WithMany(b => b.Categories)
                        .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookCategory>()
                        .HasOne(bc => bc.Category)
                        .WithMany(b => b.Books)
                        .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Category>()
                        .HasMany(x => x.SubCategories)
                        .WithOne(x => x.TopCategory)
                        .HasForeignKey(x => x.TopCategoryId);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
