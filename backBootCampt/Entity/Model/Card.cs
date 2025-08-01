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
        public string cardName {  get; set; }
        public decimal cylinderCapacity { get; set; }
        public int hP {  get; set; }
        public int finalSpeed { get; set; }
        public int nOclylinder {  get; set; }
        public bool status { get; set; }

        public List<Card> card { get; set; } = new List<Card>();
        public List<Mallet> mallet { get; set; } = new List<Mallet>();
    }
}
