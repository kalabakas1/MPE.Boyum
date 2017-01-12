using System;
using System.Collections.Generic;

namespace MPE.Boyum.Models
{
    public class WebOrder
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public List<WebOrderItem> Items { get; set; }
    }
}
