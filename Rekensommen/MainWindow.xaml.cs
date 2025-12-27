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
using System.Windows.Threading;

namespace Rekensommen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _random = new Random();
        int _expectedResult;
        DispatcherTimer _stopWatch = new DispatcherTimer();
        DateTime _stopWatchBegin;

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

        private void EqualsLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEventArgs mouseButtonEventArgs = (MouseButtonEventArgs)e;
            if (mouseButtonEventArgs.ChangedButton == MouseButton.Left)
            {
                StartExercise();
            }
        }

        private void StartExercise()
        {
            resultTextBox.Clear();
            resultTextBox.Background = Brushes.White;
            resultTextBox.IsEnabled = true;

            int number1 = 0;
            int number2 = 0;

            int.TryParse(firstNumberMinTextBox.Text, out int firstNumberMin);
            int.TryParse(firstNumberMaxTextBox.Text, out int firstNumberMax);
            int.TryParse(secondNumberMinTextBox.Text, out int secondNumberMin);
            int.TryParse(secondNumberMaxTextBox.Text, out int secondNumberMax);

            number1 = _random.Next(firstNumberMin, firstNumberMax++);
            number2 = _random.Next(secondNumberMin, secondNumberMax++);

            string sign = GetRandomOperator();

            switch (sign)
            {
                case "+":
                    _expectedResult = number1 + number2;
                    break;
                case "-": 
                    _expectedResult = number1 - number2;
                    break;
            }

            firstNumberLabel.Content = number1.ToString();
            operatorLabel.Content = sign;
            secondNumberLabel.Content = number2.ToString();

            InitStopWatch();

            resultTextBox.Focus();
        }

        private string GetRandomOperator()
        {
            if (addOperatorCheckBox.IsChecked == true 
                && subtractOperatorCheckBox.IsChecked == false)
            {
                return "+";
            }
            else if (addOperatorCheckBox.IsChecked == false
                && subtractOperatorCheckBox.IsChecked == true)
            {
                return "-";
            }
            else
            {
                int sign = _random.Next(0, 2);
                if (sign == 0)
                {
                    return "+";
                }
                else
                {
                    return "-";
                }
            }
        }

        private void InitStopWatch()
        {
            _stopWatch.Tick += new EventHandler(StopWatch_Tick);
            _stopWatch.Interval = TimeSpan.FromMilliseconds(1);
            _stopWatch.Start();
            _stopWatchBegin = DateTime.Now;
        }

        private void StopWatch_Tick(object sender, EventArgs e)
        {
            timerLabel.Content = (DateTime.Now - _stopWatchBegin).ToString(@"mm\:ss\.fff");
        }
    }
}