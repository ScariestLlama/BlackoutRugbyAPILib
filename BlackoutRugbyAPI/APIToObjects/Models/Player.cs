using System;

namespace APIToObjects.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stamina { get; set; }
        public int Handling { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Technique { get; set; }
        public int Strength { get; set; }
        public int Jumping { get; set; }
        public int Speed { get; set; }
        public int Agility { get; set; }
        public int Kicking { get; set; }

        public int Form { get; set; }
        public int Aggression { get; set; }
        public int Discipline { get; set; }
        public int Energy { get; set; }
        public int Leadership { get; set; }
        public int Experience { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public int Csr { get; set; }


        public DateTime TransferDeadline{set;get;}
    }
}