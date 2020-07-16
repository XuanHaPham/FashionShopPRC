namespace FashionShopAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountRole")]
    public partial class AccountRole
    {
        public Guid Id { get; set; }

        public Guid? RoleID { get; set; }

        public Guid? AccountID { get; set; }

        public bool? Status { get; set; }

        public virtual Account Account { get; set; }

        public virtual Role Role { get; set; }
    }
}
