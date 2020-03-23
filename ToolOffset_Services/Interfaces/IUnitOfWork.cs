namespace ToolOffset_Services.Interfaces
{
    public interface IUnitOfWork
    {
        IBlockRepository Blocks { get; }
        IToolRepository Tools { get; }
        ITurretRepository Turret { get; }
    }
}
