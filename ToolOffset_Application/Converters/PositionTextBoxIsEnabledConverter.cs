using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using ToolOffset_Application.Views.BlockEdit;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Converters
{
    public class PositionTextBoxIsEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Position pos = value as Position;
            BlockEditViewModel viewModel = parameter as BlockEditViewModel;

            if (pos.BlockPosition.ID == viewModel.EditPositionID && viewModel.IsNotEditing == false)
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
