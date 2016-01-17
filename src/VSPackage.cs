using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace IonicPack
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Version, IconResourceID = 400)]
    [ProvideAutoLoad(UIContextGuids80.SolutionExists)]
    [Guid(Guid)]
    public sealed class VSPackage : Package
    {
        public const string Version = "1.0";
        public const string Name = "Ionic Pack";
        public const string Guid = "65879cf0-df9b-43b5-a55a-01c043ac224b";

        protected override void Initialize()
        {
            Logger.Initialize(this, Name);
            Telemetry.Initialize(this, Version, "527270b3-08af-45b4-a972-4d63b52b2a58");

            base.Initialize();
        }
    }
}
