using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity.Base
{
    public class BaseDto
    {
        public int id { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;
    }
}
