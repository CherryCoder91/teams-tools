using System.Windows;
using System.Windows.Input;

namespace TeamsTools.Windows
{
    public partial class TeamsViewportWindow : Window
    {
        public TeamsViewportWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
