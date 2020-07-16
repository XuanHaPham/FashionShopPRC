namespace FashionShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillDetail")]
    public partial class BillDetail
    {
        public int Id { get; set; }

        public int? BillID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public bool? Status { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Product Product { get; set; }
    }
}
