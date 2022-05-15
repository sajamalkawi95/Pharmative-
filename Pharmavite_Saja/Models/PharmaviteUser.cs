using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteUser
    {
        public PharmaviteUser()
        {
            PharmativeUserContacts = new HashSet<PharmativeUserContact>();
            PharmaviteCards = new HashSet<PharmaviteCard>();
            PharmaviteOrders = new HashSet<PharmaviteOrder>();
            PharmaviteWebsites = new HashSet<PharmaviteWebsite>();
        }

        public decimal UserId { get; set; }
        public decimal? RoleIdfk { get; set; }
        public string UserName { get; set; }
        public string Img { get; set; }
        [NotMapped]

        public virtual IFormFile ImageFile { get; set; }

        public decimal? PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? Bod { get; set; }
        public string Address { get; set; }
        public decimal? RoleId { get; set; }
        public string Password { get; set; }

        public virtual PharmaviteRole RoleIdfkNavigation { get; set; }
        public virtual ICollection<PharmativeUserContact> PharmativeUserContacts { get; set; }
        public virtual ICollection<PharmaviteCard> PharmaviteCards { get; set; }
        public virtual ICollection<PharmaviteOrder> PharmaviteOrders { get; set; }
        public virtual ICollection<PharmaviteWebsite> PharmaviteWebsites { get; set; }
    }
}
