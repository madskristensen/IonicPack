using System.Collections.Generic;
using Microsoft.Html.Editor.Completion.Def;
using Microsoft.VisualStudio.Utilities;

namespace IonicPack.Completion
{
    [HtmlCompletionProvider(CompletionTypes.Attributes, "ion-list")]
    [ContentType("htmlx")]
    class ListCompletion : AttributeCompletionBase
    {
        protected override IEnumerable<string> GetAttributes()
        {
            yield return "delegate-handle";
            yield return "type";
            yield return "show-delete";
            yield return "show-reorder";
            yield return "can-swipe";
        }
    }
}
