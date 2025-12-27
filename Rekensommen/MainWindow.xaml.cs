using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rekensommen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Range_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            bool succes = int.TryParse(textBox.Text, out int value);
            if (value < 0 || value > 100 || !succes)
            {
                textBox.Background = Brushes.LightCoral;
            }
            else
            {
                textBox.Background = Brushes.White;
            }
        }

        private void Range_KeyDown(object sender, KeyEventArgs e)
        {
            KeyEventArgs keyEventArgs = (KeyEventArgs)e;
            if (keyEventArgs.Key == Key.NumPad0 || keyEventArgs.Key == Key.NumPad1 
                || keyEventArgs.Key == Key.NumPad2 || keyEventArgs.Key == Key.NumPad3 
                || keyEventArgs.Key == Key.NumPad4 || keyEventArgs.Key == Key.NumPad5 
                || keyEventArgs.Key == Key.NumPad6 || keyEventArgs.Key == Key.NumPad7 
                || keyEventArgs.Key == Key.NumPad8 || keyEventArgs.Key == Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}