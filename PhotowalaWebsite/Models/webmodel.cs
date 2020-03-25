namespace PhotowalaWebsite.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class webmodel : DbContext
    {
        public webmodel()
            : base("name=webmodel")
        {
        }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Catagory> Catagories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<Catagory>()
              .HasMany(e => e.Blogs)
              .WithOptional(e => e.Catagorys)
              .HasForeignKey(e => e.catgoryID)
              .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<PhotowalaWebsite.Models.Work> Works { get; set; }

        public System.Data.Entity.DbSet<PhotowalaWebsite.Models.Review> Reviews { get; set; }
    }
}
