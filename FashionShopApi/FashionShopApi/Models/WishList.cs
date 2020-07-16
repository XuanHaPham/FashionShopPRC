namespace FashionShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WishList")]
    public partial class WishList
    {
        public Guid Id { get; set; }

        public Guid? ProductID { get; set; }

        public Guid? AccountID { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }

        public bool? Status { get; set; }

        public virtual Account Account { get; set; }

        public virtual Product Product { get; set; }
    }
}
