using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPE.Boyum.Interfaces;
using MPE.Boyum.Models;
using MPE.Boyum.Models.Data;
using Newtonsoft.Json;

namespace MPE.Boyum.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileReader = Setup.Container.GetInstance<IFileObjectReader>();

            var filePath = @".\Data\WebOrder_42.xml";

            var obj = fileReader.Read<XmlWebOrder>(filePath);

            if (obj.HasValue)
            {
                Console.WriteLine(JsonConvert.SerializeObject(obj.Value, Formatting.Indented));
                var converter = Setup.Container.GetInstance<IConverter<XmlWebOrder, WebOrder>>();

                var bobj = converter.Build(obj.Value);
            }
            else
            {
                Console.WriteLine("Read failed...");
            }

            Console.ReadLine();
        }
    }
}
