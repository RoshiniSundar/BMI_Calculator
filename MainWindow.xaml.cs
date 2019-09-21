using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace BMI_Calculator
{
    public partial class MainWindow : Window
    {
        BMI bmi = new BMI();
        const int IMPERIAL_CONST = 703;
        const int METRIC_CONST = 10000;
        const double UNDERWEIGHT_BMI = 18.5;
        const double OVERWEIGHT_BMI = 25;
        const string UNDERWEIGHT_MSG = "\nYou are underweight!";
        const string OVERWEIGHT_MSG = "\nYou are overweight!";
        const string OPTIMAL_MSG = "\nYour weight is optimal!";
        double height, weight, impBmi, metBmi;

        private void Imp_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            impBmiDisplay.Content = "";
            impError.Visibility = Visibility.Hidden;
        }

        private void Met_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            metBmiDisplay.Content = "";
            metError.Visibility = Visibility.Hidden;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = bmi;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (sender == impReset)
            {
                impHeight.Text = "50";
                impWeight.Text = "50";
                impBmiDisplay.Content = " ";
                impError.Visibility = Visibility.Hidden;
            }
            else
            {
                metHeight.Text = "50";
                metWeight.Text = "50";
                metBmiDisplay.Content = " ";
                metError.Visibility = Visibility.Hidden;
            }
        }

        private string calcWeightType(double bmi)
        {
            string s = "   Your BMI is ";
            if(bmi < UNDERWEIGHT_BMI)
                s += (bmi.ToString() + UNDERWEIGHT_MSG);
            else if(bmi > OVERWEIGHT_BMI)
                s += (bmi.ToString() + OVERWEIGHT_MSG);
            else
                s += (bmi.ToString() + OPTIMAL_MSG);
            return s;
        }

        private void Show_Error()
        {
            if (impTab.IsSelected)
                impError.Visibility = Visibility.Visible;
            else if (metTab.IsSelected)
                metError.Visibility = Visibility.Visible;
        }

        private void BmiCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (impTab.IsSelected)
                {
                    height = double.Parse(impHeight.Text);
                    weight = double.Parse(impWeight.Text);
                    if(height < 1 || weight < 1)
                    {
                        Show_Error();
                        return;
                    }
                    impBmi = weight * (IMPERIAL_CONST / Math.Pow(height, 2));
                    impBmiDisplay.Content = calcWeightType(Math.Round(impBmi, 2));
                }
                else if (metTab.IsSelected)
                {
                    height = double.Parse(metHeight.Text);
                    weight = double.Parse(metWeight.Text);
                    if (height < 1 || weight < 1)
                    {
                        Show_Error();
                        return;
                    }
                    metBmi = (weight / height/ height) * METRIC_CONST;
                    metBmiDisplay.Content = calcWeightType(Math.Round(metBmi, 2));
                }
            }
            catch (Exception)
            {
                Show_Error();
            }
        }
    }
}

