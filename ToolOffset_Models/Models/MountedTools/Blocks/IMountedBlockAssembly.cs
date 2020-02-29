using System.Collections.ObjectModel;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Models.Models.MountedTools.Positions;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.MountedTools.Blocks
{
    public interface IMountedBlockAssembly
    {
        Station Station { get; }
        Block Block { get; }
        ObservableCollection<IMountedPosition> Positions { get; }
        BlockOrientation BlockOrientation { get; }
        void RemovePosition(IMountedPosition position);
        void AddPosition(Position position);
    }
}
