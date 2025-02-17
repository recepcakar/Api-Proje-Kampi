using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }
        [HttpPost]
      public IActionResult CreateCategor(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id) 
        {
            try
            {
                var values = _context.Categories.Find(id);
                _context.Categories.Remove(values);
                _context.SaveChanges();
                return Ok("categor silme işlemi başarılı");
            }

            catch { return Ok("başarısız"); }
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id) 
        {
            var values = _context.Categories.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult PutCategory(Category category) 
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("güncelleme tamam");
        }

    }
}
