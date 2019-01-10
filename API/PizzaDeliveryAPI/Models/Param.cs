using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDeliveryAPI.Models
{
    public class Param
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public Attribute Attribute { get; set; }
        public Object Object { get; set; }
    }
}
