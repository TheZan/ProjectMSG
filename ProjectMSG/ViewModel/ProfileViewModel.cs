using DevExpress.Mvvm;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Message;
using ProjectMSG.Model;

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
                Task.Run(GetUser);
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

        private string firstname;

        public string Firstname
        {
            get
            {
                return $"Имя: {firstname}";
            }
            set
            {
                firstname = value;
                NotifyPropertyChanged("Firstname");
            }
        }

        private string surname;

        public string Surname
        {
            get
            {
                return $"Фамилия: {surname}";
            }
            set
            {
                surname = value;
                NotifyPropertyChanged("Surname");
            }
        }

        private List<string> results = new List<string>();

        public List<string> Results
        {
            get { return results; }
            set
            {
                results = value;
                NotifyPropertyChanged("Results");
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
                });
            }
        }

        #endregion

        #region Methods

        private async Task GetUser()
        {
            using (MSGCoreContext db = new MSGCoreContext())
            {
                Firstname = await db.Users.Where(p => p.UserId == GetUserId).Select(p => p.Firstname)
                    .FirstOrDefaultAsync();
                Surname = await db.Users.Where(p => p.UserId == GetUserId).Select(p => p.Surname)
                    .FirstOrDefaultAsync();
                Results = db.Test.Where(p => p.Result.Select(p => p.TestId).First() == p.TestId && p.Result.Where(c => c.UserId == GetUserId).Select(p => p.UserId).First() == GetUserId).Select(p => p.TestName).ToList();
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

        public class GetResultUser
        {
            public string resultName { get; set; }
        }
    }
}
