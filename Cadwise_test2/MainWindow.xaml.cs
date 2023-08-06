using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cadwise_test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    public delegate void AddMoney(List<Bill> bills);
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
        private ATM _atm = new ATM(640); //необходимо указать, колличество купюр в началеработы (максимум - 1024)
        private int multiplayer = 10;
        public MainWindow()
        {
            InitializeComponent();
            SetBalances();
            multiplayer = _atm.GetMultiplayer();

        }


        private void SetBalances()
        {
            Dispatcher.Invoke(()=>ATMBalanceText.Text = $"баланс банкомата: {_atm.BalanceCash}");
        }

        private void CashOutButton_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(GetMoenyText.Text, out int amount))
            {
                if(amount % multiplayer == 0)
                {
                    LB.Items.Clear();
                    List<Bill> b = new List<Bill>();
                    Thread t = new Thread(() =>
                    {
                        b = _atm.CashOut(amount, amount >= 5000 ? Dispatcher.Invoke(()=>BigMoneyCheckBox.IsChecked) : false);
                        foreach (Bill bill in b)
                        {
                            Dispatcher.Invoke(()=>LB.Items.Add($"Купюра номиналом: {(int)bill.Value}"));
                        }
                    });
                    t.Start();
                    multiplayer = _atm.GetMultiplayer();
                    SetBalances();
                }
                else
                {
                    MessageBox.Show("Введите число кратное 100!");
                }
            }
        }

        private void AddToATM_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1(delegate(List<Bill> b) { _atm.AddMoney(b); SetBalances(); }, _atm.SpaceLeft);
            win.Show();
        }
    }
}
