using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDeliveryAPI.Models
{
    public class Object_type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Object> Objects { get; set; }
        public IEnumerable<Attribute> Attributes { get; set; }

        public Object_type()
        {
            Objects = new List<Object>();
            Attributes = new List<Attribute>();
        }
    }
}
