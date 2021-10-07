using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonPhoneRequest
    {
        public PersonPhoneKeysRequest PersonPhoneKeys { get; set; }

        public int BusinessEntityID { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }
    }
}
