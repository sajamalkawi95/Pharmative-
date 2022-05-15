using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteWebsite
    {
        public PharmaviteWebsite()
        {
            PharmativeContacts = new HashSet<PharmativeContact>();
            PharmaviteAbouteUs = new HashSet<PharmaviteAbouteU>();
            PharmaviteReviws = new HashSet<PharmaviteReviw>();
            PharmaviteTestimonials = new HashSet<PharmaviteTestimonial>();
        }

        public decimal IdPharmavite { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteLogo1 { get; set; }
        public string WebsiteLogo2 { get; set; }
        public string WebsiteHeroimg { get; set; }
        public decimal? UserAdminfk { get; set; }
        public decimal? WebsiteWallet { get; set; }
        public string WebsiteHeroimg2 { get; set; }
        public string WebsiteHeroimg3 { get; set; }
        public string WebsiteDesc { get; set; }
        [NotMapped]

        public virtual IFormFile LogoFile { get; set; }
        [NotMapped]

        public virtual IFormFile LogoFile2 { get; set; }


        [NotMapped]

        public virtual IFormFile HeroFile { get; set; }

        [NotMapped]

        public virtual IFormFile HeroFile2 { get; set; }

        [NotMapped]

        public virtual IFormFile HeroFile3 { get; set; }
        public virtual PharmaviteUser UserAdminfkNavigation { get; set; }
        public virtual ICollection<PharmativeContact> PharmativeContacts { get; set; }
        public virtual ICollection<PharmaviteAbouteU> PharmaviteAbouteUs { get; set; }
        public virtual ICollection<PharmaviteReviw> PharmaviteReviws { get; set; }
        public virtual ICollection<PharmaviteTestimonial> PharmaviteTestimonials { get; set; }
    }
}
