using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _personFacade;

        public PersonPhoneController(IPersonPhoneFacade personFacade)
        {
            _personFacade = personFacade;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonPhoneRequest phoneRequest)
        {
            var resp = await _personFacade.AddAsync(phoneRequest);
            return Response(resp);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PersonPhoneRequest phoneRequest)
        {
            var resp = await _personFacade.UpdateAsync(phoneRequest);
            return Response(resp);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PersonPhoneRequest phoneRequest)
        {
            var resp = await _personFacade.DeleteAsync(phoneRequest.PersonPhoneKeys.BusinessEntityID, 
                phoneRequest.PersonPhoneKeys.PhoneNumber, 
                phoneRequest.PersonPhoneKeys.PhoneNumberTypeID);

            return Response(resp);
        }
    }
}
