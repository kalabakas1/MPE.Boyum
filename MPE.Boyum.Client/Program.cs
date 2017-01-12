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
            var fileReader = Setup.Container.GetInstance<IFileObjectReader<XmlWebOrder, WebOrder>>();

            var filePath = @".\Data\WebOrder_42.xml";

            var obj = fileReader.Read(filePath);

            if (obj.HasValue)
            {
                Console.WriteLine(JsonConvert.SerializeObject(obj.Value, Formatting.Indented));
            }
            else
            {
                Console.WriteLine("Read failed...");
            }

            Console.ReadLine();
        }
    }
}
