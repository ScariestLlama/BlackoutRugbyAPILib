using System;
using System.Linq;
using APILib.API;
using APILib.Mappings;
using APIToObjects.Mappings;

namespace Examples.Demos
{
    public class GetFiveHeavyTMPlayers
    {
        private readonly AppConfig _config;

        public GetFiveHeavyTMPlayers(AppConfig config)
        {
            _config = config;
        }


        public void Run()
        {
            var api = new BlackoutAPI(_config);
            var doc = api.GetPlayersFromTransferMarket(new[] { "&skill1=weight&skill1min=100&limit=5", APIAdditionalRequestData.Nationality("WA") });
            var auctions = new ApiAuctionMapping().MapAll(doc);
            
            //Get player ids from auction xml result
            var playerIds = auctions.Select(auction => auction.PlayerId).ToList();
            //use playerids to fetch player info
            var pDoc = api.GetPlayers(playerIds);
            
            var apiPlayerMapper = new ApiPlayerMapping();
            var apiPlayers = apiPlayerMapper.MapAll(pDoc);

            var playerObjectMapper = new PlayerObjectMapper();
            var players = playerObjectMapper.MapAll(apiPlayers);

            foreach (var p in players)
            {
                Console.WriteLine("{0} - {1}kg ", p.Name, p.Weight);
            }

        }
    }
}