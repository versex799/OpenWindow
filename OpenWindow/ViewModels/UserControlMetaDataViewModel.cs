using OpenWindowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWindow.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class UserControlMetaDataViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IModuleMetadata Metadata { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BitType
        {
            get { return GetBitString(Metadata.Bit); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        public UserControlMetaDataViewModel(IModuleMetadata metadata)
        {
            Metadata = metadata;
        }

        private string GetBitString(BitType bit)
        {
            switch (bit)
            {
                case OpenWindowLib.BitType.Bit32: { return "32-Bit"; }
                case OpenWindowLib.BitType.Bit64: { return "64-Bit"; }
                case OpenWindowLib.BitType.Bit32And64: { return "32-Bit and 64-Bit"; }
                default: return "N/A";
            }
        }
    }
}
