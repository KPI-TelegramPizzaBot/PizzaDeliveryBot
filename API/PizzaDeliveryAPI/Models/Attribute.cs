using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDeliveryAPI.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Object_type ObjectType { get; set; }

        public IEnumerable<Param> Params { get; set; }
        public Attribute()
        {
            Params = new List<Param>();
        }
    }
}
