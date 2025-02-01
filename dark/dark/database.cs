﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using bandysharp.Collections;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Drawing;
using dark;
using System.Text.RegularExpressions;

namespace database
{

    public class Character
    {



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

    public sealed class API
    {
        public static string calljsonapi(string url)
        {
            using (var http = new HttpClient())
            {
                HttpResponseMessage req = http.GetAsync(url).Result;
                string json = req.Content.ReadAsStringAsync().Result;
                return json;
            }
        }
        public static Image calliconapi(string url)
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
    }

    public struct ServerPopulation
    {

        public static ServerPopulation pullPopulation()
        {
            var parsed = JObject.Parse(API.calljsonapi("https://api.darkerdb.com/v1/server-population"))["body"].ToString();
            return JsonConvert.DeserializeObject<ServerPopulation>(parsed);
        }
        //properties
        public string timestamp { get; set; }
        public int num_online { get; set; }
        public int num_lobby { get; set; }
        public int num_dungeon { get; set; }
        public string timestamp_display { get; set; }
    }

    public struct ItemStats //PLEASE COLLAPSE
    {
        public static ItemStats pullStats(string url)
        {
            var parsed = JObject.Parse(API.calljsonapi(url).Replace('[', ' ').Replace(']', ' '))["body"].ToString();
            return JsonConvert.DeserializeObject<ItemStats>(parsed);
        }
        public string id { get; set; }
        public int cursor { get; set; }
        public string archetype { get; set; }
        public string name { get; set; }
        public string rarity { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string armor_type { get; set; }
        public string slot_type { get; set; }
        public int max_stack_size { get; set; }
        public int inventory_width { get; set; }
        public int inventory_height { get; set; }
        public float vendor_price { get; set; }
        public float time_to_equip { get; set; }
        public int gear_score { get; set; }
        public int adventure_points { get; set; }
        public float experience { get; set; }
        public float num_primary_attributes { get; set; }
        public float num_secondary_attributes { get; set; }
        public float primary_min_armor_rating { get; set; }
        public float primary_max_armor_rating { get; set; }
        public float primary_min_move_speed { get; set; }
        public float primary_max_move_speed { get; set; }
        public float secondary_min_agility { get; set; }
        public float secondary_max_agility { get; set; }
        public float secondary_min_additional_armor_rating { get; set; }
        public float secondary_max_additional_armor_rating { get; set; }
        public float secondary_min_buff_duration_bonus { get; set; }
        public float secondary_max_buff_duration_bonus { get; set; }
        public float secondary_min_debuff_duration_bonus { get; set; }
        public float secondary_max_debuff_duration_bonus { get; set; }
        public float secondary_min_dexterity { get; set; }
        public float secondary_max_dexterity { get; set; }
        public float secondary_min_knowledge { get; set; }
        public float secondary_max_knowledge { get; set; }
        public float secondary_min_luck { get; set; }
        public float secondary_max_luck { get; set; }
        public float secondary_min_magic_resistance { get; set; }
        public float secondary_max_magic_resistance { get; set; }
        public float secondary_min_magical_damage_bonus { get; set; }
        public float secondary_max_magical_damage_bonus { get; set; }
        public float secondary_min_magical_damage_reduction { get; set; }
        public float secondary_max_magical_damage_reduction { get; set; }
        public float secondary_min_magical_power { get; set; }
        public float secondary_max_magical_power { get; set; }
        public float secondary_min_max_health { get; set; }
        public float secondary_max_max_health { get; set; }
        public float secondary_min_max_health_bonus { get; set; }
        public float secondary_max_max_health_bonus { get; set; }
        public float secondary_min_additional_memory_capacity { get; set; }
        public float secondary_max_additional_memory_capacity { get; set; }
        public float secondary_min_memory_capacity_bonus { get; set; }
        public float secondary_max_memory_capacity_bonus { get; set; }
        public float secondary_min_additional_move_speed { get; set; }
        public float secondary_max_additional_move_speed { get; set; }
        public float secondary_min_move_speed_bonus { get; set; }
        public float secondary_max_move_speed_bonus { get; set; }
        public float secondary_min_physical_damage_bonus { get; set; }
        public float secondary_max_physical_damage_bonus { get; set; }
        public float secondary_min_physical_damage_reduction { get; set; }
        public float secondary_max_physical_damage_reduction { get; set; }
        public float secondary_min_physical_power { get; set; }
        public float secondary_max_physical_power { get; set; }
        public float secondary_min_projectile_damage_reduction { get; set; }
        public float secondary_max_projectile_damage_reduction { get; set; }
        public float secondary_min_resourcefulness { get; set; }
        public float secondary_max_resourcefulness { get; set; }
        public float secondary_min_strength { get; set; }
        public float secondary_max_strength { get; set; }
        public float secondary_min_vigor { get; set; }
        public float secondary_max_vigor { get; set; }
        public float secondary_min_will { get; set; }
        public float secondary_max_will { get; set; }
        public string icon { get; set; }
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
            string spacedName = Regex.Replace(itemName, "([a-z])([A-Z])", "$1 $2");
            string url = "https://api.darkerdb.com/v1/search?item=" + spacedName + "&rarity=" + rarity;
            stats = ItemStats.pullStats(url);
        }
        public ItemStats stats { get; set; }
        

    }
}
