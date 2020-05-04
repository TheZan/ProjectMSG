using DevExpress.Mvvm;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Message;
using ProjectMSG.Model;

namespace ProjectMSG.ViewModel
{
    public class TestingViewModel : BindableBase, INotifyPropertyChanged
    {
        public TestingViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
        {
            _pageService = pageService;
            _eventBus = eventBus;
            _messageBus = messageBus;

            _messageBus.Receive<TextMessage>(this, async message =>
            {
                GetUserId = Convert.ToInt32(message.Text);
            });

            Task.Run(GetTest);
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly EventBus _eventBus;
        private readonly MessageBus _messageBus;

        private TakeTest takeTest;

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

        private Test selectTest = new Test();
        public Test SelectTest
        {
            get
            {
                return selectTest;
            }
            set
            {
                selectTest = value;
                NotifyPropertyChanged("SelectTest");
            }
        }

        public int TestId
        {
            get
            {
                return SelectTest.TestId;
            }
            set
            {
                SelectTest.TestId = value;
                NotifyPropertyChanged("TestId");
            }
        }

        public string TestName
        {
            get
            {
                return SelectTest.TestName;
            }
            set
            {
                SelectTest.TestName = value;
                NotifyPropertyChanged("TestName");
            }
        }

        private List<Test> tests;
        public List<Test> Tests
        {
            get
            {
                return tests;
            }
            set
            {
                tests = value;
                NotifyPropertyChanged("Tests");
            }
        }

        #endregion

        #region Command

        private RelayCommand selectContent;

        public RelayCommand SelectContent
        {
            get
            {
                return selectContent ??= new RelayCommand(obj =>
                {
                    _pageService.ChangePage(new Content());
                });
            }
        }

        private RelayCommand selectTesting;

        public RelayCommand SelectTesting
        {
            get
            {
                return selectTesting ??= new RelayCommand(obj =>
                {
                    _pageService.ChangePage(new Testing());
                });
            }
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
                    {
                        _messageBus.SendTo<ProfileViewModel>(new TextMessage(GetUserId.ToString()));
                    }
                });
            }
        }

        #endregion

        #region Methods

        private async Task GetTest()
        {
            using (MSGCoreContext db = new MSGCoreContext())
            {
                Tests = await db.Test.ToListAsync();
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
