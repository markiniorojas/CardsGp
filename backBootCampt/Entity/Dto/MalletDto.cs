using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class MalletDto : BaseDto
    {
        public string typesDecks {  get; set; }
        public CardDto Card { get; set; }
    }
}
