using System;

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
