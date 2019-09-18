using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Entities.Concrete
{
    public class War
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public State State { get; set; }
        public int BothHealth { get; set; }
        public int GamerId { get; set; }

        public virtual Gamer Gamer { get; set; }
    }
    public enum State
    {
        InProcess,
        Finished
    }
}
