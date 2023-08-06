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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cadwise_test2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private AddMoney _addMoney;

        public Window1(AddMoney addMoney, int spaceLeft)
        {
            InitializeComponent();
            _addMoney = addMoney;
            TextLeft.Text = $"Введите колличество купюр, которое необходимо внести \r\n(не более {(spaceLeft > 100 ? 100: spaceLeft)})\r\n\r\n";
        }
        
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(_10Text.Text, out int _10) &&
               int.TryParse(_50Text.Text, out int _50) &&
               int.TryParse(_100Text.Text, out int _100) &&
               int.TryParse(_200Text.Text, out int _200) &&
               int.TryParse(_500Text.Text, out int _500) &&
               int.TryParse(_1000Text.Text, out int _1000) &&
               int.TryParse(_2000Text.Text, out int _2000) &&
               int.TryParse(_5000Text.Text, out int _5000))
            {
                if (_10 + _50 + _100 + _200 + _500 + _1000 + _2000 + _5000 > 100)
                {
                    MessageBox.Show("Колличество купюр должно быть меньше 100!");
                    return;
                }

                Thread thread = new Thread(() =>
                { 
                    Wallet w = new Wallet(_10,_50,_100,_200,_500,_1000,_2000,_5000);
                    
                    _addMoney.Invoke(w.bills);
                    Dispatcher.Invoke(() => this.Close());
                });
                thread.Start();
            }
            else
            {
                MessageBox.Show("Введите корректные данные!");
            }
        }
    }
}
