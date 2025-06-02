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

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperation selectedOperation;
        public MainWindow()
        {
            InitializeComponent();

            btnAC.Click += BtnAC_Click;
            btnPlusMinus.Click += BtnPlusMinus_Click;
            btnPercentage.Click += BtnPercentage_Click;
            btnEqual.Click += BtnEqual_Click;
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            double newNumber = 0;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
               
            }

            switch (selectedOperation)
            {
                case SelectedOperation.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case SelectedOperation.Substration:
                    result = SimpleMath.Substract(lastNumber, newNumber);
                    break;
                case SelectedOperation.Multiply:
                    result = SimpleMath.Multiply(lastNumber, newNumber);
                    break;
                case SelectedOperation.Division:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
            }

            lblResult.Content = result.ToString();
        }

        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void BtnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button)?.Content?.ToString());
            if (sender == btn0)
                selectedValue = 0;
            if (sender == btn1)
                selectedValue = 1;
            if (sender == btn2)
                selectedValue = 2;
            if (sender == btn3)
                selectedValue = 3;
            if (sender == btn4)
                selectedValue = 4;
            if (sender == btn5)
                selectedValue = 5;
            if (sender == btn6)
                selectedValue = 6;
            if (sender == btn7)
                selectedValue = 7;
            if (sender == btn8)
                selectedValue = 8;
            if (sender == btn9)
                selectedValue = 9;


            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = $"{selectedValue}";
            }
            else {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if(!lblResult.Content.ToString().Contains("."))
            {
                lblResult.Content += ".";
            }
        }

        private void OperatinBtn_Click(object sender, RoutedEventArgs e)
        {
            //int selectedValue = int.Parse((sender as Button)?.Content?.ToString());

            if (sender == btnPlus)
                selectedOperation = SelectedOperation.Addition;
            if (sender == btnMinus)
                selectedOperation = SelectedOperation.Substration;
            if (sender == btnMultiply)
                selectedOperation = SelectedOperation.Multiply;
            if (sender == btnDivide)
                selectedOperation = SelectedOperation.Division;

            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lblResult.Content = "";
            }
        }
    }
}