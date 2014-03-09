using System;

namespace APILib.Models
{
    public class ApiPlayer
    {
        #region Standard Properties
            public string Id { get; set; }
          public string TeamId { get; set; }
          public string FirstName{ get; set; }
          public string LastName{ get; set; }
          public string Age{ get; set; }
          public string Birthday{ get; set; }
          public string Hand{ get; set; }
          public string Foot{ get; set; }
          public string Nationality{ get; set; }
          public string Csr{ get; set; }
          public string Salary{ get; set; }
          public string Form{ get; set; }
          public string Aggression{ get; set; }
          public string Discipline{ get; set; }
          public string Energy{ get; set; }
          public string Leadership{ get; set; }
          public string Experience{ get; set; }
          public string Weight{ get; set; }
          public string Height{ get; set; }
          public string Youthid{ get; set; }
          public string DualNationality{ get; set; }
          public string Name{ get; set; }
          public string Injured{ get; set; }
          public string Joined { get; set; }
          public string Scouted { get; set; }
          public string Forsale { get; set; }
          public string Listed { get; set; }
          public string Deadline { get; set; }
          public string AskingPrice { get; set; }
          public string Price { get; set; }
          public string BidTeamId { get; set; }
          public string NextBid { get; set; }

          public DateTime TransferDeadline { get; set; }

        #endregion

        #region Premium Properties
          public string ScoutingStars { get; set; }
        #endregion

        #region OwnerOnly

          public string Stamina { get; set; }
          public string Handling { get; set; }
          public string Attack { get; set; }
          public string Defense { get; set; }
          public string Technique { get; set; }
          public string Strength { get; set; }
          public string Jumping { get; set; }
          public string Speed { get; set; }
          public string Agility { get; set; }
          public string Kicking { get; set; }

         

        #endregion
    }
}