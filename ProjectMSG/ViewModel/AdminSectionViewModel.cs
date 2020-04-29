using DevExpress.Mvvm;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectMSG.ViewModel
{
    public class AdminSectionViewModel : BindableBase, INotifyPropertyChanged
    {
        public AdminSectionViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
        {
            _pageService = pageService;
            _eventBus = eventBus;
            _messageBus = messageBus;
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly EventBus _eventBus;
        private readonly MessageBus _messageBus;

        #endregion

        #region Command

        private RelayCommand back;

        public RelayCommand Back
        {
            get
            {
                return back ??
                  (back = new RelayCommand(obj =>
                  {
                      _pageService.ChangePage(new Admin());
                  }));
            }
        }

        #endregion
    }
}
