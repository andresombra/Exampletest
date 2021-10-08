using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneResponse> AddAsync(PersonPhoneRequest personPhone)
        {
            var mapPersonPhone = new PersonPhone() { BusinessEntityID = personPhone.BusinessEntityID, PhoneNumber = personPhone.PhoneNumber, PhoneNumberTypeID = personPhone.PhoneNumberTypeID };
            var result = await _personPhoneService.AddAsync(mapPersonPhone);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new PersonPhoneDto(){ BusinessEntityID = result.BusinessEntityID, PhoneNumber = result.PhoneNumber, PhoneNumberTypeID = result.PhoneNumberTypeID };

            return response;
        }
        public async Task<PersonPhoneResponse> UpdateAsync(PersonPhoneRequest personPhone)
        {
            var response = new PersonPhoneResponse();
            var keysPersonPhone = new PersonPhone()
            {
                BusinessEntityID = personPhone.PersonPhoneKeys.BusinessEntityID,
                PhoneNumber = personPhone.PersonPhoneKeys.PhoneNumber,
                PhoneNumberTypeID = personPhone.PersonPhoneKeys.PhoneNumberTypeID
            };
            var _personPhone = await _personPhoneService.FindAsync(keysPersonPhone);
            if(_personPhone != null)
            {
                var update_personPhone = new PersonPhone()
                {
                    BusinessEntityID = personPhone.BusinessEntityID,
                    PhoneNumber = personPhone.PhoneNumber,
                    PhoneNumberTypeID = personPhone.PhoneNumberTypeID
                };
                await _personPhoneService.DeleteAsync(personPhone.PersonPhoneKeys.BusinessEntityID, personPhone.PersonPhoneKeys.PhoneNumber, personPhone.PersonPhoneKeys.PhoneNumberTypeID); 
               var result = await _personPhoneService.AddAsync(_mapper.Map<PersonPhone>(update_personPhone));
               
               response.PersonPhoneObjects = new PersonPhoneDto() {  
                   BusinessEntityID = result.BusinessEntityID, 
                   PhoneNumber = result.PhoneNumber,
                   PhoneNumberTypeID = result.PhoneNumberTypeID
               };
            }

            return response;
        }
        public async Task<PersonPhoneResponse> DeleteAsync(int businessEntityId, string phoneNumber, int phoneNumberTypeId)
        {
            var response = new PersonPhoneResponse();
            var objPersonPhone = await _personPhoneService.DeleteAsync(businessEntityId, phoneNumber, phoneNumberTypeId);
            if (objPersonPhone != null)
            {
                response.PersonPhoneObjects = new PersonPhoneDto()
                {
                    BusinessEntityID = objPersonPhone.BusinessEntityID,
                    PhoneNumber = objPersonPhone.PhoneNumber,
                    PhoneNumberTypeID = objPersonPhone.PhoneNumberTypeID
                };
                
                return response;
            }

            return null;
        }

    }
}
