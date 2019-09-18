using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Entities.Concrete
{
    public class Gamer
    {
        public Gamer()
        {
            GamerAbilities =new HashSet<GamerAbility>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int GamerAbilityId { get; set; }

        public virtual ICollection<GamerAbility> GamerAbilities { get; set; }
    }
}
