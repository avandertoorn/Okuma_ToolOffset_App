using ToolOffset_Services.Interfaces;

namespace ToolOffset_Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBlockRepository blockRepository,
            IToolRepository toolRepository, ITurretRepository turretRepository)
        {
            Blocks = blockRepository;
            Tools = toolRepository;
            Turret = turretRepository;
        }

        public IBlockRepository Blocks { get; }
        public IToolRepository Tools { get; }
        public ITurretRepository Turret { get; }
    }
}
