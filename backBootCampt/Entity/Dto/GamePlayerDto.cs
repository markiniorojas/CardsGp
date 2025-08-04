using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Base;

namespace Entity.Dto
{
    public class GamePlayerDto : BaseDto
    {
        public int points { get; set; }
        public string userName { get; set; }


    }
}
