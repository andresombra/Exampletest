using Abp.Events.Bus;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public int BusinessEntityID { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }

        public Person Person { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

        public ICollection<IEventData> DomainEvents { get; set; }  //=> throw new NotImplementedException();

        public PersonPhoneDto()
        {
            this.Person = new Person();
            this.PhoneNumberType = new PhoneNumberType();
        }
    }
}
