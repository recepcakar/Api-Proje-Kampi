using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList() 
        {
            var value=_context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(value));   //valuede bütün değerler var el ile tektek c.id=value.id vs yapıyorudk
            //şimdi automapper bizim için resultmessagedto tipinde liste döndürüyor valuedeki değerlerle

        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto message) 
        {
           var value= _mapper.Map<Message>(message);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("ekleme başarılı" );
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id) 
        {
          var value=  _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("silme başarılı");

        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
     
            var value = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value));

        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value=_mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("güncelleme başarılı");
        }
       
    }
}
