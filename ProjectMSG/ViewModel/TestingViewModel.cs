using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Message;
using ProjectMSG.Model;
using ProjectMSG.Service;
using ProjectMSG.View;

namespace ProjectMSG.ViewModel
{
    public class TestingViewModel : BindableBase, INotifyPropertyChanged
    {
        public TestingViewModel(PageService pageService, MessageBus messageBus)
        {
            _pageService = pageService;
            _messageBus = messageBus;

            _messageBus.Receive<TextMessage>(this, async message => { GetUserId = Convert.ToInt32(message.Text); });

            Task.Run(GetTest);
        }

        #region Methods

        private async Task GetTest()
        {
            using (var db = new MSGCoreContext())
            {
                Tests = await db.Test.ToListAsync();
            }
        }

        #endregion

        #region Properties

        private readonly PageService _pageService;
        private readonly MessageBus _messageBus;

        private TakeTest takeTest;

        private int getUserId;

        public int GetUserId
        {
            get => getUserId;
            set
            {
                getUserId = value;
                NotifyPropertyChanged();
            }
        }

        private Test selectTest = new Test();

        public Test SelectTest
        {
            get => selectTest;
            set
            {
                selectTest = value;
                NotifyPropertyChanged();
            }
        }

        public int TestId
        {
            get => SelectTest.TestId;
            set
            {
                SelectTest.TestId = value;
                NotifyPropertyChanged();
            }
        }

        public string TestName
        {
            get => SelectTest.TestName;
            set
            {
                SelectTest.TestName = value;
                NotifyPropertyChanged();
            }
        }

        private List<Test> tests;

        public List<Test> Tests
        {
            get => tests;
            set
            {
                tests = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        private RelayCommand selectContent;

        public RelayCommand SelectContent
        {
            get { return selectContent ??= new RelayCommand(obj => { _pageService.ChangePage(new Content()); }); }
        }

        private RelayCommand selectTesting;

        public RelayCommand SelectTesting
        {
            get { return selectTesting ??= new RelayCommand(obj => { _pageService.ChangePage(new Testing()); }); }
        }

        private RelayCommand selectProfile;

        public RelayCommand SelectProfile
        {
            get
            {
                return selectProfile ??= new RelayCommand(obj =>
                {
                    _pageService.ChangePage(new Profile());
                    _messageBus.SendTo<ProfileViewModel>(new TextMessage(GetUserId.ToString()));
                });
            }
        }

        private RelayCommand goToTest;

        public RelayCommand GoToTest
        {
            get
            {
                return goToTest ??= new RelayCommand(async obj =>
                {
                    takeTest = new TakeTest(TestId, getUserId);
                    if (takeTest.ShowDialog() == true)
                        _messageBus.SendTo<ProfileViewModel>(new TextMessage(GetUserId.ToString()));
                });
            }
        }

        #endregion

        #region ProperyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}