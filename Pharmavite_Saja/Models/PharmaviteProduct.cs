using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteProduct
    {
        public PharmaviteProduct()
        {
            FinReports = new HashSet<FinReport>();
            PharmaviteProductCarts = new HashSet<PharmaviteProductCart>();
        }

        public decimal ProductId { get; set; }
        public decimal? CategoryIdfk { get; set; }
        public string ProductName { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? Price { get; set; }
        public string ProductDesc { get; set; }
        public decimal? ProductQuantity { get; set; }
        public string Productimg { get; set; }

        public virtual PharmaviteCategory CategoryIdfkNavigation { get; set; }
        public virtual ICollection<FinReport> FinReports { get; set; }
        public virtual ICollection<PharmaviteProductCart> PharmaviteProductCarts { get; set; }
    }
}
