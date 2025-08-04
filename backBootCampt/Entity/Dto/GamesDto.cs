using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class GamesDto : BaseDto
    {
        public int winner { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
    }
}
