using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWindowLib
{
    public interface IModuleMetadata
    {
        string Name { get; }
        string Description { get; }
        string ModuleVersion { get; }
        string OpenWindowVersion { get; }
        OSType TargetOS { get; }
        ModuleType ModType { get; }
        BitType Bit { get; }
    }

    public enum OSType
    {
        Linux,
        WindowsXP,
        WindowsVista,
        Windows7,
        Windows8,
        Windows10,
        MacOS
    }

    public enum ModuleType
    { 
        Exploit,
        Recon,
        PrivEsc
    }

    public enum BitType
    {
        Bit32,
        Bit64,
        Bit32And64
    }
}
