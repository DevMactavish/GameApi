using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Entities.Concrete
{
    public class GamerAbility
    {
        public int Id { get; set; }
        public int AbilityId { get; set; }
        public int GamerId { get; set; }

        public Ability Ability { get; set; }
        public Gamer Gamer { get; set; }
    }
}
