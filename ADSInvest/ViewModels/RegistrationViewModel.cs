using ADSInvest.Data;
using ADSInvest.Models;
using ADSInvest.Services.Command;
using ADSInvest.ViewModels.Base;
using ADSInvest.Views;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace ADSInvest.ViewModels
{
    public sealed class RegistrationViewModel : BaseViewModel
    {
        public RegistrationViewModel()
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

        public ICommand BackButtonClickCommand { get; private set; }

        public ICommand RegistrationButtonClickCommand { get; private set; }

        public ICommand ShutdownAppButtonClickCommand { get; private set; }

        #endregion

        #endregion

        #region Methods

        #region Commands

        private void BackButtonClick(object obj)
        {
            var view = obj as RegistrationView;

            var displayRootRegistry = (System.Windows.Application.Current as Application).DisplayWindow;

            displayRootRegistry.Show(new AuthorizationViewModel());

            view.Close();
        }

        private void RegistrationButtonClick(object obj)
        {
            if (FieldsIsNotEmpty())
            {
                var newUser = new UserModel() { Login = Login, Password = Password, IsAdmin = false };

                var crudManager = new UserCRUD();

                if (crudManager.Create(newUser))
                {
                    var view = obj as RegistrationView;

                    var displayRootRegistry = (System.Windows.Application.Current as Application).DisplayWindow;

                    displayRootRegistry.Show(new MainViewModel());

                    view.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь не был создан", "Ошибка создания",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }   
            }
            else
            {
                MessageBox.Show("Поля не были заполнены.", "Ошибка ввода",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShutdownAppButtonClick(object obj) => Application.Current.Shutdown();

        #endregion

        private void InitialControlCondition()
        {
            _isPasswordWatermarkVisible = true;
        }

        private void InitialCommands()
        {
            BackButtonClickCommand = new DelegateCommandService(BackButtonClick);
            RegistrationButtonClickCommand = new DelegateCommandService(RegistrationButtonClick);
            ShutdownAppButtonClickCommand = new DelegateCommandService(ShutdownAppButtonClick);
        }

        #endregion

        private bool FieldsIsNotEmpty() => Login != string.Empty && Password != string.Empty;
    }
}
