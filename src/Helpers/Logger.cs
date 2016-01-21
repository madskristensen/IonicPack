using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Shell.Interop;

public static class Logger
{
    private static IVsOutputWindowPane pane;
    private static object _syncRoot = new object();
    private static IServiceProvider _provider;
    private static string _name;

    public static void Initialize(IServiceProvider provider, string name)
    {
        _provider = provider;
        _name = name;
    }

    public static void Log(string message)
    {
        if (string.IsNullOrEmpty(message))
            return;

        try
        {
            if (EnsurePane())
            {
                pane.OutputString(DateTime.Now.ToString() + ": " + message + Environment.NewLine);
            }
        }
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
        catch
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
        {
            // Do nothing
        }
    }

    public static void Log(Exception ex)
    {
        if (ex != null)
        {
            Log(ex.ToString());
            Telemetry.TrackException(ex);
        }
    }

    private static bool EnsurePane()
    {
        if (pane == null)
        {
            Guid guid = Guid.NewGuid();
            var output = (IVsOutputWindow)_provider.GetService(typeof(SVsOutputWindow));
            output.CreatePane(ref guid, _name, 1, 1);
            output.GetPane(ref guid, out pane);
        }

        return pane != null;
    }
}