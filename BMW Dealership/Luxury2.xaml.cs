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

namespace BMW_Dealership
{
    /// <summary>
    /// Interaction logic for Luxury2.xaml
    /// </summary>
    public partial class Luxury2 : Window
    {
        public Luxury2()
        {
            InitializeComponent();
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            Luxury1 obj = new Luxury1();
            obj.Show();
            this.Close();
        }
    }
}
