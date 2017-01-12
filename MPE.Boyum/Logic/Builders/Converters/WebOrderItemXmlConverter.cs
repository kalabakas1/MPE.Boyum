using MPE.Boyum.Interfaces;
using MPE.Boyum.Logic.Builders.MPE.SS.Logic.Builders;
using MPE.Boyum.Models;
using MPE.Boyum.Models.Data;

namespace MPE.Boyum.Logic.Builders.Converters
{
    internal class WebOrderItemXmlConverter : IConverter<XmlWebOrderItem, WebOrderItem>
    {
        private Builder<WebOrderItem> _builder;
        
        public WebOrderItemXmlConverter()
        {
            _builder = new Builder<WebOrderItem>();
        }

        public WebOrderItem Build(XmlWebOrderItem input)
        {
            return _builder
                .Where(x => x.Id = input.Id)
                .Where(x => x.Description = input.Description)
                .Where(x => x.Price = input.Price)
                .Where(x => x.Quantity = input.Quantity)
                .Build();
        }
    }
}
