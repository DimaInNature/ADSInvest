using ADSInvest.ViewModels;
using System.Windows;

namespace ADSInvest.Views
{
    public partial class AuthorizationView : Window
    {
        public AuthorizationView() => InitializeComponent();

        private AuthorizationViewModel _viewModel => (AuthorizationViewModel)DataContext;

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PasswordBox.Password;
            _viewModel.SecurePassword = PasswordBox.SecurePassword;
        }

        private void ThisWindow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();
    }
}
