using DevExpress.Mvvm;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectMSG.ViewModel
{
    public class TestingViewModel : BindableBase, INotifyPropertyChanged
    {
        public TestingViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
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

        private RelayCommand selectContent;

        public RelayCommand SelectContent
        {
            get
            {
                return selectContent ??
                  (selectContent = new RelayCommand(obj =>
                  {
                      _pageService.ChangePage(new Content());
                  }));
            }
        }

        private RelayCommand selectTesting;

        public RelayCommand SelectTesting
        {
            get
            {
                return selectTesting ??
                  (selectTesting = new RelayCommand(obj =>
                  {
                      _pageService.ChangePage(new Testing());
                  }));
            }
        }

        private RelayCommand selectProfile;

        public RelayCommand SelectProfile
        {
            get
            {
                return selectProfile ??
                  (selectProfile = new RelayCommand(obj =>
                  {
                      _pageService.ChangePage(new Profile());
                  }));
            }
        }

        #endregion
    }
}
