using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Tesla.ItcastCater.CommonHelper
{
    public class CurrentDomainAssemblyResolver
    {
        public static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);
            if (assemblyName.Name.StartsWith("Microsoft.VisualStudio.TestTools.UITest", StringComparison.Ordinal))
            {
                string path = string.Empty;
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\VisualStudio\11.0"))
                {
                    if (key != null)
                    {
                        path = key.GetValue("InstallDir") as string;
                    }
                }

                if (!string.IsNullOrWhiteSpace(path))
                {
                    string assemblyPath = Path.Combine(path, "PublicAssemblies",
                        string.Format(CultureInfo.InvariantCulture, "{0}.dll", assemblyName.Name));

                    if (!File.Exists(assemblyPath))
                    {
                        assemblyPath = Path.Combine(path, "PrivateAssemblies",
                            string.Format(CultureInfo.InvariantCulture, "{0}.dll", assemblyName.Name));

                        if (!File.Exists(assemblyPath))
                        {
                            string commonFiles = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
                            if (string.IsNullOrWhiteSpace(commonFiles))
                            {
                                commonFiles = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
                            }

                            assemblyPath = Path.Combine(commonFiles, "Microsoft Shared", "VSTT", "11.0",
                                string.Format(CultureInfo.InvariantCulture, "{0}.dll", assemblyName.Name));
                        }
                    }

                    if (File.Exists(assemblyPath))
                    {
                        return Assembly.LoadFrom(assemblyPath);
                    }
                }
            }

            return null;
        }
    }
}