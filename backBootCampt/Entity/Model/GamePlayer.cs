using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Base;

namespace Entity.Model
{
    public class GamePlayer : BaseModel
    {
        public int points {  get; set; }
        public int playersId { get; set; }
        public int GamesId { get; set; }
        public Player Player { get; set; }
        public Games Games { get; set; }
        public ICollection<PlayerCard> PlayerCards { get; set; } = new List<PlayerCard>();
    }
}
