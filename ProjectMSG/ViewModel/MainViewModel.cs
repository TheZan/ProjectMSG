using DevExpress.Mvvm;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ProjectMSG.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private readonly PageService _pageService;

        public Page PageSource { get; set; }

        public MainViewModel(PageService pageService)
        {
            _pageService = pageService;


            _pageService.OnPageChanged += (page) => PageSource = page;
            _pageService.ChangePage(new Auth());
        }
    }
}
