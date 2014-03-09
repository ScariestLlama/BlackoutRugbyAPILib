using System;
using System.Configuration;
using APILib.API;
using Examples.Demos;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {

            //You'll need to add your details to the App.config files for this to work

            var config = new AppConfig(
                ConfigurationManager.AppSettings["DeveloperKey"],
                ConfigurationManager.AppSettings["DeveloperID"],
                ConfigurationManager.AppSettings["DeveloperIV"],
                ConfigurationManager.AppSettings["BaseAPIUrl"],
                ConfigurationManager.AppSettings["MyMemberID"],
                ConfigurationManager.AppSettings["MyMemberKey"],
                1000
                );

            var demo = new GetTeamDemo(config);
            demo.Run();

            var myBestFivePlayers = new GetMyBestFivePlayers(config);
            myBestFivePlayers.Run();

            var getFirstFivePlayersOnTMWhoWeigh100kgOrMoreAndAreWelsh = new GetFiveHeavyTMPlayers(config);
            getFirstFivePlayersOnTMWhoWeigh100kgOrMoreAndAreWelsh.Run();

            Console.ReadKey();
        }
    }
}
