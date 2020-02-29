using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBlockRepository blockRepository,
            IToolRepository toolRepository, ITurretRepository turretRepository)
        {
            BlockRepository = blockRepository;
            ToolRepository = toolRepository;
            TurretRepository = turretRepository;
        }

        public IBlockRepository BlockRepository { get; }
        public IToolRepository ToolRepository { get; }
        public ITurretRepository TurretRepository { get; }
    }
}
