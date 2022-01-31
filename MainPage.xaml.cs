using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;



namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstnumber;
        private string operatorname;
        private bool isclickedoperation;


        private void BtnOne_Clicked(Object sender, EventArgs e)
        {

            TheLabelResult.Text = "1";
        }


        private void BtnCommon_Clicked(Object sender, EventArgs e)
        {

            var button = sender as Button;

            if(TheLabelResult.Text == "0" || isclickedoperation)
            {
                TheLabelResult.Text = button.Text;

                isclickedoperation = false;
            }

            else

            {
                TheLabelResult.Text += button.Text;
            }
        }


        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            TheLabelResult.Text = "0";
            isclickedoperation = false;
            firstnumber = 0;
        }


        private void BtnX_Clicked(object sender, EventArgs e)

        {
            string number = TheLabelResult.Text;

            if(number!="0")
                {

                number = number.Remove(number.Length - 1, 1);

                if(string.IsNullOrEmpty(number))

                {
                    TheLabelResult.Text = "0";
                   // isclickedoperation = false;
                }

                else

                {

                    TheLabelResult.Text = number;
                }
            }
        }



        private async void BtnPercen_Clicked(object sender, EventArgs e)
        {

            try
            {
               string number = TheLabelResult.Text;


                if(number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    TheLabelResult.Text = result;
                }

            }

            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

        }



        private void BtnOperations_Clicked(object sender, EventArgs e)
        {

            var button = sender as Button;

            isclickedoperation = true;

            operatorname = button.Text;

            firstnumber = Convert.ToDecimal(TheLabelResult.Text);
        }



        private void BtnEqual_Clicked(object sender, EventArgs e)
        {

            try
            {
                decimal secondNumber = Convert.ToDecimal(TheLabelResult.Text);
                string finalresult = Calculate(firstnumber, secondNumber).ToString("0.##");
                TheLabelResult.Text = finalresult;
            }

            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }
        }




        public decimal Calculate(decimal firstnumber, decimal secondNumber)
        {

            decimal result = 0;

            if(operatorname == "+")
            {
                result = firstnumber + secondNumber;
            }

            else if(operatorname == "-")
            {
                result = firstnumber - secondNumber;
            }

            else if(operatorname == "*")
            {
                result = firstnumber * secondNumber;
            }

            else if(operatorname == "/")
            {
                result =  firstnumber / secondNumber;
            }

            return result;
        }
    }
}
