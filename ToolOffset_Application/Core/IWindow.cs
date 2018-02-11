using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolOffset_Application.Core
{
    public interface IWindow
    {
        object DataContext { get; set; }
    }
}
