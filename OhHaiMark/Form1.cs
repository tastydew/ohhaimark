using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OhHaiMark
{
    public partial class frmhaimark : Form
    {

        private HotKeyDefinition hotKeyDef;
        SoundPlayer snd = new SoundPlayer(Properties.Resources.ohhaimark);

        public frmhaimark()
        {
            InitializeComponent();
            hotKeyDef = new HotKeyDefinition(HotKeyDefinition.CTRL + HotKeyDefinition.SHIFT, Keys.M, this);
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
        }

        private void PlaySound()
        {
            snd.Stop();
            snd.Play();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == HotKeyDefinition.WM_HOTKEY_ID)
            {
                PlaySound();
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                hotKeyDef.RegisterKeyCombo();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not register keys");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!hotKeyDef.UnRegisterKeyCombo())
                MessageBox.Show("Failed to unregister keys");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            snd.Dispose();
            this.Close();
        }
    }
}
