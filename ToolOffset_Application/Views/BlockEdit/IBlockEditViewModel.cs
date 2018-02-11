using ToolOffset_Application.Core;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Views.BlockEdit
{
    public interface IBlockEditViewModel : IViewModel
    {
        BlockAssembly BlockAssembly { get; set; }
        int EditPositionID { get; set; }
        string Title { get; }
    }
}