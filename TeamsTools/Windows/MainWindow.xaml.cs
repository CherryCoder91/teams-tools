using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TeamsTools.Services;

namespace TeamsTools.Windows
{
    public partial class MainWindow : Window
    {

        internal ITeamsKeepAliveService TeamsKeepAliveService { get; }
        public TeamsViewportWindow TeamsViewportWindow { get; }

        public MainWindow(ITeamsKeepAliveService teamsKeepAliveService, TeamsViewportWindow teamsViewportWindow)
        {
            DataContext = this;
            InitializeComponent();
            TeamsKeepAliveService = teamsKeepAliveService;
            TeamsViewportWindow = teamsViewportWindow;
            TeamsKeepAliveService.ActiveStateChanged += HandleTeamsAliveActiveStateChanged;
            this.Loaded += new RoutedEventHandler(Window_Loaded);
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
            TeamsViewportWindow.Show();
        }

        private void ToggleTeamsKeepAliveButton_Click(object sender, RoutedEventArgs e)
        {
            TeamsKeepAliveService.ToggleTeamsAlive();
        }
        private void HandleTeamsAliveActiveStateChanged(object? sender, bool e)
        {
            ToggleTeamsKeepAliveButton.Foreground = e ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7f85f4")) : new SolidColorBrush(Colors.White);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width - 15;
            Top = desktopWorkingArea.Bottom - Height - 15;
        }
    }
}
