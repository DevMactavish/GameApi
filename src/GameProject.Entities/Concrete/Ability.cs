using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Entities.Concrete
{
    public class Ability
    {
        public int Id { get; set; }
        public AbilityType Type { get; set; }
        public int Damage { get; set; }
    }
    public enum AbilityType
    {
        StraightStroke,
        Ability1,
        Ability2,

    }
}
