using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Services.Interfaces;
using ToolOffset_Services.Repositories;

namespace ToolOffset_Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBlockRepository BlockRepository { get; }
        public IToolRepository ToolRepository { get; }
        public ITurretRepository TurretRepository { get;}

        public UnitOfWork(IBlockRepository blockRepository, IToolRepository toolRepository, ITurretRepository turretRepository)
        {
            BlockRepository = blockRepository;
            ToolRepository = toolRepository;
            TurretRepository = turretRepository;
        }
    }
}
