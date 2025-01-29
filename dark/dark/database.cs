using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<object> Items = new List<object>();
        
        public void AddItem<ItemType>(ItemType item)
        {
            Items.Add(new Item<ItemType>(item));
        }

        public void AddItem(object item)
        {
            Items.Add(item);
        }     
    }

    #region ItemTypes
    public enum Helmets
    {
        CrusaderHelm, ShadowMask, KettleHat
    }

    public enum Chests
    {
        ChampionArmor, Frock, MysticVestments
    }
    public enum Legs
    {
        BardicPants, HeavyLeatherLeggings, PlatePants
    }
    public enum Hands
    {
        ArcaneGloves, ElkwoodGloves, LightGauntlets
    }
    public enum Foots
    {
        AdventurerBoots, LightfootBoots, HeavyBoots
    }
    public enum Backs
    {
        AdventurerCloak, MercurialCloak, RadiantCloak
    }
    public enum Necklaces
    {
        BearPendant, FoxPendant, OwlPendant
    }
    public enum Rings
    {
        RingOfWisdom, RingOfVitality, RingOfFinesse
    }
    #endregion

    public class Item<TItem>
    {
        public TItem name;
        public Item(TItem itemName)
        {
            name = itemName;
        }
    }
}
