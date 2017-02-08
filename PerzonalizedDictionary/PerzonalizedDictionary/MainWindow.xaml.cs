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
            _person.Address = new Address();
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
            //Get all textboxes into a list
            List<TextBox> tb = new List<TextBox>();
            FindTextBoxex(this, tb);

            //FillDictionary();

            List<string> input = ConvertTextBoxesToList(tb);

            //Create all posibillities
            output = PasswordGenerator.GeneratePasswords(input);

            OptionWindow window = new OptionWindow();
            window.ShowDialog();
            List<string> results = window.result;

            //Show records
            lblCountPasswords.Content = output.Count.ToString() + " Results";

            lvResult.ItemsSource = output;

            
        }

        void FindTextBoxex(object uiElement, IList<TextBox> foundOnes)
        {
            //Put all Textboxes into a list
            if (uiElement is TextBox)
            {
                foundOnes.Add((TextBox)uiElement);
            }
            else if (uiElement is Panel)
            {
                var uiElementAsCollection = (Panel)uiElement;
                foreach (var element in uiElementAsCollection.Children)
                {
                    FindTextBoxex(element, foundOnes);
                }
            }
            else if (uiElement is UserControl)
            {
                var uiElementAsUserControl = (UserControl)uiElement;
                FindTextBoxex(uiElementAsUserControl.Content, foundOnes);
            }
            else if (uiElement is ContentControl)
            {
                var uiElementAsContentControl = (ContentControl)uiElement;
                FindTextBoxex(uiElementAsContentControl.Content, foundOnes);
            }
        }


        private List<string> ConvertTextBoxesToList(List<TextBox> tb)
        {
            List<string> input = new List<string>();

            foreach(TextBox txb in tb)
            {
                if (txb.Text != String.Empty)
                {
                    if (txb.Text.Contains(" "))
                    {
                        string[] s = txb.Text.Split(' ');
                        foreach (string x in s)
                        {
                            input.Add(x);
                        }
                    }
                    else if (txb.Text.Contains("-"))
                    {
                        string[] s = txb.Text.Split('-');
                        StringBuilder sb = new StringBuilder();

                        foreach (string item in s)
                        {
                            sb.Append(item);
                        }

                        input.Add(sb.ToString());

                        foreach (string x in s)
                        {
                            input.Add(x);
                        }
                    }
                    else
                    {
                        input.Add(txb.Text);
                    }
                }
            }

            return input;
        }

        private void btnSavefile_Click(object sender, RoutedEventArgs e)
        {
            FileReaderWriter.WriteFile(output);
        }
    }
}
