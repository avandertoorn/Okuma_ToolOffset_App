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
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ToolOffset> Offsets { get; set; }

        public ApplicationDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>()
                .HasMany(b => b.Positions)
                .WithRequired(p => p.Block)
                .HasForeignKey(p => p.BlockId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Tool>()
                .HasMany(t => t.ToolOffsets)
                .WithRequired(o => o.Tool)
                .HasForeignKey(o => o.ToolId)
                .WillCascadeOnDelete(true);

            modelBuilder.Types<ToolOffset>().Configure(ctc => ctc.Property(o => o.Offset.Length).HasColumnName("Length"));
            modelBuilder.Types<ToolOffset>().Configure(ctc => ctc.Property(o => o.Offset.LengthType).HasColumnName("LengthType"));
            modelBuilder.Types<ToolOffset>().Configure(ctc => ctc.Property(o => o.Offset.Width).HasColumnName("Width"));
            modelBuilder.Types<ToolOffset>().Configure(ctc => ctc.Property(o => o.Offset.XRadiusOffset).HasColumnName("XRadiusOffset"));
            modelBuilder.Types<ToolOffset>().Configure(ctc => ctc.Property(o => o.Offset.ZRadiusOffset).HasColumnName("ZRadiusOffset"));
            modelBuilder.Types<ToolOffset>().Configure(ctc => ctc.Property(o => o.Offset.RadiusCompPattern).HasColumnName("RadiusCompPattern"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
