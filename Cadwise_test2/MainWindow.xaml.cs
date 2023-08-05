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

namespace Cadwise_test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum BillValue { 
        Ten = 10, 
        Fifty = 50, 
        OneHundred = 100, 
        TwoHundred = 200, 
        FiveHundred = 500, 
        OneThousand = 1000, 
        TwoThousand  = 2000, 
        FiveThousand  = 5000
    }
    public partial class MainWindow : Window
    {
        private ATM _atm = new ATM(320); //необходимо указать, колличество купюр в началеработы (максимум - 512)
        private Wallet _wallet = new Wallet(40); //необходимо указать, колличество купюр в началеработы (максимум - 64)
        public MainWindow()
        {
            InitializeComponent();
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void CashOutButton_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(GetMoenyText.Text, out int amount))
            {
                if(amount % 100 == 0)
                {

                    MessageBox.Show("КРАСАВЧИК");
                    //_wallet.AddMoney(_atm.CashOut(amount, amount >= 5000 ? BigMoneyCheckBox.IsChecked : false));
                }
                else
                {
                    MessageBox.Show("Введите число кратное 100!");
                }
            }
            //ATM w = new ATM(320);
            //StringBuilder sb = new StringBuilder();
            //foreach (Bill b in w._bills)
            //{
            //    sb.Append($"Купюра номинолом: {(int)b.Value}, ");
            //}
            //RES.Text = sb.ToString();
        }
    }
}
