using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<PersonPhone> AddAsync(PersonPhone personPhone)
        {
            return await _personPhoneRepository.AddAsync(personPhone);
        }

        public async Task<PersonPhone> UpdateAsync(PersonPhone personPhone)
        {
            return await _personPhoneRepository.UpdateAsync(personPhone);
        }

        public async Task<PersonPhone> DeleteAsync(int businessEntityId, string phoneNumber, int phoneNumberTypeId)
        {
            return await _personPhoneRepository.DeleteAsync(businessEntityId, phoneNumber, phoneNumberTypeId);
        }

        public async Task<PersonPhone> FindAsync(PersonPhone personPhone)
        {
            return await _personPhoneRepository.FindAsync(personPhone);
        }
    }
}
