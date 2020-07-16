namespace FashionShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPic")]
    public partial class ProductPic
    {
        public int Id { get; set; }

        public string ImageURL { get; set; }

        public int? ProductID { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }

        public virtual Product Product { get; set; }
    }
}
