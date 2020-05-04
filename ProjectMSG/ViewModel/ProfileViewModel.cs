using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    public class ProfileViewModel : BindableBase, INotifyPropertyChanged
    {
        public ProfileViewModel(PageService pageService, MessageBus messageBus)
        {
            _pageService = pageService;
            _messageBus = messageBus;

            _messageBus.Receive<TextMessage>(this, async message =>
            {
                GetUserId = Convert.ToInt32(message.Text);
                Task.Run(GetUser);
            });
        }

        #region Methods

        private async Task GetUser()
        {
            using (var db = new MSGCoreContext())
            {
                Firstname = await db.Users.Where(p => p.UserId == GetUserId).Select(p => p.Firstname)
                    .FirstOrDefaultAsync();
                Surname = await db.Users.Where(p => p.UserId == GetUserId).Select(p => p.Surname)
                    .FirstOrDefaultAsync();
                Results = db.Test
                    .Where(p => p.Result.Select(p => p.TestId).First() == p.TestId &&
                                p.Result.Where(c => c.UserId == GetUserId).Select(p => p.UserId).First() == GetUserId)
                    .Select(p => p.TestName).ToList();
            }
        }

        #endregion

        public class GetResultUser
        {
            public string resultName { get; set; }
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly MessageBus _messageBus;

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

        private string firstname;

        public string Firstname
        {
            get => $"Имя: {firstname}";
            set
            {
                firstname = value;
                NotifyPropertyChanged();
            }
        }

        private string surname;

        public string Surname
        {
            get => $"Фамилия: {surname}";
            set
            {
                surname = value;
                NotifyPropertyChanged();
            }
        }

        private List<string> results = new List<string>();

        public List<string> Results
        {
            get => results;
            set
            {
                results = value;
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
            get { return selectProfile ??= new RelayCommand(obj => { _pageService.ChangePage(new Profile()); }); }
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