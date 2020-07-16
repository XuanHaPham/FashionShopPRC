namespace FashionShopAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DeliveryChannel> DeliveryChannels { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPic> ProductPics { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryChannel>()
                .HasMany(e => e.Bills)
                .WithOptional(e => e.DeliveryChannel)
                .HasForeignKey(e => e.DeliverID);

            modelBuilder.Entity<Product>()
                .Property(e => e.Size)
                .IsUnicode(false);
        }
    }
}
