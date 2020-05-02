using DevExpress.Mvvm;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ProjectMSG.Message;

namespace ProjectMSG.ViewModel
{
    public class ProfileViewModel : BindableBase, INotifyPropertyChanged
    {
        public ProfileViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
        {
            _pageService = pageService;
            _eventBus = eventBus;
            _messageBus = messageBus;

            _messageBus.Receive<TextMessage>(this, async message =>
            {
                GetUserId = Convert.ToInt32(message.Text);
            });
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly EventBus _eventBus;
        private readonly MessageBus _messageBus;

        private int getUserId;

        public int GetUserId
        {
            get
            {
                return getUserId;
            }
            set
            {
                getUserId = value;
                NotifyPropertyChanged("GetUserId");
            }
        }

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

        #region ProperyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
