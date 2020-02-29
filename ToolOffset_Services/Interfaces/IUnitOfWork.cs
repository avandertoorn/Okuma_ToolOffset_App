namespace ToolOffset_Services.Interfaces
{
    public interface IUnitOfWork
    {
        IBlockRepository BlockRepository { get; }
        IToolRepository ToolRepository { get; }
        ITurretRepository TurretRepository { get; }
    }
}
