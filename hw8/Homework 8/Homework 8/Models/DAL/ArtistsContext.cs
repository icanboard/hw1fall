namespace Homework_8.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArtistsContext : DbContext
    {
        public ArtistsContext()
            : base("name=ArtistsContext")
        {
        }

        public virtual DbSet<ARTIST> ARTISTS { get; set; }
        public virtual DbSet<ARTWORK> ARTWORKS { get; set; }
        public virtual DbSet<CLASSIFICATION> CLASSIFICATIONS { get; set; }
        public virtual DbSet<GENRE> GENRES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ARTWORK>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<CLASSIFICATION>()
                .Property(e => e.Genre)
                .IsUnicode(false);

            modelBuilder.Entity<GENRE>()
                .Property(e => e.Genre1)
                .IsUnicode(false);

            modelBuilder.Entity<GENRE>()
                .HasMany(e => e.CLASSIFICATIONS)
                .WithRequired(e => e.GENRE1)
                .HasForeignKey(e => e.Genre);
        }
    }
}
