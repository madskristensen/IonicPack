using System.Collections.Generic;
using Microsoft.Html.Editor.Completion.Def;
using Microsoft.VisualStudio.Utilities;

namespace IonicPack.Completion
{
    [HtmlCompletionProvider(CompletionTypes.Attributes, "ion-content")]
    [ContentType("htmlx")]
    class ContentCompletion : AttributeCompletionBase
    {
        protected override IEnumerable<string> GetAttributes()
        {
            yield return "delegate-handle";
            yield return "direction";
            yield return "locking";
            yield return "padding";
            yield return "scroll";
            yield return "overflow-scroll";
            yield return "scrollbar-x";
            yield return "scrollbar-y";
            yield return "start-x";
            yield return "start-y";
            yield return "on-scroll";
            yield return "on-scroll-completion";
            yield return "has-bouncing";
            yield return "scroll-event-interval";
        }
    }
}
