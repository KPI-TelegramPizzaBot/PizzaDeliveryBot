using Microsoft.EntityFrameworkCore;
using PizzaDeliveryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDeliveryAPI.Repository
{
    public class MetamodelRepository : IRepository<Pizza> 
    {
        private PizzaContext _context;

        public MetamodelRepository(PizzaContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _context.Object_types
                .Include(t => t.Objects)
                .ThenInclude(o => o.Params)
                .ThenInclude(v => v.Attribute)
                .SingleOrDefault(x => x.Name == "Pizza")
                .Objects
                .Select(x => _loadObject(x));
        }

        public Pizza Get(int id)
        {
            return _loadObject(_context.Objects
                .Include(o => o.Params)
                .ThenInclude(v => v.Attribute)
                .Single(x => x.Id == id));
        }

        public void SaveEntity(Pizza entity)
        {
            var type = _ensureTypeCreated();
            var obj = _context.Objects.Find(entity.Id);
            if (obj != null)
            {
                _saveExisting(entity, obj);
            }
            else
            {
                _saveNew(entity, type);
            }
        }

        private Object_type _ensureTypeCreated()
        {
            var className = typeof(Pizza).FullName;
            var item = _context.Object_types
                .Include(x => x.Attributes)
                .SingleOrDefault(x => x.Name == className);
            if (item != null) return item;

            item = new Object_type() { Name = className };
            _context.Object_types.Add(item);

            var props = typeof(Pizza)
                .GetProperties();
            var attributes = typeof(Pizza)
                .GetProperties()
                .Where(x => x.Name.ToLower() != "id")
                .Select(x => new Models.Attribute() { Name = x.Name })
                .ToArray();

            _context.Attributes.AddRange(attributes);
            return item;
        }

        private void _saveExisting(Pizza entity, Models.Object obj)
        {
            foreach (var value in obj.Params)
            {
                object attrVal = entity.GetType().GetProperty(value.Attribute.Name)?.GetValue(entity);
                value.Data = attrVal.ToString();
            }
        }

        private void _saveNew(Pizza entity, Models.Object_type type)
        {
            var obj = new Models.Object();
            _context.Objects.Add(obj);
            entity.Id = obj.Id;
            foreach (var attribute in type.Attributes)
            {
                object attrVal = entity.GetType().GetProperty(attribute.Name).GetValue(entity);
                var value = new Param()
                {
                    Attribute = attribute,
                    Data = attrVal.ToString(),
                    Object = obj
                };
                _context.Params.Add(value);
            }
        }

        private Pizza _loadObject(Models.Object obj)
        {
            if (obj is null) return null;
            var entity = new Pizza();
            entity.Id = obj.Id;
            foreach (var val in obj.Params)
            {
                var prop = entity.GetType().GetProperty(val.Attribute.Name);
                //prop.SetValue(entity, new object[] { prop.PropertyType, val.Data });
                try
                {
                    prop.SetValue(entity, Convert.ToInt32(val.Data));
                }
                catch
                {
                    prop.SetValue(entity, val.Data);
                }
            }
            return entity;
        }

        public void Delete(int id)
        {
            var found = _context.Objects.Single(x => x.Id == id);
            _context.Remove(found);
        }
        
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
