using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodies.Shop.Database.Entities
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; }
        public string? UserTypeCode { get; set; }
        public string? UserTypeDescription { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
