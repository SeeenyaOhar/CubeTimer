using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FringleTimer.Model
{
    static class SecureStringExtension
    {
        internal static String SecureStringToPassword(this SecureString secstring)
        {
            IntPtr ptr = default(IntPtr);
            try
            {
                if (secstring != null)
                {
                    ptr = Marshal.SecureStringToGlobalAllocUnicode(secstring);
                    return Marshal.PtrToStringAuto(ptr);
                }
                else return "";


            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(ptr);
                GC.Collect();
            }

        }
        internal unsafe static SecureString ToSecureString(this String str)
        {
            IntPtr ptr = default;
            try
            {
               ptr = Marshal.StringToBSTR(str);
                Char* chars = (Char*)ptr;
                return new SecureString(chars, str.Length);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(ptr);
                GC.Collect();
            }
        }
    }
}
