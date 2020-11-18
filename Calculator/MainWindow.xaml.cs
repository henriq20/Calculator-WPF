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
        private SelectedOperator _selectedOperator;

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
            double newNumber;

            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                switch (_selectedOperator)
                {

                    case SelectedOperator.Addtion:
                        _result = SimpleMath.Add(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        _result = SimpleMath.Subtraction(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        _result = SimpleMath.Multiply(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        _result = SimpleMath.Divide(_lastNumber, newNumber);
                        break;
                }

                lblResult.Content = _result.ToString();
            }
        }

        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(lblResult.Content.ToString(), out tempNumber))
            {
                tempNumber /= 100;

                if (_lastNumber != 0)
                    tempNumber *= _lastNumber;

                lblResult.Content = tempNumber.ToString();
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
            _result = 0;
            _lastNumber = 0;
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out _lastNumber))
            {
                lblResult.Content = "0";
            }

            if (sender == btnMultiplication)
                _selectedOperator = SelectedOperator.Multiplication;
            else if (sender == btnDivision)
                _selectedOperator = SelectedOperator.Division;
            else if (sender == btnPlus)
                _selectedOperator = SelectedOperator.Addtion;
            else
                _selectedOperator = SelectedOperator.Subtraction;
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            int selectedValue = int.Parse(selectedButton.Content.ToString());

            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = selectedValue;
            }
            else
            {
                lblResult.Content += selectedValue.ToString();
            }
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (!lblResult.Content.ToString().Contains("."))
                lblResult.Content += ".";
        }
    }

    public enum SelectedOperator
    {
        Addtion,
        Subtraction,
        Multiplication,
        Division
    }

    public static class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return 0;
            }

            return n1 / n2;
        }
    }
}
