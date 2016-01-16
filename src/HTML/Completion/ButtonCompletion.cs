using System.Collections.Generic;
using Microsoft.Html.Editor.Completion.Def;
using Microsoft.VisualStudio.Utilities;

namespace IonicPack.Completion
{
    [HtmlCompletionProvider(CompletionTypes.Attributes, "*")]
    [ContentType("htmlx")]
    class buttonCompletion : AttributeCompletionBase
    {
        protected override IEnumerable<string> GetAttributes()
        {
            yield return "on-double-tab";
            yield return "on-drag";
            yield return "on-drag-down";
            yield return "on-drag-left";
            yield return "on-drag-right";
            yield return "on-drag-up";
            yield return "on-hold";
            yield return "on-release";
            yield return "on-swipe";
            yield return "on-swipe-up";
            yield return "on-swipte-down";
            yield return "on-swipte-left";
            yield return "on-swipte-right";
            yield return "on-tab";
            yield return "on-touch";
        }
    }
}
