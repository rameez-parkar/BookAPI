using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.App.Data;
using FluentValidation;

namespace BookService.App.Middleware
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id can't be negative or 0.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price can't be negative or 0.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("The Book Name cannot be blank.");
            RuleFor(x => x.Category).NotEmpty().Matches("/^[a-zA-Z ]*$/").WithMessage("The Category Name cannot be blank.");
            RuleFor(x => x.Author).NotEmpty().Matches("/^[a-zA-Z ]*$/").WithMessage("The Author Name cannot be blank.");
        }
    }
}
