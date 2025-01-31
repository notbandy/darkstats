using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bandysharp.Collections;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Drawing;
using dark;

namespace database
{
    
    public class Character
    {

        public string calljsonapi(string url)
        {
            using(var http = new HttpClient())
            {
                HttpResponseMessage req = http.GetAsync(url).Result;
                string json = req.Content.ReadAsStringAsync().Result;
                return json;
            }
            
        }
        public Image calliconapi(string url)
        {
            using (var http = new HttpClient())
            {
                try
                {
                    byte[] req = http.GetByteArrayAsync(url).Result;
                    using (var icon = new MemoryStream(req)) //ive got genuinely no idea how hard ive cooked
                    {
                        return Image.FromStream(icon);
                    }
                }
                catch
                {
                    Form1 temp = new Form1();
                    temp.message("Error", "API request failed, or overloaded", msgbox.Icons.Error);
                    return null;
                }
            }

        }
        public Dictionary<string, short> Stats = new Dictionary<string, short>()
        {
            {"strength", 0 },
            {"vigor", 0 },
            {"agility", 0 },
            {"dexterity", 0 },
            {"will", 0 },
            {"knowledge", 0 },
            {"resourcefulness", 0 },
            {"movespeed", 0 },
            {"Ppowerbonus",0 }
        };

        public Dictionary<string, object> Items = new Dictionary<string, object>()
        {
            {"Helmet", null },
            {"Chest", null },
            {"Leg", null },
            {"Hand", null },
            {"Foot", null },
            {"Back", null },
            {"Necklace", null },
            {"Ring", null },
            {"Ring2", null }
        };

        public void EditItem(string itemType, object item)
        {
            Items[itemType] = item;
        }

    }

    public class Item //creates an item with its type 'helmet, chest...'
    {
        public string name;
        public string rarity;
        public string type; //this is the item name, for example Helmets.CrusaderHelm
        public Item(string itemName, string rarity, string type) //takes in ItemType.ItemName for eg. Helmets.CrusaderHelm
        {
            name = itemName;
            this.rarity = rarity;
            this.type = type;
        }

        /*
        public Dictionary<string, short> Stats = new Dictionary<string, short>()
        {
            {"strength", 0 },
            {"vigor", 0 },
            {"agility", 0 },
            {"dexterity", 0 },
            {"will", 0 },
            {"knowledge", 0 },
            {"resourcefulness", 0 },
            {"movespeed", 0 },
            {"Ppowerbonus",0 }
        };
        */
        
        
    }
}
