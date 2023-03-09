using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Models
{
    public class Scrubbed
    {
        //public int account_id { get; set; }
        public int solo_competitive_rank { get; set; }
        public int assists { get; set; }
        public int deaths { get; set; }
        public int denies { get; set; }
        public int gold { get; set; }
        public int gold_per_min { get; set; }
        public int gold_spent { get; set; }
        public int hero_damage { get; set; }
        public int hero_healing { get; set; }
        public int kills { get; set; }
        public int last_hits { get; set; }
        public int level { get; set; }
        public int net_worth { get; set; }
        //public int party_size { get; set; }
        public int tower_damage { get; set; }
        public int xp_per_min { get; set; }
        public int total_gold { get; set; }
        public int total_xp { get; set; }
        public int kda { get; set; }
        public float kills_per_min { get; set; }

        public float Last_Hits_Per_Minraw { get; set; }

        public float Hero_Damage_Per_Minraw { get; set; }

        public float Hero_Healing_Per_Minraw { get; set; }

        public Scrubbed(Player player, PlayerDetail detail)
        {
            //account_id = detail.profile.account_id;
            solo_competitive_rank = detail.solo_competitive_rank.Value;
            assists = player.assists;
            deaths = player.deaths;
            denies = player.denies;
            gold = player.gold;
            gold_per_min = player.gold_per_min;
            gold_spent = player.gold_spent;
            hero_damage = player.hero_damage;
            hero_healing = player.hero_healing;
            kills = player.kills;
            last_hits = player.last_hits;
            level = player.level;
            net_worth = player.net_worth;
            //party_size = player.party_size;
            tower_damage = player.tower_damage;
            xp_per_min = player.xp_per_min;
            total_gold = player.total_gold;
            total_xp = player.total_xp;
            kda = player.kda;
            kills_per_min = player.kills_per_min;

            Last_Hits_Per_Minraw = player.benchmarks.last_hits_per_min.raw;
            Hero_Damage_Per_Minraw = player.benchmarks.hero_damage_per_min.raw;
            Hero_Healing_Per_Minraw = player.benchmarks.hero_healing_per_min.raw;
        }
        static int BoolToInt(bool b)
        {
            if (b)
                return 1;
            return -1;
        }
    }

}
