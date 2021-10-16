using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PersonPhone> FindAsync(PersonPhone personPhone)
        {
                object[] objParams = { personPhone.BusinessEntityID, personPhone.PhoneNumber, personPhone.PhoneNumberTypeID };
                if (await _context.PersonPhone.FindAsync(objParams) != null) return personPhone;

                return await _context.PersonPhone.FindAsync(personPhone);
        }
       
        public async Task<PersonPhone> AddAsync(PersonPhone personPhone)
        {
            try
            {
                object[] objParams = { personPhone.BusinessEntityID, personPhone.PhoneNumber, personPhone.PhoneNumberTypeID };
                if (await _context.PersonPhone.FindAsync(objParams)!=null) return personPhone;

                _context.PersonPhone.Add(personPhone);
                int ret = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var reterro = ex.Message;
                return null;
            }
            
            return personPhone;
        }

        public async Task<PersonPhone> UpdateAsync(PersonPhone personPhone)
        {
            object[] objParams = { personPhone.BusinessEntityID, personPhone.PhoneNumber, personPhone.PhoneNumberTypeID };

            if (await _context.PersonPhone.FindAsync(objParams) != null) return personPhone;

            _context.PersonPhone.Update(personPhone);
            await _context.SaveChangesAsync();

            return personPhone;
        }

        public async Task<PersonPhone> DeleteAsync(int businessEntityId, string phoneNumber, int phoneNumberTypeId)
        {
            //Exclusao usando as tres chaves primarias
            var objPersonPhone = new PersonPhone() {  BusinessEntityID = businessEntityId, PhoneNumber = phoneNumber, PhoneNumberTypeID = phoneNumberTypeId };
            object[] prms = { businessEntityId, phoneNumber, phoneNumberTypeId};

            if(await _context.PersonPhone.FindAsync(prms) != null)
            {
                _context.PersonPhone.Remove(objPersonPhone);
                await _context.SaveChangesAsync();
                return objPersonPhone;
            }

            return null;
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);
    }
}
