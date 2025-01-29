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

namespace dark
{
    public partial class Form1 : Form
    {
        Character Char = new Character();
        public Form1()
        {
            InitializeComponent();
            

            Item<Chests> frock = new Item<Chests>(Chests.Frock);

            main.AddItem<Helmets>(Helmets.ShadowMask);

            main.AddItem(frock);
        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            panelItemChoose.Show();
        }

        private void sButton2_Click(object sender, EventArgs e)
        {
            if (comboboxItems.SelectedItem == null)
                return;
            switch(comboboxItems.SelectedIndex)
            {
                case 0:
                    Char.EditItem("Helmet", Helmets.CrusaderHelm);
                    break;
                case 1:
                    Char.EditItem("Helmet", Helmets.ShadowMask);
                    break;
            }
        }
    }
}
