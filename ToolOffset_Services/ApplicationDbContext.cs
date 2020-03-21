using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ToolOffset_Models.Models;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>()
                .HasMany(b => b.Positions)
                .WithRequired(p => p.Block)
                .HasForeignKey(p => p.BlockId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
