using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Error
{
    public class Error(string Code , string Messsage)
    {
        public static readonly Error None = new Error(string.Empty, string.Empty);  

        public static readonly Error NullValue = new ("Error.NullValue", "Value cannot be null.");
    }
}
