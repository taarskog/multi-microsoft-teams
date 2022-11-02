using Microsoft.Win32;
using System.Diagnostics;

namespace MMT.Core
{
    public class RegistryManager
    {
        private readonly RegistryKey _registryKey;

        public RegistryManager()
        {
            _registryKey = Registry.CurrentUser.OpenSubKey(StaticResources.StartupApplications, true)!;
        }

        public bool IsApplicationInStartup(string name)
        {            
            return _registryKey.GetValue(name) != null;
        }

        public void AddApplicationInStartup(string name)
        {
            _registryKey.SetValue(name, System.Environment.ProcessPath ?? throw new System.Exception("Process path is null."));
        }

        public void RemoveApplicationFromStartup(string appName)
        {
            _registryKey.DeleteValue(appName, false);
        }
    }
}
