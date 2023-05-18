using System.Windows;
using System.Windows.Input;

namespace TeamsTools
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowTeamsViewportButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void ToggleTeamsKeepAliveButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }
    }
}
