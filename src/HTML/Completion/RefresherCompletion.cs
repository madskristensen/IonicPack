using System.Collections.Generic;
using Microsoft.Html.Editor.Completion.Def;
using Microsoft.VisualStudio.Utilities;

namespace IonicPack.Completion
{
    [HtmlCompletionProvider(CompletionTypes.Attributes, "ion-refresher")]
    [ContentType("htmlx")]
    class RefresherCompletion : AttributeCompletionBase
    {
        protected override IEnumerable<string> GetAttributes()
        {
            yield return "on-refresh";
            yield return "on-pulling";
            yield return "pulling-text";
            yield return "pulling-icon";
            yield return "spinner";
            yield return "refreshing-icon";
            yield return "disable-pulling-rotation";
        }
    }
}
