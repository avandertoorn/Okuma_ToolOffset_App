using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ToolOffset_Models.Models;

namespace ToolOffset_Services
{
    public class ToolOffsetDbContext : DbContext
    {
        public DbSet<ToolOffset> Offsets { get; set; }
    }
}
