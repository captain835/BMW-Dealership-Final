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
    /// Interaction logic for Luxury1.xaml
    /// </summary>
    public partial class Luxury1 : Window
    {
        public Luxury1()
        {
            InitializeComponent();
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            Luxury2 obj = new Luxury2();
            obj.Show();
            this.Close();
        }
    }
}
