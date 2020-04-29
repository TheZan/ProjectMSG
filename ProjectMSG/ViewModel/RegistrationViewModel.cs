using DevExpress.Mvvm;
using ProjectMSG.Model;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectMSG.ViewModel
{
    public class RegistrationViewModel : BindableBase, INotifyPropertyChanged
    {
        public RegistrationViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
        {
            _pageService = pageService;
            _eventBus = eventBus;
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

        public ICommand BackToAuth => new AsyncCommand(async () =>
        {
            _pageService.ChangePage(new Auth());
        });

        #endregion

        #region Properties

        private readonly PageService _pageService;
        private readonly EventBus _eventBus;
        private readonly MessageBus _messageBus;

        private bool loadingVisability;
        public bool LoadingVisability
        {
            get
            {
                return loadingVisability;
            }
            set
            {
                loadingVisability = value;
                NotifyPropertyChanged("LoadingVisability");
            }
        }

        private bool completedRegistration;
        public bool CompletedRegistration
        {
            get
            {
                return completedRegistration;
            }
            set
            {
                completedRegistration = value;
                NotifyPropertyChanged("CompletedLogin");
            }
        }

        private bool controlDisable = true;
        public bool ControlDisable
        {
            get
            {
                return controlDisable;
            }
            set
            {
                controlDisable = value;
                NotifyPropertyChanged("ControlDisable");
            }
        }

        private string warningText;
        public string WarningText
        {
            get
            {
                return warningText;
            }
            set
            {
                warningText = value;
                NotifyPropertyChanged("WarningText");
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                NotifyPropertyChanged("Surname");
            }
        }

        private string firstname;
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                NotifyPropertyChanged("Firstname");
            }
        }

        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                NotifyPropertyChanged("Login");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        #endregion

        #region Methods

        private void Back()
        {
            if (CompletedRegistration)
            {
                _pageService.ChangePage(new Auth());
            }
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
                using (MSGCoreContext db = new MSGCoreContext())
                {
                    if (db.Users.Where(p => p.Login == Login).Any())
                    {
                        WarningText = "Пользователь с таким логином уже существует!";
                        CompletedRegistration = false;
                    }
                    else
                    {
                        Users registerUser = new Users
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
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
