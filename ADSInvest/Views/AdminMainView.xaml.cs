using System.Windows;
using System.Windows.Input;

namespace ADSInvest.Views
{
    public partial class AdminMainView : Window
    {
        public AdminMainView() => InitializeComponent();

        private void ThisWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}
