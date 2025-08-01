using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class CardDto : BaseDto
    {
        public string cardName {  get; set; }
        public decimal cylinderCapacity { get; set; }
        public int hP {  get; set; }
        public int finalSpeed { get; set; }
        public int nOclylinder {  get; set; }
        public bool status { get; set; }

        public List<CardDto> Card { get; set; } = new List<CardDto>();
        public List<Mallet> mallet { get; set; } = new List<Mallet>();
    }
}
