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
    public class FeatureController : ControllerBase
    {
        private readonly Mapper _mapper;

        private readonly ApiContext _context;
        public FeatureController(Mapper mapper,ApiContext apiContext)
        {
            _mapper = mapper;
            _context = apiContext;

        }

        [HttpGet]
        public IActionResult GetList() 
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
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values=_context.Features.Find( id);
            _context.Features.Remove(values);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı "  );
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var values= _context.Features.Find( id);
            return Ok(_mapper.Map<List<GetByIdFeatureDto>>(values));
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
