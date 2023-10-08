using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using HygrometerBL;

namespace HygrometerWPFUI
{
    /// <summary>
    /// Interaction logic for HygrometerUI.xaml
    /// </summary>
    public partial class HygrometerUI : Window
    {
        public HygrometerUI()
        {
            InitializeComponent();

            dryThermometerTextBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };
            double dryThermometer = Convert.ToDouble(dryThermometerTextBox.Text, numberFormatInfo);
            double wetThermometer = Convert.ToDouble(wetThermometerTextBox.Text, numberFormatInfo);
            Hygrometer.PsychometricMethod(dryThermometer, wetThermometer, out double relativeHumidity);
            label.Content = relativeHumidity.ToString() + "%";
            MessageBox.Show("Данные сохранены в файл!", "Успешное сохранение!", MessageBoxButton.OK);
        }

        private void dryThermometerKeyDown(object sender, KeyEventArgs e)
        {
            var text = (TextBox)sender;

            if (string.IsNullOrEmpty(text.Text))
            {
                return;
            }
            if (e.Key == Key.Enter)
            {
                wetThermometerTextBox.Focus();
            }
        }

        private void wetThermometerKeyDown(object sender, KeyEventArgs e)
        {
            var text = (TextBox)sender;

            if (string.IsNullOrEmpty(text.Text))
            {
                return;
            }
            if (e.Key == Key.Enter)
            {
                Button_Click(null, null);
            }
        }
    }
}
