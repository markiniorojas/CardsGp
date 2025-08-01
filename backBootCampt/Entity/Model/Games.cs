using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Games : BaseModel
    {
        public int winner { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public DateTime date { get; set; }

        public List<Player> players { get; set; } = new List<Player>();

        public Card Card { get; set; }
    }
}
