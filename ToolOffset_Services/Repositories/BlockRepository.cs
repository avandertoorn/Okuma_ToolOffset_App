using System.Collections.Generic;
using System.Data.Entity;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        public BlockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private ApplicationDbContext _context;

        public void Add(Block entity)
        {
            _context.Blocks.Add(entity);
        }

        public void AddRange(IEnumerable<Block> entities)
        {
            _context.Blocks.AddRange(entities);
        }

        public Block Get(int id)
        {
            var block = _context.Blocks.Find(id);
            if (block != null)
                _context.Entry(block).Collection(b => b.Positions).Load();
            return block;
        }

        public IEnumerable<Block> GetAll()
        {
            return _context.Blocks.Include(b => b.Positions);
        }

        public void Remove(Block entity)
        {
            _context.Blocks.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Block> entities)
        {
            _context.Blocks.RemoveRange(entities);
        }
    }
}
