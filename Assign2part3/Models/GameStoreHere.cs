namespace Assign2part3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GameStoreHere : DbContext
    {
        public GameStoreHere()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(e => e.Descriptions)
                .WithRequired(e => e.Game1)
                .HasForeignKey(e => e.Game)
                .WillCascadeOnDelete(false);
        }
    }
}
