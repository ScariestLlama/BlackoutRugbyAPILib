using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APILib.API;
using APILib.Mappings;

namespace Examples.Demos
{
    public class GetTeamDemo
    {
        private readonly AppConfig _config;

        public GetTeamDemo(AppConfig config)
        {
            _config = config;
        }

        public void Run()
        {
            var api = new BlackoutAPI(_config);
            var doc = api.GetTeam("46531");
            var teamApiMapper = new ApiTeamMapping();
            var team = teamApiMapper.MapAll(doc).FirstOrDefault();
            if (team != null)
            {
                Console.WriteLine("Team: {0}", team.Name);
            }
            
        }
    }
}
