using ToolOffset_Application.Core;
using ToolOffset_Application.Views.ToolEdit;
using ToolOffset_Application.Views.ToolList;
using Unity;

namespace ToolOffset_Application.Views.ToolLibrary
{
    public class ToolLibraryViewModel : BaseViewModel, IToolLibraryViewModel
    {
        public ToolLibraryViewModel()
        {

        }

        public ToolLibraryViewModel(IToolLibraryView view, IUnityContainer container)
            : base(view, container)
        {
            LeftView = ShowView<IToolListViewModel>();
            RightView = ShowView<IToolEditViewModel>();
        }

        private IView _lefView;
        private IView _rightView;

        public IView LeftView
        {
            get { return _lefView; }
            set
            {
                if (_lefView != value)
                {
                    _lefView = value;
                    OnPropertyChanged("LeftView");
                }
            }
        }

        public IView RightView
        {
            get { return _rightView; }
            set
            {
                if (_rightView != value)
                {
                    _rightView = value;
                    OnPropertyChanged("RightView");
                }
            }
        }

        private IView ShowView<T>() where T : IViewModel
        {
            return Container.Resolve<T>().View;
        }
    }
}
