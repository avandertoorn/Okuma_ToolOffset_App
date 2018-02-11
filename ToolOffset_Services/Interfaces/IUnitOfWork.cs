using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolOffset_Services.Interfaces
{
    public interface IUnitOfWork
    {
        IBlockRepository BlockRepository { get; }
        IToolRepository ToolRepository { get; }
        ITurretRepository TurretRepository { get; }
    }
}
