using DataScraper.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataScraper
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\mradt\source\repos\Trinity\Machine Learning\machine-learning-group-project\";
            //string path = @"C:\Users\Daniel\source\repos\machine-learning-group-project\";
            List<Match> matches = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Match>>(File.ReadAllText(path + "MatchDetails.json"));
            List<PlayerDetail> players = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PlayerDetail>>(File.ReadAllText(path + "PlayerDetails.json"));
            players = players.Where(x => x.solo_competitive_rank != null).ToList();
            List<string> Fields = new List<string>()
            {

            };
            // These are the game lobby types where it is not a player vs a computer or event game mode
            List<int> validLobbyTypes = new List<int>() {0,2,5,6,7,9 };
            matches = matches.Where(x => validLobbyTypes.Contains(x.lobby_type)).ToList();

            int playerCount = matches.ToList().SelectMany(x => x.players).Count();
            // Remove players from matches that do not have an id and/or mmr
            var playerPerformance = matches.ToList().SelectMany(x => x.players).ToList();
            playerPerformance = playerPerformance.Where(x => x.account_id.HasValue &&  x.account_id != null).ToList();

            List<Scrubbed> scrubbedData = playerPerformance.Select(x =>
            {
                var player = players.FirstOrDefault(y => y.profile.account_id == x.account_id);
                if (player == null)
                    return null;
                return new Scrubbed(x, player);
            }).ToList();
            // Get players that have mmr
            scrubbedData = scrubbedData.Where(x => x != null).ToList();
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(scrubbedData, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path + "scrubbed2.json", data);
        }

    }
}
