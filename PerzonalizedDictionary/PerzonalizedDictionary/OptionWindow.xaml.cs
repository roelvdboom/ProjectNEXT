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
using System.Windows.Shapes;

namespace PerzonalizedDictionary
{
    /// <summary>
    /// Interaction logic for OptionWindow.xaml
    /// </summary>
    public partial class OptionWindow : Window
    {
        public List<string> result;
        public OptionWindow()
        {
            InitializeComponent();
            result = new List<string>();
            this.Closing += OptionWindow_Closing;
        }

        private void OptionWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if((bool)cbAll.IsChecked)
                result.Add(cbAll.Content.ToString());
            if((bool)cbLower.IsChecked)
                result.Add(cbLower.Content.ToString());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
