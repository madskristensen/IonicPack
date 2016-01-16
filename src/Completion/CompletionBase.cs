using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IonicPack.Schema;
using Microsoft.Html.Editor.Completion;
using Microsoft.Html.Editor.Completion.Def;
using Microsoft.VisualStudio.Language.Intellisense;

namespace IonicPack.Completion
{
    abstract class CompletionBase : IHtmlCompletionListProvider
    {
        ImageSource _icon = GetIcon();

        public abstract string CompletionType { get; }

        public abstract IList<HtmlCompletion> GetEntries(HtmlCompletionContext context);

        static ImageSource GetIcon()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(assembly);
            string path = Path.Combine(folder, "snippets\\html\\ionic pack\\_default.png");

            Uri uri = new Uri(path);
            return BitmapFrame.Create(uri);
        }

        protected IList<HtmlCompletion> AddEntries(HtmlCompletionContext context, IEnumerable<IHtmlItem> items)
        {
            var list = new List<HtmlCompletion>();

            if (items == null)
                return list;

            foreach (IHtmlItem item in items)
            {
                var entry = new HtmlCompletion(item.Name, item.Name, item.Description, _icon, null, context.Session as ICompletionSession);
                list.Add(entry);
            }

            return list;
        }

        protected IList<HtmlCompletion> AddEntries(HtmlCompletionContext context, IEnumerable<string> items)
        {
            var list = new List<HtmlCompletion>();

            if (items == null)
                return list;

            foreach (string item in items)
            {
                var entry = new HtmlCompletion(item, item, "", _icon, null, context.Session as ICompletionSession);
                list.Add(entry);
            }

            return list;
        }
    }

}
