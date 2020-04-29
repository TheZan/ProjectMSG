using DevExpress.Mvvm;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectMSG.ViewModel
{
    public class AdminViewModel : BindableBase, INotifyPropertyChanged
    {
        public AdminViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
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

        private RelayCommand selectSection;

        public RelayCommand SelectSection
        {
            get
            {
                return selectSection ??
                  (selectSection = new RelayCommand(obj =>
                  {
                      _pageService.ChangePage(new AdminSection());
                  }));
            }
        }

        #endregion
    }
}
