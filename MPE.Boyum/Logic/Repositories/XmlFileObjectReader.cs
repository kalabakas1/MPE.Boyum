using System;
using System.IO;
using System.Xml.Serialization;
using Functional.Maybe;
using MPE.Boyum.Enums;
using MPE.Boyum.Interfaces;
using MPE.Boyum.Logic.Exceptions;

namespace MPE.Boyum.Logic.Repositories
{
    internal class XmlFileObjectReader<T, TK> : IFileObjectReader<T, TK>
    {
        private ILogger _logger;
        private IConverter<T, TK> _converter;
        public XmlFileObjectReader(
            ILogger logger,
            IConverter<T, TK> converter)
        {
            _logger = logger;
            _converter = converter;
        }

        public virtual Maybe<TK> Read(string filePath)
        {
            var xmlObject = default(T).ToMaybe();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    xmlObject = ((T)serializer.Deserialize(reader)).ToMaybe();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevels.Debug, ex);
                throw new ParseException($"Not able to parse XML document to {typeof(T).Name}", ex);
            }

            if (xmlObject.HasValue)
                return _converter.Build(xmlObject.Value).ToMaybe();
            return default(TK).ToMaybe();
        }
    }
}
