using System.Linq;
using MPE.Boyum.Interfaces;
using MPE.Boyum.Logic.Builders.MPE.SS.Logic.Builders;
using MPE.Boyum.Models;
using MPE.Boyum.Models.Data;

namespace MPE.Boyum.Logic.Builders.Converters
{
    internal class WebOrderXmlConverter : IConverter<XmlWebOrder, WebOrder>
    {
        private Builder<WebOrder> _builder;
        private IConverter<XmlWebOrderItem, WebOrderItem> _itemConverter;
        
        public WebOrderXmlConverter(
            IConverter<XmlWebOrderItem, WebOrderItem> itemConverter)
        {
            _builder = new Builder<WebOrder>();
            _itemConverter = itemConverter;
        }

        public WebOrder Build(XmlWebOrder input)
        {
            return _builder
                .Where(x => x.Id = input.Id)
                .Where(x => x.Date = input.Date)
                .Where(x => x.Customer = input.Customer)
                .Where(x => x.Items = input.Items.Select(item => _itemConverter.Build(item)).ToList())
                .Build();
        }
    }
}
