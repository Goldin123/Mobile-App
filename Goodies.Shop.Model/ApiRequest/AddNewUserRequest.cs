using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodies.Shop.Model.ApiRequest
{
    public class AddNewUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? Cellphone { get; set; }

        public AddNewUserRequest(string? firstName, string? lastName, string? emailAddress, string? password, string? cellphone)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            if (emailAddress == null) throw new ArgumentNullException(nameof(emailAddress));
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (cellphone == null) throw new ArgumentNullException(nameof(cellphone));

            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Password = password;
            Cellphone = cellphone;
        }
    }
}
