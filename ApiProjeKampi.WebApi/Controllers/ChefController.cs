﻿using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ChefList() 
        { 
            var values=_context.Chefs.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateChef(Chef chef) 
        {    
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("eklendi");
        }
        [HttpPut]
        public IActionResult UpdateChef(Chef chef) 
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("güncelleme tamam");
        }
        [HttpDelete]

        public IActionResult DeleteChef(int id)
        {
            var values = _context.Chefs.Find(id);
            _context.Chefs.Remove(values);
            _context.SaveChanges();
            return Ok("silme başarılı");
        }
        [HttpGet("GetChef")]
        public IActionResult GetChef(int id) 
        {

            var values = _context.Chefs.Find(id);
            return Ok(values);
        }
    }
}
