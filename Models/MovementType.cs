using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioBTG.Models
{

    public class MovementType
    {
        public string Name { get; set; }
        public List<String> Weakness { get; set; }

        public MovementType(string name, List<String> weakness)
        {
            this.Name = name;
            this.Weakness = weakness;
        }
    }
}
