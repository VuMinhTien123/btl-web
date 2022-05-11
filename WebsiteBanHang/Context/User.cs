namespace WebsiteBanHang.Context
{
    using System;
    using System.Collections.Generic;
    using WebsiteBanHang.Context;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using Xunit;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Orders = new HashSet<Order>();
        }
        public int idUser { get; set; }
        [Required(ErrorMessage = "Vui long nhap ho!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui long nhap ten!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Vui long nhap email!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email khong hop le!")]
        public string Email { get; set; }
        [StringLength(9, MinimumLength = 6)]
        public string Password { get; set; }
        public Nullable<bool> IsAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
