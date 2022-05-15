using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteCategory
    {
        public PharmaviteCategory()
        {
            PharmaviteProducts = new HashSet<PharmaviteProduct>();
        }

        public decimal CategoryId { get; set; }
        public string CategoryImg { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<PharmaviteProduct> PharmaviteProducts { get; set; }
    }
}
