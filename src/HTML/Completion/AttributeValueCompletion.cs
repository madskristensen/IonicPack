using System.Collections.Generic;
using System.Linq;
using Microsoft.Html.Editor.Completion;
using Microsoft.Html.Editor.Completion.Def;
using Microsoft.VisualStudio.Utilities;

namespace IonicPack.HTML
{
    [HtmlCompletionProvider(CompletionTypes.Values, "*", "*")]
    [ContentType("htmlx")]
    class AttributeValueCompletion : CompletionBase
    {
        public override string CompletionType
        {
            get { return CompletionTypes.Values; }
        }

        public override IList<HtmlCompletion> GetEntries(HtmlCompletionContext context)
        {
            var list = new List<HtmlCompletion>();
            string tagName = context.Element.Name.ToLowerInvariant();
            string attrName = context.Attribute.Name.ToLowerInvariant();


            var all = HtmlCache.Elements.Single(e => e.Name == "*").Attributes.ToList();

            HtmlElement element = HtmlCache.Elements.SingleOrDefault(e => e.Name == tagName);

            if (element != null && element.Attributes != null)
                all.AddRange(element.Attributes);

            var attributes = new List<HtmlAttribute>();

            foreach (var attribute in all)
            {
                if (!string.IsNullOrEmpty(attribute.Require))
                {
                    if (context.Element.GetAttribute(attribute.Require) != null)
                        attributes.Add(attribute);
                }
                else
                {
                    attributes.Add(attribute);
                }
            }

            var attr = attributes.SingleOrDefault(a => a.Name == attrName);

            return AddAttributeValues(context, attr?.Values);
        }
    }
}
