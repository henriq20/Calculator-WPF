using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _lastNumber;
        private double _result;

        public MainWindow()
        {
            InitializeComponent();

            btnAc.Click += BtnAc_Click;
            btnNegative.Click += BtnNegative_Click;
            btnPercentage.Click += BtnPercentage_Click;
            btnEqual.Click += BtnEqual_Click;
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
             
        }

        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out _lastNumber))
            {
                _lastNumber /= 100;
                lblResult.Content = _lastNumber.ToString();
            }
        }

        private void BtnNegative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out _lastNumber))
            {
                _lastNumber *= -1;
                lblResult.Content = _lastNumber.ToString();
            }
        }

        private void BtnAc_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;

            if (double.TryParse(lblResult.Content.ToString(), out _lastNumber))
            {
                lblResult.Content = "0";
            }
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            int selectedValue = int.Parse(selectedButton.Content.ToString());

            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = $"{selectedValue}";
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }
    }
}
