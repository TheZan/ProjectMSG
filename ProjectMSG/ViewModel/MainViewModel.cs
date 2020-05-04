using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DevExpress.Mvvm;
using ProjectMSG.Service;
using ProjectMSG.View;

namespace ProjectMSG.ViewModel
{
    public class MainViewModel : BindableBase, INotifyPropertyChanged
    {
        private readonly PageService _pageService;

        public MainViewModel(PageService pageService)
        {
            _pageService = pageService;


            _pageService.OnPageChanged += page => PageSource = page;
            _pageService.ChangePage(new Auth());
        }

        public Page PageSource { get; set; }

        #region Properties

        private bool topMenuVisability;

        public bool TopMenuVisability
        {
            get => topMenuVisability;
            set
            {
                topMenuVisability = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}