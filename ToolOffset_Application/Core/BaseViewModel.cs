﻿using Unity;

namespace ToolOffset_Application.Core
{
    public class BaseViewModel : BaseNotification, IViewModel
    {
        public BaseViewModel() { }

        public BaseViewModel(IView view, IUnityContainer container)
        {
            View = view;
            View.DataContext = this;

            Container = container;
        }

        public IView View { get; set; }
        public IUnityContainer Container { get; set; }
    }
}
