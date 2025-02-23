using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.FutureDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ApiContext _context;
        public FeaturesController(IMapper mapper,ApiContext Context)
        {
            _mapper = mapper;
            _context = Context;

        }

        [HttpGet]
        public IActionResult FeatureList() 
        {
            var values=_context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
         
        }
        [HttpPost]
         public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("ekleme başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value=_context.Features.Find( id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı "  );
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var values= _context.Features.Find( id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(values));
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        { 
            var value=_mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok(value);
            
        }
    }
}
