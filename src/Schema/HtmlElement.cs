using System.Collections.Generic;

namespace IonicPack.Schema
{
    class HtmlElement : IHtmlItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public IEnumerable<HtmlAttribute> Attributes { get; set; }
    }
}
