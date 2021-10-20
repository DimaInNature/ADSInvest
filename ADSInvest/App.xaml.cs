using ADSInvest.Services;
using ADSInvest.ViewModels;
using ADSInvest.Views;
using System.Windows;

namespace ADSInvest
{
    public partial class Application : System.Windows.Application
    {
        public DisplayWindowService DisplayWindow { get; private set; } = new DisplayWindowService();

        public Application() => RegisterWindows();
        
        private void RegisterWindows()
        {
            DisplayWindow.RegisterWindow<AdminMainViewModel, AdminMainView>();
            DisplayWindow.RegisterWindow<MainViewModel, MainView>();
            DisplayWindow.RegisterWindow<AuthorizationViewModel, AuthorizationView>();
            DisplayWindow.RegisterWindow<RegistrationViewModel, RegistrationView>();
        }
    }
}
