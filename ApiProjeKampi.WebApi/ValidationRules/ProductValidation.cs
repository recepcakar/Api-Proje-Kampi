using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidation :AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("ürün adını boş geçmeyin");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("ürün ismini en az 2 karakter yapınız");
            RuleFor(x => x.ProductName).MaximumLength(30).WithMessage("ürün adı en fazla 30 karakter yapınız ");
            RuleFor(x => x.Price).NotEmpty().WithMessage("ürün fiyatı boş olamaz");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("ürün fiyatı 0dan büyük olmalı");
            RuleFor(x => x.Price).LessThan(1800).WithMessage("ürün fiyatı 1800den küçük olmalı");
            RuleFor(x => x.Description).NotEmpty().WithMessage("ürün açıklaması boş geçilemez");
        }
    }
}
