using System;
using System.IO;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation
{
    public class PhotoValidator : AbstractValidator<IFormFile>
    {
        public PhotoValidator()
        {
            RuleFor(p => p.Length).NotNull().WithMessage("Please attach file");
            RuleFor(p => p.Length).LessThanOrEqualTo(100).WithMessage("File size is larger than allowed");
            RuleFor(p => p.FileName).Must(HaveSupportedFileType).WithMessage("File must be photo!");
        }

        private bool HaveSupportedFileType(string contentType)
        {
            var supportedFileTypes = new[] { "jpg", "jpeg", "png" };
            var fileExtension = Path.GetExtension(contentType).ToLower();
            return supportedFileTypes.Contains(fileExtension);
        }
    }
}