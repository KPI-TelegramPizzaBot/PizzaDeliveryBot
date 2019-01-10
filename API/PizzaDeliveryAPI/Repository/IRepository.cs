using PizzaDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDeliveryAPI.Repository
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAll(); 
        T Get(int id); 
        void Delete(int id); 
        void Save();  
    }
}
