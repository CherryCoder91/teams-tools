using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TeamsTools.Services;

namespace TeamsTools
{
    public partial class MainWindow : Window
    {

        internal ITeamsKeepAliveService TeamsKeepAliveService { get; }

        public MainWindow(ITeamsKeepAliveService teamsKeepAliveService)
        {
            DataContext = this;
            InitializeComponent();
            TeamsKeepAliveService = teamsKeepAliveService;
            TeamsKeepAliveService.ActiveStateChanged += HandleTeamsAliveActiveStateChanged;
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
            TeamsKeepAliveService.ToggleTeamsAlive();
        }
        private void HandleTeamsAliveActiveStateChanged(object? sender, bool e)
        {
            ToggleTeamsKeepAliveButton.Foreground = e ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7f85f4")) : new SolidColorBrush(Colors.White);
        }
    }
}
