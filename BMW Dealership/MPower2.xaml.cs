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
    /// Interaction logic for MPower2.xaml
    /// </summary>
    public partial class MPower2 : Window
    {
        public MPower2()
        {
            InitializeComponent();
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MPower1 obj = new MPower1();
            obj.Show();
            this.Close();
        }
    }
}
