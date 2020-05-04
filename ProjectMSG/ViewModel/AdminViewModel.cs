using System.ComponentModel;
using DevExpress.Mvvm;
using ProjectMSG.Service;
using ProjectMSG.View;

namespace ProjectMSG.ViewModel
{
    public class AdminViewModel : BindableBase, INotifyPropertyChanged
    {
        public AdminViewModel(PageService pageService, MessageBus messageBus)
        {
            _pageService = pageService;
            _messageBus = messageBus;
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly MessageBus _messageBus;

        #endregion

        #region Command

        private RelayCommand selectSection;

        public RelayCommand SelectSection
        {
            get
            {
                return selectSection ??= new RelayCommand(async obj =>
                {
                    _pageService.ChangePage(new AdminSection());
                });
            }
        }

        private RelayCommand relogin;

        public RelayCommand Relogin
        {
            get { return relogin ??= new RelayCommand(async obj => { _pageService.ChangePage(new Auth()); }); }
        }

        #endregion
    }
}