using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathOfServant
{
    public class Keyboard
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag

        public void Send(Keys key)
        {
            var vk = (byte)key;
            keybd_event(vk, 0, KEYEVENTF_EXTENDEDKEY, 0);
            Thread.Sleep(50);
            keybd_event(vk, 0, KEYEVENTF_KEYUP, 0);
        }

        public void SendDown(Keys key)
        {
            var vk = (byte)key;
            keybd_event(vk, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }

        public void SendUp(Keys key)
        {
            var vk = (byte)key;
            keybd_event(vk, 0, KEYEVENTF_KEYUP, 0);
        }
    }
        
}
