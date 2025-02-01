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
using Transitions;

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
            refreshPopulation();
            
        }
        public delegate void finish();
        
        public void refreshPopulation()
        {
            ServerPopulation sp = ServerPopulation.pullPopulation(); //init new server population object
            labelPlayersOnline.Text = sp.num_online.ToString(); //online
            labelInLobby.Text = sp.num_lobby.ToString(); //lobby
            labelDungeon.Text = sp.num_dungeon.ToString(); //dungeon
            refreshed = DateTime.UtcNow;
        }

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

        void logItem(string item, string rarity, string type, ref PictureBox p)
        {
            Item i = new Item(item, rarity, type) { };
            Char.EditItem(type, i);
            p.Image = API.calliconapi("https://api.darkerdb.com/v1/icon?id=" + comboboxItems.Text + "_6001");
            message("item added", "test message" + Environment.NewLine + "item: " + i.name + Environment.NewLine + "Rarity: " + i.stats.rarity + Environment.NewLine + "Time to equip: " + i.stats.time_to_equip.ToString() + Environment.NewLine + "Max armor rating: " + i.stats.primary_max_armor_rating, msgbox.Icons.Info);
        }

        private unsafe void sButton1_Click(object sender, EventArgs e)
        {
            //fib(new LigmaMap<Dictionary<LigmaMap<string, int>, short>, LinkedList<SByte>>(), 1);
            panelItemChoose.Top = panelItemChoose.Top + 100;
            panelItemChoose.Show();
            Transition.run(panelItemChoose, "Top", panelItemChoose.Top - 100, new TransitionType_EaseInEaseOut(700));
            
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
            int i = comboboxItems.SelectedIndex;
            if (i <= 2)
            {
                logItem(comboboxItems.Text, comboboxRarity.Text, "Helmet", ref pbHelmet);
            }
            else if(i <= 5)
            {
                logItem(comboboxItems.Text, comboboxRarity.Text, "Chest", ref pbChest);
            }
            else if(i <= 8)
            {
                logItem(comboboxItems.Text, comboboxRarity.Text, "Leg", ref pbLeg);
            }
            else if(i <= 11)
            {
                logItem(comboboxItems.Text, comboboxRarity.Text, "Hands", ref pbHands);
            }
            else if(i <= 14)
            {
                logItem(comboboxItems.Text, comboboxRarity.Text, "Foot", ref pbFoot);
            }
            else if(i <= 17)
            {
                logItem(comboboxItems.Text, comboboxRarity.Text, "Back", ref pbBack);
            }
            else if(i <= 20)
            {
                logItem(comboboxItems.Text, comboboxRarity.Text, "Necklace", ref pbNecklace);
            }
            else if(i <= 23)
            {
                if(usering2)
                {
                    logItem(comboboxItems.Text, comboboxRarity.Text, "Ring", ref pbRing2);
                    usering2 = false;
                }
                else
                {
                    logItem(comboboxItems.Text, comboboxRarity.Text, "Ring", ref pbRing1);
                    usering2 = true;
                }
            }
            
        }
        int clicks = 0;
        bool usering2 = false;
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

        private void sButton1_Click_1(object sender, EventArgs e)
        {
            message("crusader response", API.calljsonapi("https://api.darkerdb.com/v1/search?item=Crusader%20Helm&rarity=Legendary"), msgbox.Icons.Info); //getting cursader helmet
            //if you check messagebox.cs i've made it so that longer texts make the box expand
            //useful if you ever need long popups
            //message("test response", API.calljsonapi("https://api.darkerdb.com/v1/health-check"), msgbox.Icons.Info); //just an api req test
            //this wont expand the msgbox
        }
        DateTime refreshed;
        private void sButton2_Click_1(object sender, EventArgs e)
        {
            if (DateTime.UtcNow - refreshed > TimeSpan.FromSeconds(7))
            {
                message("success", "server population refreshed successfully", msgbox.Icons.Info);
                refreshPopulation();
            }
        }
    }
}
