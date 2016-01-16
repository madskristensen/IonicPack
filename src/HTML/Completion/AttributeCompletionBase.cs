using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Html.Editor.Completion;
using Microsoft.Html.Editor.Completion.Def;
using Microsoft.VisualStudio.Language.Intellisense;

namespace IonicPack.Completion
{
    abstract class AttributeCompletionBase : IHtmlCompletionListProvider
    {
        private ImageSource _icon = GetIcon();

        public string CompletionType
        {
            get { return CompletionTypes.Attributes; }
        }

        protected abstract IEnumerable<string> GetAttributes();

        public IList<HtmlCompletion> GetEntries(HtmlCompletionContext context)
        {
            List<HtmlCompletion> list = new List<HtmlCompletion>();

            foreach (string attr in GetAttributes())
            {
                var entry = new HtmlCompletion(attr, attr, attr, _icon, null, context.Session as ICompletionSession);
                list.Add(entry);
            }

            return list;
        }

        static ImageSource GetIcon()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(assembly);
            string path =  Path.Combine(folder, "snippets\\html\\ionic pack\\_default.png");

            Uri uri = new Uri(path);
            return BitmapFrame.Create(uri);
        }
    }
}
