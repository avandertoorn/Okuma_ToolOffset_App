using System;
using System.Collections.Generic;
using System.Data.Entity;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class TurretRepository :ITurretRepository
    {
        public TurretRepository(ApplicationDbContext context)
        {
        }

        public void Add(Turret entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Turret> entities)
        {
            throw new NotImplementedException();
        }

        public Turret Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Turret> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Turret entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Turret> entities)
        {
            throw new NotImplementedException();
        }
    }
}
