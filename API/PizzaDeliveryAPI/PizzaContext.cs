using Microsoft.EntityFrameworkCore;
using PizzaDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDeliveryAPI
{
    public class PizzaContext:DbContext
    {
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<Models.Object> Objects { get; set; }
        public DbSet<Object_type> Object_types { get; set; }
        public DbSet<Param> Params { get; set; }
        public PizzaContext(DbContextOptions<PizzaContext> options) :base(options)
        {        }
    }
}
