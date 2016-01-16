using System.Collections.Generic;
using Microsoft.Html.Editor.Completion.Def;
using Microsoft.VisualStudio.Utilities;

namespace IonicPack.Completion
{
    [HtmlCompletionProvider(CompletionTypes.Attributes, "ion-header-bar")]
    [ContentType("htmlx")]
    class HeaderBarCompletion : AttributeCompletionBase
    {
        protected override IEnumerable<string> GetAttributes()
        {
            yield return "align-title";
            yield return "no-tab-scroll";
        }
    }
}
