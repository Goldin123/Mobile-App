using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodies.Shop.Database.Entities
{
    public class UserAddress
    {
        [Key]
        public int UserAddressID { get; set; }
        public string? PhysicalAddress1 { get; set; }
        public string? PhysicalAddress2 { get; set; }
        public string? PhysicalAddress3 { get; set; }
        public string? PhysicalAddress4 { get; set; }
        public string? PhysicalAddressCode { get; set; }
        public string? PostalAddress1 { get; set; }
        public string? PostalAddress2 { get; set; }
        public string? PostalAddress3 { get; set; }
        public string? PostalAddress4 { get; set; }
        public string? PostalAddressCode { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? Telephone { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
