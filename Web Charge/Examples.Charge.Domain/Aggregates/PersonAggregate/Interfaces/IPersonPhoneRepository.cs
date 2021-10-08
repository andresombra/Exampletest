using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonPhone>> FindAllAsync();
        Task<PersonPhone> FindAsync(PersonPhone personPhone);
        Task<PersonPhone> AddAsync(PersonPhone personPhone);
        Task<PersonPhone> UpdateAsync(PersonPhone personPhone);
        Task<PersonPhone> DeleteAsync(int businessEntityId, string phoneNumber, int phoneNumberTypeId);
    }
}
