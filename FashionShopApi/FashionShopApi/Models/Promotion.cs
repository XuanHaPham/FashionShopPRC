namespace FashionShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Promotion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promotion()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public int? Creater { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
