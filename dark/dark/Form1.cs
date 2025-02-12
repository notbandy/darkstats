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
        Character.Class targetclass { get; set; }
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
            calc.c = Char1;
            switch (targetclass)
            {
                case Character.Class.fighter:
                    calcAllStats(new float[]
                    { 
                        calc.str(15), // 0
                        calc.vig(15), // 1
                        calc.agi(15), // 2
                        calc.dex(15), // 3
                        calc.will(15), // 4
                        calc.knlg(15), // 5
                        calc.resr(15), // 6
                        calc.base_health(calc.str(15),calc.vig(15)), // 7
                        calc.health(calc.base_health(calc.str(15),calc.vig(15))), // 8
                        calc.memcap(calc.knlg(15)), // 9
                        calc.move_speed(calc.agi(15)) // 10

                    }
                    );
                    break;

            }
        }
        public void calcAllStats(float[] stats)
        {
            Char1.Stats["strength"] = stats[0];
            Char1.Stats["vigor"] = stats[1];
            Char1.Stats["agility"] = stats[2];
            Char1.Stats["dexterity"] = stats[3];
            Char1.Stats["will"] = stats[4];
            Char1.Stats["knowledge"] = stats[5];
            Char1.Stats["resourcefulness"] = stats[6];
            Char1.Stats["base_health"] = stats[7];
            Char1.Stats["health"] = stats[8];
            Char1.Stats["memcap"] = stats[9];
            Char1.Stats["movespeed"] = stats[10];
            Char1.Stats["actionspeed"] = stats[11];
            Char1.Stats["armorpen"] = stats[12];
            Char1.Stats["magicpen"] = stats[13];
            Char1.Stats["headshotred"] = stats[14];
            Char1.Stats["armor_rating"] = stats[15];
            Char1.Stats["pdr"] = stats[16];
            Char1.Stats["magicres"] = stats[17];
            Char1.Stats["mdr"] = stats[18];
            Char1.Stats["physpower"] = stats[19];
            Char1.Stats["magicpower"] = stats[20];
            Char1.Stats["Ppowerbonus"] = stats[21];
            Char1.Stats["Mpowerbonus"] = stats[22];
            Char1.Stats["TruePhysDamage"] = stats[23];
            Char1.Stats["maxhbonus"] = stats[24];
            Char1.Stats["Physdamage"] = stats[25];
            Char1.Stats["Physdamagebonus"] = stats[26];
            Char1.Stats["magicdamage"] = stats[27];
            Char1.Stats["magicdamagebonus"] = stats[28];
            Char1.Stats["addphysdamage"] = stats[29];
            Char1.Stats["addmagicdamage"] = stats[30];
        }
        private void CBclass_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CBclass_select.SelectedText)
            {
                case "Fighter":
                    targetclass = Character.Class.fighter;
                    break;
                case "Barbarian":
                    targetclass = Character.Class.barbarian;
                    break;
                case "Rouge":
                    targetclass = Character.Class.rouge;
                    break;
                case "Ranger":
                    targetclass = Character.Class.ranger;
                    break;
                case "Wizard":
                    targetclass = Character.Class.wizard;
                    break;
                case "Cleric":
                    targetclass = Character.Class.cleric;
                    break;
                case "Bard":
                    targetclass = Character.Class.bard;
                    break;
                case "Warlock":
                    targetclass = Character.Class.warlock;
                    break;
                case "Druid":
                    targetclass = Character.Class.druid;
                    break;
                case "Sorcerer":
                    targetclass = Character.Class.sorcerer;
                    break;
            }
        }
        
    }
}
