using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Threading;

namespace Cadwise_test
{
    public partial class MainWindow : Window
    {
        List<string> strings = new List<string>();
        string _currentSelected = "";
        string CurrentSelected 
        { 
            get => _currentSelected; 
            set 
            {
                _currentSelected = value; 
                OpenText.Text = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenText.Text = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Thread t = new Thread(() => 
                { 
                    StreamReader sr = new StreamReader(openFileDialog.FileName);
                    strings.Add(sr.ReadToEnd());
                    
                    Dispatcher.Invoke(() =>
                    {
                        CurrentSelected = strings[strings.Count - 1];
                        Listbox.Items.Add($"Текст {Listbox.Items.Count + 1}");
                    }); 
                });
                t.Start();
            }
        }

        private void DeleterPunctuation_Click(object sender, RoutedEventArgs e)
        {
            if (strings.Count <= 0)
                return;
            Thread t = new Thread(() =>
            { 
                Deletes del = new Deletes(CurrentSelected);
                Dispatcher.Invoke(() => ResultText.Text = del.DeletePunctuation());
            });
            t.Start();
        }

        private void DeleteShortWords_Click(object sender, RoutedEventArgs e)
        {
            if (strings.Count > 0 && int.TryParse(LengthText.Text, out int res))
            {
                Thread t = new Thread(() =>
                {
                    Deletes del = new Deletes(CurrentSelected);
                    Dispatcher.Invoke(() => ResultText.Text = del.DeleteShortWords(res));
                });
                t.Start();
            }
        }

        private void DeleteBoth_Click(object sender, RoutedEventArgs e)
        {
            if (strings.Count > 0 && int.TryParse(LengthText.Text, out int res))
            {
                Thread t = new Thread(() =>
                {

                    Deletes del = new Deletes(CurrentSelected);
                    string temp = del.DeleteShortWordsAndPunctuation(res);
                    Dispatcher.Invoke(() => ResultText.Text = temp);
                });
                t.Start();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            strings.Clear();
            CurrentSelected = "";
            Listbox.Items.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLineAsync(ResultText.Text);
                    writer.Close();
                }
            }
        }

        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listbox.SelectedIndex >= strings.Count)
            {
                CurrentSelected = string.Empty;
                return;
            }
            CurrentSelected = strings[Listbox.SelectedIndex];
        }
    }
}
