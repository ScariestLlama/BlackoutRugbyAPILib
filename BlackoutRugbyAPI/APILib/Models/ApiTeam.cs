namespace APILib.Models
{
    public class ApiTeam
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
  public string RegionId { get; set; }
  public string StadiumName { get; set; }
        public string IsBot { get; set; } 
        public string Nickname1 { get; set; }
        public string Nickname2 { get; set; }
        public string Nickname3 { get; set; }
        public string RankingPoints { get; set; }
        public string RegionalRank { get; set; }
        public string NationalRank { get; set; }
        public string WorldRank { get; set; }

  public string PrevRankingPoints { get; set; }
  public string PrevRegionalRank { get; set; }
  public string PrevNationalRank { get; set; }
  public string PrevWorldRank { get; set; }
  public string Plural { get; set; }
  public string PluralNickname1 { get; set; }
  public string PluralNickname2 { get; set; }
  public string PluralNickname3 { get; set; }
  public string MinimumSalary { get; set; }
  public string LeagueId { get; set; }
  public string Manager { get; set; }
    }
}