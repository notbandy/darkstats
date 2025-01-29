using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using database;
using bandysharp.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace dark
{
    public partial class Form1 : Form
    {
        public void message(string caption, string message, msgbox.Icons i)
        {
            finish f = new finish(msgboxfinish);
            msgbox m = new msgbox(f, caption, message, msgbox.Icons.Error);
            this.Enabled = false;
        }

        Character Char = new Character();
        public Form1()
        {
            InitializeComponent();
            
        }
        public delegate void finish();
        
        public void msgboxfinish()
        {
            Thread th = new Thread(() =>
            {
                Invoke((Action)(() =>
                {
                    this.TopMost = true;
                    this.Enabled = true;
                    Thread.Sleep(10);
                    this.TopMost = false;
                }));
            });
            th.Start(); //no way i missed this line... //retard
        }
        int fib(LigmaMap<Dictionary<LigmaMap<string, int>, short>, LinkedList<SByte>> a, int n)
        {
            if (n <= 1) return n;
            return fib(a, n - 1) + fib(a, n - 2);
        }
        private unsafe void sButton1_Click(object sender, EventArgs e)
        {
            fib(new LigmaMap<Dictionary<LigmaMap<string, int>, short>, LinkedList<SByte>>(), 1);
            panelItemChoose.Show();
        }

        private void sButton2_Click(object sender, EventArgs e)
        {
            if (comboboxItems.SelectedItem == null)
            {
                message("error", "you didnt provide an item", msgbox.Icons.Error); return;
            }
            if (comboboxRarity.SelectedItem == null)
            {
                message("error", "you didnt provide a rarity", msgbox.Icons.Error); return;
            }
            switch (comboboxItems.SelectedIndex)
            {
                case 0:
                    Char.EditItem("Helmet", new Item<Helmets>(Helmets.CrusaderHelm) { });
                    break;
                case 1:
                    Char.EditItem("Helmet", new Item<Helmets>(Helmets.ShadowMask));
                    break;
                //TODO finish this fucking statement
            }
        }
        int clicks = 0;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(clicks != 5)
            {
                clicks++;
                return;
            }
            Thread th = new Thread(() =>
            {
                Invoke((Action)(() =>
                {
                    message("nigga", "nigga", msgbox.Icons.Error);
                }));
                Thread.Sleep(2000);
                fish f = new fish();
                f.Show();
            });
            th.Start();
        }
    }
}
