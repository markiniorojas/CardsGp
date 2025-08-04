using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Base;

namespace Entity.Model
{
    public class PlayerCard : BaseModel
    {
        public bool isUsed { get; set; }
        public int gamePlayerId {  get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public GamePlayer GamePlayer { get; set; }
    }
}
