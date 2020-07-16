namespace FashionShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
            ProductPics = new HashSet<ProductPic>();
            WishLists = new HashSet<WishList>();
        }

        public Guid Id { get; set; }

        public Guid? CategoryID { get; set; }

        public Guid? AccountID { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public double? Price { get; set; }

        public string Description { get; set; }

        public string Overview { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }

        public bool? Status { get; set; }

        public int? Quantity { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPic> ProductPics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
