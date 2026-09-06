using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
     public interface IApplicationException
    {
        public string Code { get; }
    }
}
