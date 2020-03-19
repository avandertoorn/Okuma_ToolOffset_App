using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ToolOffset_Models.Models;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Services
{
    public class ToolOffsetDbContext : DbContext
    {
        public DbSet<Block> Block { get; set; }
    }
}
