using System.Data.Entity;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class ToolRepository : BaseRepository<Tool>, IToolRepository
    {
        public ToolRepository(DbContext context) : base(context)
        {
        }
    }
}
