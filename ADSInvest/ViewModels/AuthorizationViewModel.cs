using ADSInvest.Data;
using ADSInvest.Services.Command;
using ADSInvest.Services.Data;
using ADSInvest.ViewModels.Base;
using ADSInvest.Views;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace ADSInvest.ViewModels
{
    public sealed class AuthorizationViewModel : BaseViewModel
    {
        public AuthorizationViewModel()
        {
            InitialControlCondition();
            InitialCommands();
        }

        #region Properties

        #region Auth Props

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _login = string.Empty;

        public SecureString SecurePassword
        {
            get => _securePassword;
            set
            {
                _securePassword = value;
                OnPropertyChanged("SecurePassword");
            }
        }

        private SecureString _securePassword;

        public unsafe string Password
        {
            [SecurityCritical]
            get
            {
                if (SecurePassword != null)
                {
                    SecureString securePassword = SecurePassword;
                    IntPtr intPtr = Marshal.SecureStringToBSTR(securePassword);
                    return new string((char*)(void*)intPtr);
                }
                return String.Empty;
            }
            [SecurityCritical]
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                using (SecureString secureString = new SecureString())
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        secureString.AppendChar(value[i]);
                    }
                }
                _password = value;
                IsPasswordWatermarkVisible = string.IsNullOrEmpty(_password);
            }
        }

        private string _password;

        #endregion

        #region Control Condition

        public bool IsPasswordWatermarkVisible
        {
            get => _isPasswordWatermarkVisible;
            set
            {
                if (value.Equals(_isPasswordWatermarkVisible)) return;
                _isPasswordWatermarkVisible = value;
                OnPropertyChanged("IsPasswordWatermarkVisible");
            }
        }

        private bool _isPasswordWatermarkVisible;

        #endregion

        #region Commands

        public ICommand AuthorizationButtonClickCommand { get; private set; }

        public ICommand RegistrationButtonClickCommand { get; private set; }

        public ICommand ShutdownAppButtonClickCommand { get; private set;}

        #endregion

        #endregion

        #region Methods

        #region Commands

        private void AuthorizationButtonClick(object obj)
        {
            if (FieldsIsNotEmpty())
            {
                if (AuthorizationService.UserIsExist(Login, Password))
                {
                    var activeUser = AuthorizationService.FindByLoginAndPassword(Login, Password);

                    if (activeUser.IsAdmin)
                    {
                        var view = obj as AuthorizationView;

                        var displayRootRegistry = (Application.Current as Application).DisplayWindow;

                        displayRootRegistry.Show(new AdminMainViewModel());

                        view.Close();
                    }
                    else
                    {
                        var view = obj as AuthorizationView;

                        var displayRootRegistry = (Application.Current as Application).DisplayWindow;

                        displayRootRegistry.Show(new MainViewModel());

                        view.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Пользователя с таким логином и паролем не существует.", "Ошибка авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Поля не были заполнены.", "Ошибка ввода",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegistrationButtonClick(object obj)
        {
            var view = obj as AuthorizationView;

            var displayRootRegistry = (System.Windows.Application.Current as Application).DisplayWindow;

            displayRootRegistry.Show(new RegistrationViewModel());

            view.Close();
        }

        private void ShutdownAppButtonClick(object obj) => System.Windows.Application.Current.Shutdown();

        #endregion

        private void InitialControlCondition()
        {
            _isPasswordWatermarkVisible = true;
        }

        private void InitialCommands()
        {
            AuthorizationButtonClickCommand = new DelegateCommandService(AuthorizationButtonClick);
            RegistrationButtonClickCommand = new DelegateCommandService(RegistrationButtonClick);
            ShutdownAppButtonClickCommand = new DelegateCommandService(ShutdownAppButtonClick);
        }

        private bool FieldsIsNotEmpty() => Login != string.Empty && Password != string.Empty;

        #endregion
    }
}