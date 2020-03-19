using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        public BlockRepository()
        {
            _context = new ToolOffsetDbContext();
            List<Block> blocks = _context.Block.ToList();
        }

        private ToolOffsetDbContext _context;

        public void Add(Block item)
        {
            
        }

        public void Delete(int id)
        {
        }

        public Block Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Block> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Block item)
        {

        }
    }
}
