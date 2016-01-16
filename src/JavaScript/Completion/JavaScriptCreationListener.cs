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
        static string _path = Environment.ExpandEnvironmentVariables(@"%localappdata%\Microsoft\FSPCache\");
        static bool _hasRun;

        public async void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            if (!_hasRun)
            {
                _hasRun = true;
                await MoveFile();
            }
        }

        static async Task MoveFile()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(assembly);
            string sourcePath = Path.Combine(folder, "JavaScript\\Completion\\ionic.bundle.intellisense.js");
            string destinationPath = Path.Combine(_path, Path.GetFileName(sourcePath));

            using (Stream source = File.Open(sourcePath, FileMode.Open))
            {
                using (Stream destination = File.Create(destinationPath))
                {
                    await source.CopyToAsync(destination);
                }
            }
        }
    }
}
