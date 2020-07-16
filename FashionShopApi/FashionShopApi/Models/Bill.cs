namespace FashionShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }

        public int? AccountID { get; set; }

        public int? DeliverID { get; set; }

        public int? PromotionID { get; set; }

        public double? SubTotal { get; set; }

        public double? ShippingFee { get; set; }

        public double? Total { get; set; }

        public string Code { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }

        public bool? Status { get; set; }

        public string NoteForDeliver { get; set; }

        public virtual Account Account { get; set; }

        public virtual DeliveryChannel DeliveryChannel { get; set; }

        public virtual Promotion Promotion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
