using System;
using UIKit;

namespace App5
{
    public enum Operator {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class Calculator {
        public string Calculate( string operand1, string operand2, Operator @operator ) {
            double value1;
            double value2;

            double.TryParse(operand1, out value1);
            double.TryParse(operand2, out value2);

            double result = 0;

            switch (@operator)
            {
                case Operator.Addition:
                    result = value1 + value2;
                    break;
                case Operator.Subtraction:
                    result = value1 - value2;
                    break;
                case Operator.Multiplication:
                    result = value1 * value2;
                    break;
                case Operator.Division:
                    result = value1 / value2;
                    break;
            }

            return result.ToString( );
        }
    }

    public partial class ViewController : UIViewController {
        private string _operand1 = string.Empty;
        private string _operand2 = string.Empty;
        private Operator _operator;

        private Calculator _calculator;

        public ViewController(IntPtr handle) : base(handle)
        {
            _calculator = new Calculator();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            txtDisplay.Text = string.Empty;

            btnZero.TouchUpInside += NumericButtonClick;
            btnOne.TouchUpInside += NumericButtonClick;
            btnTwo.TouchUpInside += NumericButtonClick;
            btnThree.TouchUpInside += NumericButtonClick;
            btnFour.TouchUpInside += NumericButtonClick;
            btnFive.TouchUpInside += NumericButtonClick;
            btnSix.TouchUpInside += NumericButtonClick;
            btnSeven.TouchUpInside += NumericButtonClick;
            btnEight.TouchUpInside += NumericButtonClick;
            btnNine.TouchUpInside += NumericButtonClick;

            btnAdd.TouchUpInside += OperatorButtonClick;
            btnSubtract.TouchUpInside += OperatorButtonClick;
            btnMultiply.TouchUpInside += OperatorButtonClick;
            btnDivide.TouchUpInside += OperatorButtonClick;

            btnEquals.TouchUpInside += EqualsButtonClick;
        }

        private void EqualsButtonClick( object sender, EventArgs eventArgs ) {
            _operand2 = txtDisplay.Text;

            txtDisplay.Text = _calculator.Calculate( _operand1, _operand2, _operator );
        }

        private void OperatorButtonClick( object sender, EventArgs eventArgs ) {
            _operand1 = txtDisplay.Text;
            var button = (UIButton) sender;

            switch ( button.CurrentTitle ) {
                case "+":
                    _operator = Operator.Addition;
                    break;
                case "-":
                    _operator = Operator.Subtraction;
                    break;
                case "X":
                    _operator = Operator.Multiplication;
                    break;
                case "/":
                    _operator = Operator.Division;
                    break;
            }

            txtDisplay.Text = string.Empty;
        }

        private void NumericButtonClick( object sender, EventArgs eventArgs ) {
            var button = (UIButton) sender;
            txtDisplay.Text += button.CurrentTitle;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}