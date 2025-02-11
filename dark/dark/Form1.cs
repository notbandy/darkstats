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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Security.Cryptography;

namespace dark
{
    
    public partial class Form1 : Form
    {
        Character.Class Cluss { get; set; }
        public static Dictionary<string, string> raritycode = new Dictionary<string, string>()
        {
            {"Poor", "1001" },
            {"Common", "2001" },
            {"Uncommon", "3001" },
            {"Rare", "4001" },
            {"Epic", "5001" },
            {"Legendary", "6001" },
            {"Unique", "7001" },
        };
        public void message(string caption, string message, msgbox.Icons i)
        {
            finish f = new finish(msgboxfinish);
            if(this.Visible)
            {
                msgbox m = new msgbox(f, caption, message, msgbox.Icons.Error);

            }
            else
            {
                msgbox m = new msgbox(null, caption, message, msgbox.Icons.Error);
            }
            this.Enabled = false;
        }
        public delegate void msg(string c, string t, msgbox.Icons i);
        public static msg msgdeleg;
        Character Char1 = new Character(msgdeleg);
        public Form1()
        {
            InitializeComponent();
            refreshPopulation();
            msgdeleg = new msg(message);
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
            Char1.EditItem(type, i);
            p.Image = API.calliconapi("https://api.darkerdb.com/v1/icon?id=" + comboboxItems.Text + "_" + raritycode[comboboxRarity.Text]);
            message("item added", "test message" + Environment.NewLine + "item: " + i.stats.name + Environment.NewLine + "Rarity: " + i.stats.rarity + Environment.NewLine + "Max armor rating: " + i.stats.primary_max_armor_rating, msgbox.Icons.Info);        
        }
        

        private unsafe void sButton1_Click(object sender, EventArgs e)
        {
            //fib(new LigmaMap<Dictionary<LigmaMap<string, int>, short>, LinkedList<SByte>>(), 1);
            panelItemChoose.Top = panelItemChoose.Top + 100;
            panelItemChoose.Show();
            Transition.run(panelItemChoose, "Top", panelItemChoose.Top - 100, new TransitionType_EaseInEaseOut(700));
            buttonAddItem.Enabled = false;
        }

        private void sButton2_Click(object sender, EventArgs e)
        {
            buttonAddItem.Enabled = true;
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
            else if(i <= 25)
            {
                logItem(comboboxItems.Text, comboboxRarity.Text, "MainHand", ref pbMainHand);

            }    
            else if(i <= 28)
            {
                logItem(comboboxItems.Text, comboboxRarity.Text, "OffHand", ref pbOffHand);
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
        
        private void comboboxItems_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void comboboxItems_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
           
        }
        
        private void sButton1_Click_2(object sender, EventArgs e)
        {
            //message(Char.Items["OffHand"].stats.primary_max_weapon_damage.ToString(), "asd", msgbox.Icons.Info);
            switch (Cluss)
            {
                case Character.Class.fighter:
                    Char1.Stats["strength"] = calc_str(15);
                    Char1.Stats["vigor"] = calc_vig(15);
                    Char1.Stats["agility"]= 15;
                    Char1.Stats["dexterity"] = 0;
                    Char1.Stats["will"] = 0;
                    Char1.Stats["knowledge"] = 0;
                    Char1.Stats["resourcefulness"] = 0;
                    Char1.Stats["health"] = 0;
                    Char1.Stats["memcap"] = 0;
                    Char1.Stats["movespeed"] = 0;
                    Char1.Stats["actionspeed"] = 0;
                    Char1.Stats["armorpen"] = 0;
                    Char1.Stats["magicpen"] = 0;
                    Char1.Stats["headshotred"] = 0;
                    Char1.Stats["armorrating"] = 0;
                    Char1.Stats["pdr"] = 0;
                    Char1.Stats["magicres"] = 0;
                    Char1.Stats["mdr"] = 0;
                    Char1.Stats["physpower"] = 0;
                    Char1.Stats["magicpower"] = 0;
                    Char1.Stats["Ppowerbonus"] = 0;
                    Char1.Stats["Mpowerbonus"] = 0;
                    Char1.Stats["TruePhysDamage"] = 0;
                    Char1.Stats["maxhbonus"] = 0;
                    Char1.Stats["Physdamage"] = 0;
                    Char1.Stats["Physdamagebonus"] = 0;
                    Char1.Stats["magicdamage"] = 0;
                    Char1.Stats["magicdamagebonus"] = 0;
                    Char1.Stats["addphysdamage"] = 0;
                    Char1.Stats["addmagicdamage"] = 0;
                    break;

            }
        }
        
        private void CBclass_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CBclass_select.SelectedText)
            {
                case "Fighter":
                    Cluss = Character.Class.fighter;
                    break;
                case "Barbarian":
                    Cluss = Character.Class.barbarian;
                    break;
                case "Rouge":
                    Cluss = Character.Class.rouge;
                    break;
                case "Ranger":
                    Cluss = Character.Class.ranger;
                    break;
                case "Wizard":
                    Cluss = Character.Class.wizard;
                    break;
                case "Cleric":
                    Cluss = Character.Class.cleric;
                    break;
                case "Bard":
                    Cluss = Character.Class.bard;
                    break;
                case "Warlock":
                    Cluss = Character.Class.warlock;
                    break;
                case "Druid":
                    Cluss = Character.Class.druid;
                    break;
                case "Sorcerer":
                    Cluss = Character.Class.sorcerer;
                    break;
            }
        }
        public float calc_str(float BaseStat)
        {
            float n = BaseStat + Char1.Items["Helmet"].stats.primary_max_strength + Char1.Items["Chest"].stats.primary_max_strength + Char1.Items["Leg"].stats.primary_max_strength + Char1.Items["Hand"].stats.primary_max_strength + Char1.Items["Foot"].stats.primary_max_strength + Char1.Items["Back"].stats.primary_max_strength + Char1.Items["Necklace"].stats.primary_max_strength + Char1.Items["Ring"].stats.primary_max_strength + Char1.Items["Ring2"].stats.primary_max_strength + Char1.Items["MainHand"].stats.primary_max_strength + Char1.Items["OffHand"].stats.primary_max_strength;
            return n;
        }
        public float calc_vig(float BaseStat)
        {
            float n = BaseStat + Char1.Items["Helmet"].stats.primary_max_vigor + Char1.Items["Chest"].stats.primary_max_vigor + Char1.Items["Leg"].stats.primary_max_vigor + Char1.Items["Hand"].stats.primary_max_vigor + Char1.Items["Foot"].stats.primary_max_vigor + Char1.Items["Back"].stats.primary_max_vigor + Char1.Items["Necklace"].stats.primary_max_vigor + Char1.Items["Ring"].stats.primary_max_vigor + Char1.Items["Ring2"].stats.primary_max_vigor + Char1.Items["MainHand"].stats.primary_max_vigor + Char1.Items["OffHand"].stats.primary_max_vigor;
            return n;
        }
    }
}
