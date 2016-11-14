using HP.LFT.SDK.StdWin;
//using HP.LFT.SDK.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeanFtTestProject1
{
    

    public static class VerifyActionExtensions
    {
        public static void VerifyErrorMessages<T>(this T window) where T : HP.LFT.SDK.WPF.IEditField
        {
            Console.WriteLine(window.Text);
        }

        public static bool Click<T>(this T Control) where T: IUiObject
        {
            Control.Click();
            return true;
        }


        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        public static void PressKey(Keys key, bool up)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            if (up)
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            else
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            }
        }

        
    }
}
