using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneResponse> AddAsync(PersonPhoneRequest personPhone);
        Task<PersonPhoneResponse> UpdateAsync(PersonPhoneRequest personPhone);
        Task<int> DeleteAsync(int businessEntityId, string phoneNumber, int phoneNumberTypeId);
    }
}
