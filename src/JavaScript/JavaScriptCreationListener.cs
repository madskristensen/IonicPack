﻿using System;
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

        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            if (!_hasRun)
            {
                Task.Run(() =>
                {
                    MoveFile();
                });

            }
            _hasRun = true;
        }

        static void MoveFile()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(assembly);
            string source = Path.Combine(folder, "JavaScript\\ionic.bundle.intellisense.js");

            string destination = Path.Combine(_path, Path.GetFileName(source));
            File.Copy(source, destination, true);
        }
    }
}
