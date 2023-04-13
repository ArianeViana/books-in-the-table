
using books_in_the_table.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace books_in_the_table.Data
{
    public class AppDbContext : DbContext
    {
        //necessário para os testes unitários, na hora de mockar o banco 
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<AuthorPublisher> AuthorPublishers { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            //relacionamento one-to-many
            Builder.Entity<Book>()
            .HasOne(book => book.Author)
            .WithMany(author => author.Books)
            .HasForeignKey(book => book.AuthorId);

            Builder.Entity<Book>()
           .HasOne(book => book.Publisher)
           .WithMany(publisher => publisher.Books)
           .HasForeignKey(book => book.PublisherId);

            //relacionamento many-to-many
            Builder.Entity<AuthorPublisher>()
            .HasKey(ap => new { ap.Id });
            // .HasKey(ap => new { ap.AuthorId, ap.PublisherId });
            //salva o id da tabela nulo uma vez que o id não é mais a chave primária
            Builder.Entity<AuthorPublisher>()
            .HasOne(ap => ap.Author)
            .WithMany(author => author.AuthorPublishers)
            .HasForeignKey(ap => ap.AuthorId);
            Builder.Entity<AuthorPublisher>()
            .HasOne(ap => ap.Publisher)
            .WithMany(publisher => publisher.AuthorPublishers)
            .HasForeignKey(ap => ap.PublisherId);

        }
    }
}