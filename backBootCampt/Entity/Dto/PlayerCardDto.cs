using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Base;

namespace Entity.Dto
{
    public class PlayerCardDto : BaseDto
    {
        public bool isUsed { get; set; }
        public string userName { get; set; }
        public string cardName { get; set; }
        public decimal cylinderCapacity { get; set; }
        public decimal hP { get; set; }
        public decimal finalSpeed { get; set; }
        public decimal nOclylinder { get; set; }
        public string weight { get; set; }
        public decimal torque { get; set; }
        public string conAtributos { get; set; }
        public string sinAtributos { get; set; }
    }
}
