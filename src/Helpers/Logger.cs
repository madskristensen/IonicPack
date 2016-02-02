using System;
using Microsoft.VisualStudio.Shell.Interop;

public static class Logger
{
    static IVsOutputWindowPane pane;
    static object _syncRoot = new object();
    static IServiceProvider _provider;
    static string _name;

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

    static bool EnsurePane()
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