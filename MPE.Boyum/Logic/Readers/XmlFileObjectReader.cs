using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Functional.Maybe;
using MPE.Boyum.Enums;
using MPE.Boyum.Interfaces;
using MPE.Boyum.Logic.Exceptions;

namespace MPE.Boyum.Logic.Readers
{
    internal class XmlFileObjectReader : IFileObjectReader
    {
        private ILogger _logger;
        public XmlFileObjectReader(
            ILogger logger)
        {
            _logger = logger;
        }

        public virtual Maybe<T> Read<T>(string filePath)
        {
            var returnObject = default(T);

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    returnObject = (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevels.Debug, ex);
                throw new ParseException($"Not able to parse XML document to {typeof(T).Name}", ex);
            }

            return returnObject.ToMaybe();
        }
    }
}
