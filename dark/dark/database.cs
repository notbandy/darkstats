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

    }

    public class Item
    {
        string name;
    }
}
