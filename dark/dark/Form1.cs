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
        private unsafe void sButton1_Click(object sender, EventArgs e)
        {
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
    }
}
