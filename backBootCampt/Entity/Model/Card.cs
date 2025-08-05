using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Card : BaseModel
    {
        public string cardName { get; set; }
        public decimal cylinderCapacity { get; set; }
        public decimal hP { get; set; }
        public decimal finalSpeed { get; set; }
        public decimal nOclylinder {  get; set; }
        public string weight { get; set; }
        public decimal torque { get; set; }
        public string conAtributos { get; set; }
        public string sinAtributos { get; set; }

        public ICollection<PlayerCard> PlayerCards { get; set; } = new List<PlayerCard>();
    }
}

