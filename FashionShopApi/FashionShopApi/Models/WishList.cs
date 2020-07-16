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
        public int Id { get; set; }

        public int? ProductID { get; set; }

        public int? AccountID { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }

        public bool? Status { get; set; }

        public virtual Account Account { get; set; }

        public virtual Product Product { get; set; }
    }
}
