using DevExpress.Mvvm;
using ProjectMSG.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectMSG.ViewModel
{
    public class ContentViewModel : BindableBase, INotifyPropertyChanged
    {
        public ContentViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
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
    }
}
