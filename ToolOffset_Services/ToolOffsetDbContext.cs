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
        //public ToolOffsetDbContext() : base()
        //{
        //    this.Configuration.LazyLoadingEnabled = false;
        //}
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Position> Positions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>()
                .HasMany(Block.ORMappings.Positions);

            //modelBuilder.Entity<Position>()
            //    .HasRequired<Block>(p => p.Block)
            //    .WithMany(Block.PositionMapping)
            //    .HasForeignKey(p => p.BlockId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
