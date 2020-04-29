﻿using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Model;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectMSG.ViewModel
{
    public class AuthViewModel : BindableBase, INotifyPropertyChanged
    {
        public AuthViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
        {
            _pageService = pageService;
            _eventBus = eventBus;
            _messageBus = messageBus;
            LoadingVisability = false;
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly EventBus _eventBus;
        private readonly MessageBus _messageBus;

        private Users user;
        private string userRole;
        private int userId;

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

        private string role;
        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
                NotifyPropertyChanged("Role");
            }
        }

        private string warning;
        public string Warning
        {
            get
            {
                return warning;
            }
            set
            {
                warning = value;
                NotifyPropertyChanged("Warning");
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

        private bool completedLogin;
        public bool CompletedLogin
        {
            get
            {
                return completedLogin;
            }
            set
            {
                completedLogin = value;
                NotifyPropertyChanged("CompletedLogin");
            }
        }

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

        #endregion

        #region Command

        private RelayCommand loginCommand;

        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                  (loginCommand = new RelayCommand(async obj =>
                  {
                      ControlDisable = false;
                      CompletedLogin = false;
                      LoadingVisability = true;
                      Password = GetPassword(obj);
                      await Task.Run(() => LoginUser());
                      OpenGeneral();
                  }));
            }
        }

        public ICommand RegistrationCommand => new DelegateCommand(() =>
        {
            _pageService.ChangePage(new Registration());
        });

        #endregion

        #region Methods

        private async Task LoginUser()
        {
            if (Login != "" && Password != "")
            {
                using (MSGCoreContext db = new MSGCoreContext())
                {
                    user = await db.Users.FirstOrDefaultAsync(u => u.Login == Login);

                    if (user != null)
                    {
                        userId = user.UserId;
                        userRole = user.Role;

                        if (PBKDF2HashHelper.VerifyPassword(Password, user.Password))
                        {
                            CompletedLogin = true;
                            LoadingVisability = false;
                        }
                        else { Warning = "Неверный логин или пароль!"; CompletedLogin = false; ControlDisable = true; LoadingVisability = false; }
                    }
                    else { Warning = "Пользователь не существует!"; CompletedLogin = false; ControlDisable = true; LoadingVisability = false; }
                }
            }
            else
            {
                Warning = "Заполните все поля!";
                CompletedLogin = false;
                ControlDisable = true;
                LoadingVisability = false;
            }
        }

        private string GetPassword(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            return password;
        }

        private void OpenGeneral()
        {
            
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
