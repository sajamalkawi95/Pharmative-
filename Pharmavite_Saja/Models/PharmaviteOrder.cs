using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteOrder
    {
        public PharmaviteOrder()
        {
            FinReports = new HashSet<FinReport>();
            PharmaviteProductCarts = new HashSet<PharmaviteProductCart>();
        }
        public PharmaviteOrder(int UserIdfk, int ProductQty, string ProductStatus, DateTime OrderStartDate)
        {
            this.UserIdfk = UserIdfk;
            this.ProductQty = ProductQty;
            this.ProductStatus = ProductStatus;
            this.OrderStartDate = OrderStartDate;

        }
        public PharmaviteOrder(int UserIdfk, int ProductQty, string ProductStatus)
        {
            this.UserIdfk = UserIdfk;
            this.ProductQty = ProductQty;
            this.ProductStatus = ProductStatus;
 
        }

        public decimal OrderId { get; set; }
        public decimal? UserIdfk { get; set; }
        public decimal? ProductQty { get; set; }
        public string ProductStatus { get; set; }
        public DateTime? OrderStartDate { get; set; }
        public DateTime? DeleverdDate { get; set; }

        public virtual PharmaviteUser UserIdfkNavigation { get; set; }
        public virtual ICollection<FinReport> FinReports { get; set; }
        public virtual ICollection<PharmaviteProductCart> PharmaviteProductCarts { get; set; }
    }
}
