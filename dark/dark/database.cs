using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bandysharp.Collections;
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

    public enum Rarity
    {
        Poor,Common,Uncommon,Rare,Epic,Legendary,Unique
    }

    public class Item<TItem> //creates an item with its type 'helmet, chest...'
    {
        public TItem name; //this is the item name, for example Helmets.CrusaderHelm
        public Item(TItem itemName) //takes in ItemType.ItemName for eg. Helmets.CrusaderHelm
        {
            name = itemName; //boilerplate
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

        public Rarity rarity
        {
            set
            {
                //SOMEONE PLEASE FINISH THIS SHIT // ahh hell nawww
                switch(value) //Rarity check
                {
                    case Rarity.Poor:
                        switch (this.name) //item typecheck
                        {
                            case Helmets h: //if helmets

                                switch (h)
                                {
                                    case Helmets.CrusaderHelm: //fucking curzader
                                        Stats["strength"] = 1;
                                        Stats["vigor"] = 2;
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}
