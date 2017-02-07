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

        private void PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Use textbox that u clicked on
            TextBox txb = (TextBox)sender;

            //Take the grey color into a brush
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FF797979");

            //Check if the text is grey
            if (txb.Foreground.ToString() == brush.ToString())
            {
                //Clear the textbox and change the color to black
                txb.Text = String.Empty;
                txb.Foreground = Brushes.Black;
            }
        }
    }
}
