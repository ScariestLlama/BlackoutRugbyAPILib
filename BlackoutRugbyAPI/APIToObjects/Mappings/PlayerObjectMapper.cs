using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APILib.Models;
using APIToObjects.Models;

namespace APIToObjects.Mappings
{
    public class PlayerObjectMapper
    {
        public List<Player> MapAll(IEnumerable<ApiPlayer> list)
        {
            return list.Select(player => new Player
            {
                Id = player.Id,
                Name = player.FirstName + " " + player.LastName,
                Stamina = Convert.ToInt32(player.Stamina),
                Handling = Convert.ToInt32(player.Handling),
                Attack = Convert.ToInt32(player.Attack),
                Defense = Convert.ToInt32(player.Defense),
                Technique = Convert.ToInt32(player.Technique),
                Strength = Convert.ToInt32(player.Strength),
                Jumping = Convert.ToInt32(player.Jumping),
                Speed = Convert.ToInt32(player.Speed),
                Agility = Convert.ToInt32(player.Agility),
                Kicking = Convert.ToInt32(player.Kicking),
                Form = Convert.ToInt32(player.Form),
                Aggression = Convert.ToInt32(player.Aggression),
                Discipline = Convert.ToInt32(player.Discipline),
                Energy = Convert.ToInt32(player.Energy),
                Leadership = Convert.ToInt32(player.Leadership),
                Experience = Convert.ToInt32(player.Experience),
                Weight = Convert.ToInt32(player.Weight),
                Height = Convert.ToInt32(player.Height),
                Csr = Convert.ToInt32(player.Csr),
                TransferDeadline = player.Deadline != "" ? MapperHelper.UnixTimeStampToDateTime(Convert.ToDouble(player.Deadline)) : DateTime.MaxValue
            }).ToList();
        }

        
    }
}
