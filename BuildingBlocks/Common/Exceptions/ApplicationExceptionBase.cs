using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ApplicationExceptionBase : Exception , IApplicationException
    {
        public string Code { get; }
        public ApplicationExceptionBase(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}
