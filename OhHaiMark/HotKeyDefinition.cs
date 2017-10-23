using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OhHaiMark
{
    public class HotKeyDefinition
    {
        public const int NO_MODIFIER = 0x0000;
        public const int ALT = 0x0001;
        public const int CTRL = 0x0002;
        public const int SHIFT = 0x0004;
        public const int WINKEY = 0x0008;

        public const int WM_HOTKEY_ID = 0x0312;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private IntPtr hWnd;
        private int id;
        private int mod;
        private int key;

        public HotKeyDefinition(int mod, Keys key, Form form)
        {
            this.mod = mod;
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return DateTime.Now.Second & mod & key + new Random().Next(0,999999999);
        }

        public bool RegisterKeyCombo()
        {
            return RegisterHotKey(hWnd, id, mod, key);
        }

        public bool UnRegisterKeyCombo()
        {
            return UnregisterHotKey(hWnd, id);
        }



    }
}
