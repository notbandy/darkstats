using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database;

namespace dark
{
    public class calc
    {
        public static Character c;
        public static float str(float BaseStat)
        {

            foreach (var it in c.Items)
            {
                BaseStat += it.Value.stats.primary_max_strength;
            }
            return BaseStat;
        }
        public static float vig(float BaseStat)
        {

            foreach (var it in c.Items)
            {
                BaseStat += it.Value.stats.primary_max_strength;
            }
            return BaseStat;
        }
        
    }
}
