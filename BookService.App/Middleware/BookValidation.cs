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
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Invalid Book ID. It must be a positive number.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Invalid Book Price. It must be a positive value.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The Book Name cannot be blank.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Invalid Book Name. It must only contain alphabets.");
            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("The Category Name cannot be blank.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Invalid Book Category. It must only contain alphabets.");
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("The Author Name cannot be blank.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Invalid Author Name. It must only contain alphabets.");
        }
    }
}
