﻿using PerzonalizedDictionary.Controllers;
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

namespace PerzonalizedDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //Get all textboxes into a list
            List<TextBox> tb = new List<TextBox>();
            FindTextBoxex(this, tb);

            List<string> input = ConvertTextBoxesToList(tb);

            //Create all posibillities
            List<string> output = PasswordGenerator.GeneratePasswords(input);

            //Show records
            lblCountPasswords.Content = output.Count.ToString() + " Results";

            lvResult.ItemsSource = output;

            FileReaderWriter.WriteFile(output);
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
    }
}
