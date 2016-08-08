using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;

namespace IonicPack.JavaScript
{
    [Export(typeof(IVsTextViewCreationListener))]
    [ContentType("JavaScript")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    class JavaScriptCreationListener : IVsTextViewCreationListener
    {
        static readonly string _path = Environment.ExpandEnvironmentVariables(@"%localappdata%\Microsoft\FSPCache\");
        static bool _hasRun;

        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            if (!_hasRun)
            {
                _hasRun = true;

                Task.Run(() =>
                {
                    MoveFile();
                });
            }
        }

        static void MoveFile()
        {
            try
            {
                string assembly = Assembly.GetExecutingAssembly().Location;
                string folder = Path.GetDirectoryName(assembly);
                var source = new FileInfo(Path.Combine(folder, "JavaScript\\Completion\\ionic.bundle.intellisense.js"));
                var dest = new FileInfo(Path.Combine(_path, source.Name));

                if (!dest.Exists || source.LastWriteTime > dest.LastWriteTime)
                {
                    Microsoft.VisualStudio.Shell.PackageUtilities.EnsureOutputPath(_path);

                    source.CopyTo(dest.FullName, true);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }
    }
}
