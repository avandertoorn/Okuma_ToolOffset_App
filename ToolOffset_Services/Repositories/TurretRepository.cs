using System;
using System.Collections.Generic;
using System.Data.Entity;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class TurretRepository : BaseRepository<Turret>, ITurretRepository
    {
        public TurretRepository(DbContext context) : base(context)
        {
        }
    }
}
