using PerzonalizedDictionary.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using PerzonalizedDictionary.Data;

namespace PerzonalizedDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // Dictionary<DataEnum.DataType, string> values;
        List<string> output;
        private Person _person;

        public MainWindow()
        {
            InitializeComponent();
           // values = new Dictionary<DataEnum.DataType, string>();
            output = new List<string>();

            _person = new Person();
            Grid.DataContext = _person;
            this.Loaded += MainWindow_Loaded;
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            double newHeight = this.ActualHeight;
            newHeight -= lblCountPasswords.ActualHeight;
            newHeight -= 60;
            lvResult.Height = newHeight;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            SetEnabled(false);
            lblCountPasswords.Content = "~ Results";
            Start();   
        }

        private void btnSavefile_Click(object sender, RoutedEventArgs e)
        {
            SetEnabled(false);
            FileReaderWriter.WriteFile(output);
            MessageBox.Show("Completed writing to file");
            SetEnabled(true);
        }

        private void SetEnabled(bool value)
        {
            btnStart.IsEnabled = value;
            btnSavefile.IsEnabled = value;
        }

        private void Start()
        {
            SetEnabled(false);
            lblCountPasswords.Content = "~ Results";
            System.Threading.Thread.Sleep(10);
            //Create all posibillities
            output = PasswordGenerator.GetInstance().GeneratePasswords(_person);
            

            //Show records
            lblCountPasswords.Content = output.Count.ToString() + " Results";

            lvResult.ItemsSource = output;
            SetEnabled(true);
        }
    }
}
