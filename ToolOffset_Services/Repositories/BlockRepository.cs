using System.Data.Entity;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.Repositories
{
    public class BlockRepository : BaseRepository<Block>, IBlockRepository
    {
        public BlockRepository(DbContext context) : base(context)
        {
        }
    }
}
