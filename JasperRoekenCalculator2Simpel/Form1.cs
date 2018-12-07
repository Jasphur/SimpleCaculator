using System;
using System.Windows.Forms;

namespace JasperRoekenCalculator2Simpel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        double value = 0;
        string input = "";
        bool operatorUsed = false;
        bool equalBtnUsed = false;
        float deciCount = 0;

        // Invoeren getallen
        private void BtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Haalt de standaard beginwaarde 0 weg bij invoeren nieuw getal
            if ((result.Text == "0") || (operatorUsed))
                result.Clear();
            
               // Zorgen dat het eerste getal een "0" kan zijn en de eerste toets invoer een "," kan zijn.
               if (btn.Text == ",")
               {
                if (!result.Text.Contains(","))
                    result.Text += btn.Text;
               }
               else
                   result.Text += btn.Text;
                   
            // Beginnen van nieuwe som zonder op 'Clear All' te klikken
            if (equalBtnUsed == true)
            {
                value = 0;
                result.Clear();
                result.Text += btn.Text;
            }

            operatorUsed = false;
            equalBtnUsed = false;
        }

        // De , toets
        private void DeciClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Zorgen dat er geen tweede "," kan worden toegevoegd
            if (deciCount == 0)
            {
                deciCount++;
                result.Text += btn.Text;
            }
        }

        // Totale reset van invoer in het display via de ClearAll toets
        private void ButtonAllClear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
            deciCount = 0;
        }

        // Laatste invoer verwijderen met de Clear toets
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            deciCount = 0;
        }

        // Operator toevoegen aan rekensom
        private void OperatorBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Checken of er al een eerder som heeft plaats gevonden. Bij true: uitkomst als eerste input getal gebruiken, daarna invoeren orperator 
            if (value != 0)
            {   if (operatorUsed == false)
                {
                    // Onmogelijk maken twee keer klikken op operator toets
                    EqualBtn.PerformClick();
                    operatorUsed = true;
                }

                input = btn.Text;
                equalBtnUsed = false;
                deciCount = 0;
            }

            // invoeren operator
            else
            {
                input = btn.Text;
                value = Double.Parse(result.Text);
                operatorUsed = true;
                deciCount = 0;
            }
        }

        // De worteltoets
        private void RootBtnClick(object sender, EventArgs e)
        {
            value = Double.Parse(result.Text);
            result.Text = Convert.ToString(Math.Sqrt(value));
            //result.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(result.Text)));
        }

        // De percentage toets
        private void PercentageBtnClick(object sender, EventArgs e)
        {
            value = Double.Parse(result.Text);
            result.Text = (value / 100).ToString();
        }

        // De kwadraattoets
        private void SquareBtnClick(object sender, EventArgs e)
        {
            value = Double.Parse(result.Text);
            result.Text = Convert.ToString(Math.Pow(value, 2));
        }

        // De = toets
        private void EqualBtn_click(object sender, EventArgs e)
        {
            // Onmogelijk maken twee keer gebruiken equals toets
            if (equalBtnUsed == false)
            {
                // Bekijken welke operator er is gebruikt en toepassen
                switch (input)
                {
                    case "+":
                        result.Text = (value + Double.Parse(result.Text)).ToString();
                        break;

                    case "-":
                        result.Text = (value - Double.Parse(result.Text)).ToString();
                        break;

                    case "/":
                        result.Text = (value / Double.Parse(result.Text)).ToString();
                        break;

                    case "X":
                        result.Text = (value * Double.Parse(result.Text)).ToString();
                        break;

                    default:
                        break;
                }
            }
            // Opslaan uitkomt rekensom
            value = double.Parse(result.Text);
            // '=' toets is gebruikt
            equalBtnUsed = true;
            // Reset komma gebruik
            deciCount = 0;
        }

        // Zorgen dat het toetsenbord gebruikt kan worden
        private void NumPadInput(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    ZeroBtn.PerformClick();
                    break;

                case "1":
                    OneBtn.PerformClick();
                    break;

                case "2":
                    TwoBtn.PerformClick();
                    break;

                case "3":
                    ThreeBtn.PerformClick();
                    break;

                case "4":
                    FourBtn.PerformClick();
                    break;

                case "5":
                    FiveBtn.PerformClick();
                    break;

                case "6":
                    SixBtn.PerformClick();
                    break;

                case "7":
                    SevenBtn.PerformClick();
                    break;

                case "8":
                    EightBtn.PerformClick();
                    break;

                case "9":
                    NineBtn.PerformClick();
                    break;

                case "*":
                    TimesBtn.PerformClick();
                    break;

                case "/":
                    DivideBtn.PerformClick();
                    break;

                case "-":
                    SubtractBtn.PerformClick();
                    break;

                case "+":
                    Addbtn.PerformClick();
                    break;

                case ",":
                    DecimalBtn.PerformClick();
                    break;

                case ".":
                    DecimalBtn.PerformClick();
                    break;

                case "c":
                    ClearBtn.PerformClick();
                    break;

               // Twee keer op de "c" toets op het toetsenbord klikken voor een All Clear
                case "c" + "c":
                    AllClearBtn.PerformClick();
                    break;

                default:
                    break;
            }

            // De "Enter" toets op het toetsenbord de functie van de "=" toets toewijzen
            if (e.KeyChar == (char) Keys.Enter)
                EqualBtn.PerformClick();
        }
    }
}

