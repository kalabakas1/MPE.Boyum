using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MPE.Boyum.Interfaces;
using MPE.Boyum.Logic;
using MPE.Boyum.Logic.Builders;
using MPE.Boyum.Logic.Builders.Converters;
using MPE.Boyum.Logic.Readers;
using MPE.Boyum.Models;
using MPE.Boyum.Models.Data;
using SimpleInjector;

namespace MPE.Boyum
{
    public class Setup
    {
        private static Container _container;
        private static object _lock = new object();

        public static Container Container
        {
            get
            {
                lock (_lock)
                {
                    if (_container == null)
                    {
                        _container = Configure();
                    }
                    return _container;
                }
            }
        }

        private static Container Configure()
        {
            var container = new Container();

            container.Register<ILogger, Logger>();

            container.Register<IFileObjectReader, XmlFileObjectReader>();

            container.Register<IConverter<XmlWebOrder, WebOrder>, WebOrderXmlConverter>();
            container.Register<IConverter<XmlWebOrderItem, WebOrderItem>, WebOrderItemXmlConverter>();


            container.Verify();

            return container;
        }
    }
}
