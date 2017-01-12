using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPE.Boyum.Logic.Exceptions
{
    public class ParseException : Exception
    {
        internal ParseException(
            string message,
            Exception parent) 
            : base(message, parent)
        {
        }
    }
}
