using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class RoundResultDto
    {
        public GamePlayerDto Winner { get; set; }
        public GamePlayerDto NextPlayer { get; set; }
        public string Message { get; set; } // ✅ Nuevo campo para notificar final de juego
    }

}
