using BuildingBlocks.Common.Exceptions;
using BuildingBlocks.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
     public class ValidationException : ApplicationExceptionBase
    {
        public IReadOnlyCollection<ValidationError> Errors  { get; }

        public ValidationException(IReadOnlyCollection<ValidationError> errors) : base("validation_error", "One or more validation errors occurred.")
        {
            Errors = errors;
        }
    }
}
