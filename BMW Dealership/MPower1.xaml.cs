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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BMW_Dealership
{
    /// <summary>
    /// Interaction logic for MPower1.xaml
    /// </summary>
    public partial class MPower1 : Window
    {
        public MPower1()
        {
            InitializeComponent();

        }


        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            MPower2 obj = new MPower2();
            obj.Show();
            this.Close();
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            Main obj = new Main();
            obj.Show();
            this.Close();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile obj = new Profile();
            obj.Show();
            this.Close();
        }
    }
}
