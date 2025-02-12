﻿using System;
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
                BaseStat += it.Value.stats.primary_max_vigor;
            }
            return BaseStat;
        }
        public static float agi(float BaseStat)
        {

            foreach (var it in c.Items)
            {
                BaseStat += it.Value.stats.primary_max_agility;
            }
            return BaseStat;
        }
        public static float dex(float BaseStat)
        {

            foreach (var it in c.Items)
            {
                BaseStat += it.Value.stats.primary_max_dexterity;
            }
            return BaseStat;
        }
        public static float will(float BaseStat)
        {

            foreach (var it in c.Items)
            {
                BaseStat += it.Value.stats.primary_max_will;
            }
            return BaseStat;
        }
        public static float knlg(float BaseStat)
        {

            foreach (var it in c.Items)
            {
                BaseStat += it.Value.stats.primary_max_knowledge;
            }
            return BaseStat;
        }
        public static float resr(float BaseStat)
        {

            foreach (var it in c.Items)
            {
                BaseStat += it.Value.stats.primary_max_resourcefulness;
            }
            return BaseStat;
        }
        public static float base_health(float str,float vig)
        {
            float basehp = 80;
            float basehealth_rating = (str * (float)0.25) + (vig * (float)0.75);          
            for (int i=1;i<=basehealth_rating;i++)
            {
                if (i<=34)
                {
                    basehp = basehp + 2;
                }
                else if (i<=50)
                {
                    basehp = basehp + (float)1.5;
                }
                else if (i<=75)
                {
                    basehp = basehp + 1;
                }
                else if (i<=100)
                {
                    basehp = basehp + (float)0.5;
                }
               
            }               
            return basehp;
        }
        public static float health(float basehp)
        {
            float maxhpbonus = 0;
            float maxhp = 0;

            foreach (var it in c.Items)
            {
                maxhpbonus += it.Value.stats.primary_max_max_health_bonus;
                maxhp += it.Value.stats.primary_max_max_health;
            }

            return basehp * (1 + maxhpbonus) + maxhp;
        }
        public static float memcap(float knlg)
        {
            float memcap = 0;
            for (int i = 1;i<=knlg;i++)
            {
                if (i>=6&&i<=100)
                {
                    memcap++;
                }
                
            }
            return memcap;
        }
        public static float move_speed(float agi)
        {
            float basespeed = -10;
            for (int i =1;i<=agi;i++)
            {
                if (i<=10)
                {
                    basespeed += (float)0.5;
                }
                else if (i<=15)
                {
                    basespeed += 1;
                }
                else if (i<=75)
                {
                    basespeed += (float)0.75;
                }
                else if (i<=100)
                {
                    basespeed += (float)0.5;
                }
            }
            basespeed += 300;

            float gearms = 0;            
            float msbonus = 0;
            foreach (var it in c.Items)
            {
                gearms += it.Value.stats.primary_max_move_speed;
                msbonus += it.Value.stats.primary_max_move_speed_bonus;
            }

            return (basespeed+gearms)*(1+msbonus);
        }

    }
}
