using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace IonicPack.HTML
{
    class HtmlCache
    {
        public static List<HtmlElement> Elements { get; } = ReadConfig();

        static List<HtmlElement> ReadConfig()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(assembly);
            string source = Path.Combine(folder, "HTML\\Schema\\schema.json");

            string content = File.ReadAllText(source);
            return JsonConvert.DeserializeObject<List<HtmlElement>>(content);
        }
    }
}
