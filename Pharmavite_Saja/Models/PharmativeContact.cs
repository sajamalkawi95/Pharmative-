using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmativeContact
    {
        public decimal ContactId { get; set; }
        public decimal? WebsiteIdfk { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FbAccaunt { get; set; }
        public string LiAccaunt { get; set; }
        public string InstaAccaunt { get; set; }

        public virtual PharmaviteWebsite WebsiteIdfkNavigation { get; set; }
    }
}
