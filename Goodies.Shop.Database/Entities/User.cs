using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodies.Shop.Database.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public int? UserTypeID { get; set; }
        public int? UserAddressID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
       // [PasswordPropertyText]
        public string? Password { get; set; }
        public string? Cellphone { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateLastOrdered { get; set; }
    }
}
