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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
