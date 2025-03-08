using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using ApiProjeKampi.WebApi.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext apiContext; 



        public ProductController(IValidator<Product> validator, ApiContext apiContext)
        {
            _validator = validator;
            this.apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult GetList() 
        {
            var value =apiContext.Products.ToList();
            return Ok(value);  //Listeleme aynı
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product) 
        {
            var valudationResult = _validator.Validate(product);
            if (!valudationResult.IsValid) 
            {
                return BadRequest(valudationResult.Errors.Select(x=>x.ErrorMessage));
            }
            else
            {
                apiContext.Products.Add(product);
                apiContext.SaveChanges();

                return Ok(new { message = "Ürün ekleme başarılı", data = product });
            }
        }
        [HttpDelete]
        public IActionResult deleteProduct(int id) 
        {
            var RemoveValue = apiContext.Products.Find(id);
            if (RemoveValue != null) 
            {
                apiContext.Products.Remove(RemoveValue);
                apiContext.SaveChanges();
                return Ok("Silme başarılo");
            }
            else
            {
                return Ok("Bulunamadı");
            }
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id) 
        {
            var value=apiContext.Products.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product) 
        {
            var valudationResult = _validator.Validate(product);
            if (!valudationResult.IsValid)
            {
                return BadRequest(valudationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                apiContext.Products.Update(product);
                apiContext.SaveChanges();

                return Ok(new { message = "güncelleme başarılı", data = product });
            }
        }
    }
}
