using System;

namespace MPE.Boyum.Extensions
{
    public static class ExceptionExtensions
    {
        public static string Flatten(this Exception ex)
        {
            if (ex == null)
                return string.Empty;

            string theString = ex.Message;

            if (ex.InnerException != null)
                return Environment.NewLine + "---- Inner Exception ----" + Environment.NewLine + Flatten(ex.InnerException);

            return theString;
        }
    }
}
