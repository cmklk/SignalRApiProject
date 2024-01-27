using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Services;
using SignalR.DtoLayer.Dto.ContactDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactServices _contactServices;
        private readonly IMapper mapper;

        public ContactController(IContactServices contactServices, IMapper mapper)
        {
            _contactServices = contactServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetContactList()
        {
            var list = mapper.Map<List<ResultContactDto>>(_contactServices.GetAll());
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var find = _contactServices.GetById(id);
            return Ok(find);
        }


        [HttpPost]
        public IActionResult AddContact(createContactDto createContactDto)
        {
            _contactServices.Add(new Contact()
            {
                Email = createContactDto.Email,
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Phone = createContactDto.Phone,
            });

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactServices.Update(new Contact()
            {
                ContactID = updateContactDto.ContactID,
                Email = updateContactDto.Email,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                Phone = updateContactDto.Phone,
            });

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var find = _contactServices.GetById(id);
            _contactServices.Remove(find);
            return Ok();
        }
    }
}
