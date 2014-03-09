using System;
using System.Linq;
using APILib.API;
using APILib.Mappings;
using APIToObjects.Mappings;

namespace Examples.Demos
{
    public class GetMyBestFivePlayers
    {
        private readonly AppConfig _config;

        public GetMyBestFivePlayers(AppConfig config)
        {
            _config = config;
        }

        public void Run()
        {
            var api = new BlackoutAPI(_config);
            var doc = api.GetPlayersFromTeam("46531");
            var apiPlayerMapper = new ApiPlayerMapping();
            var apiTeamPlayers = apiPlayerMapper.MapAll(doc);
            //Like the previous demo we have the xml doc mapped to a code representation of the doc
            //however if we want to take it a step further we can map these to more useable objects
            var playerObjectMapper = new PlayerObjectMapper();
            var players = playerObjectMapper.MapAll(apiTeamPlayers);

            var bestFive = players.OrderByDescending(p => p.Csr).Take(5);
            foreach (var p in bestFive)
            {
                Console.WriteLine("{0} - {1} CSR", p.Name, p.Csr);
            }

        }
    }
}