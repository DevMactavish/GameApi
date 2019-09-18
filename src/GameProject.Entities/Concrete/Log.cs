using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Entities.Concrete
{
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int WarId { get; set; }
    }
}
