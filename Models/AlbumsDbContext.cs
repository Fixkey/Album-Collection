namespace Album_Collection.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AlbumsDbContext : DbContext
    {
        public AlbumsDbContext()
            : base("name=AlbumsDbContext")
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
