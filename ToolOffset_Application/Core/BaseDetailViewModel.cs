using Unity;

namespace ToolOffset_Application.Core
{
    public class BaseDetailViewModel : BaseViewModel, IDetailViewModel
    {
        public BaseDetailViewModel() { }

        public BaseDetailViewModel(IView view, IUnityContainer container)
            : base(view, container)
        {

        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }
    }
}
