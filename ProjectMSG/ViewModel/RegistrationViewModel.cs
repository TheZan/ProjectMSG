﻿using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Controls;
using DevExpress.Mvvm;
using ProjectMSG.Model;
using ProjectMSG.Service;
using ProjectMSG.View;

namespace ProjectMSG.ViewModel
{
    public class RegistrationViewModel : BindableBase, INotifyPropertyChanged
    {
        public RegistrationViewModel(PageService pageService, MessageBus messageBus)
        {
            _pageService = pageService;
            _messageBus = messageBus;
            LoadingVisability = false;
        }

        #region Command

        private RelayCommand registerUser;

        public RelayCommand RegisterUser
        {
            get
            {
                return registerUser ??
                       (registerUser = new RelayCommand(async obj =>
                       {
                           ControlDisable = false;
                           CompletedRegistration = false;
                           Password = GetPassword(obj);
                           await Task.Run(() => AddUserAsync());
                           Back();
                       }));
            }
        }

        private RelayCommand backToAuth;

        public RelayCommand BackToAuth
        {
            get
            {
                return backToAuth ??
                       (backToAuth = new RelayCommand(obj => { _pageService.ChangePage(new Auth()); }));
            }
        }

        #endregion

        #region Properties

        private readonly PageService _pageService;
        private readonly MessageBus _messageBus;

        private bool loadingVisability;

        public bool LoadingVisability
        {
            get => loadingVisability;
            set
            {
                loadingVisability = value;
                NotifyPropertyChanged();
            }
        }

        private bool completedRegistration;

        public bool CompletedRegistration
        {
            get => completedRegistration;
            set
            {
                completedRegistration = value;
                NotifyPropertyChanged("CompletedLogin");
            }
        }

        private bool controlDisable = true;

        public bool ControlDisable
        {
            get => controlDisable;
            set
            {
                controlDisable = value;
                NotifyPropertyChanged();
            }
        }

        private string warningText;

        public string WarningText
        {
            get => warningText;
            set
            {
                warningText = value;
                NotifyPropertyChanged();
            }
        }

        private string surname;

        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                NotifyPropertyChanged();
            }
        }

        private string firstname;

        public string Firstname
        {
            get => firstname;
            set
            {
                firstname = value;
                NotifyPropertyChanged();
            }
        }

        private string login;

        public string Login
        {
            get => login;
            set
            {
                login = value;
                NotifyPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void Back()
        {
            if (CompletedRegistration) _pageService.ChangePage(new Auth());
        }

        private string GetPassword(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            return password;
        }

        private async Task AddUserAsync()
        {
            LoadingVisability = true;
            if (Firstname != "" && Surname != "" && Login != "" && Password != "")
            {
                using (var db = new MSGCoreContext())
                {
                    if (db.Users.Where(p => p.Login == Login).Any())
                    {
                        WarningText = "Пользователь с таким логином уже существует!";
                        CompletedRegistration = false;
                    }
                    else
                    {
                        var registerUser = new Users
                        {
                            Firstname = Firstname,
                            Surname = Surname,
                            Login = Login,
                            Password = PBKDF2HashHelper.CreatePasswordHash(Password, 15000),
                            Role = "User"
                        };
                        await db.Users.AddAsync(registerUser).ConfigureAwait(false);
                        await db.SaveChangesAsync();
                        WarningText = "Регистрация прошла успешно!";
                        CompletedRegistration = true;
                    }
                }
            }
            else
            {
                WarningText = "Заполните все поля!";
                CompletedRegistration = false;
            }

            ControlDisable = true;
            LoadingVisability = false;
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