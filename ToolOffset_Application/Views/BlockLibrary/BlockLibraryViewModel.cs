using ToolOffset_Application.Core;
using ToolOffset_Application.Views.BlockEdit;
using ToolOffset_Application.Views.BlockList;
using Unity;

namespace ToolOffset_Application.Views.BlockLibrary
{
    public class BlockLibraryViewModel : BaseViewModel, IBlockLibraryViewModel
    {
        public BlockLibraryViewModel()
        {
            LeftView = new BlockListView();
            RightView = new BlockEditView();
        }

        public BlockLibraryViewModel(IBlockLibraryView view, IUnityContainer container)
            : base(view, container)
        {
            LeftView = ShowView<IBlockListViewModel>();
            RightView = ShowView<IBlockEditViewModel>();
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
