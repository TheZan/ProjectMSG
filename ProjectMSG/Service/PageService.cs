using System;
using System.Windows.Controls;
using ProjectMSG.View;

namespace ProjectMSG.Service
{
    public class PageService
    {

        public event Action<Page> OnPageChanged;
        public void ChangePage(Page page) => OnPageChanged?.Invoke(page);
    }
}
