using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Player : BaseModel
    {
        public string userName { get; set; }
        public bool IsEnabled { get; set; } = false;
        public ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();

    }
}
