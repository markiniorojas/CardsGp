using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class PlayerDto : BaseDto
    {
        public string userName { get; set; }
        public int itemsEntered { get; set; }

        public Games Games { get; set; }
    }
}
