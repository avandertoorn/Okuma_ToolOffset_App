using System.Collections.Generic;
using System.Data.Entity;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class ToolRepository : IToolRepository
    {
        public ToolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private ApplicationDbContext _context;

        public void Add(Tool entity)
        {
            _context.Tools.Add(entity);
        }

        public void AddRange(IEnumerable<Tool> entities)
        {
            _context.Tools.AddRange(entities);
        }

        public Tool Get(int id)
        {
            var tool = _context.Tools.Find(id);
            if (tool != null)
                _context.Entry(tool).Collection(t => t.ToolOffsets).Load();
            return tool;
        }
 
        public IEnumerable<Tool> GetAll()
        {
            return _context.Tools.Include(t => t.ToolOffsets);
        }

        public void Remove(Tool entity)
        {
            _context.Tools.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Tool> entities)
        {
            _context.Tools.RemoveRange(entities);
        }
    }
}
