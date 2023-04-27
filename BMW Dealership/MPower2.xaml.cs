using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
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

namespace BMW_Dealership
{
    
    public partial class MPower2 : Window
    {
        private SQLiteConnection dbConnection;
        private string hyperlink;
        public Uri MyUri { get; set; }
        public MPower2()
        {
            InitializeComponent(); if (!File.Exists("CarSpecs.db"))
            {
                SQLiteConnection.CreateFile("CarSpecs.db");
            }
            dbConnection = new SQLiteConnection("Data Source=CarSpecs.db;Version=3;");
            dbConnection.Open();
            using (var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS CarSpecs (id INTEGER PRIMARY KEY AUTOINCREMENT, Model TEXT, Power TEXT, Type TEXT, Transmission TEXT, Color TEXT, Mileage INTEGER, Pirce INTEGER,[See More] TEXT)", dbConnection))
            {
                command.ExecuteNonQuery();
            }
            //Insert data into the Database
            using (var command2 = new SQLiteCommand("INSERT INTO CarSpecs (Model, Power, Type, Transmission, Color, Mileage, [See More]) VALUES ('M3 CS (G26)', '375 kW (~510 hp)', 'Petrol', 'Automatic', 'Signal Green', 21300, 'https://www.mobile.bg/pcgi/mobile.cgi?act=4&adv=11666772180125197&slink=s728p0')", dbConnection))
            {
                command2.ExecuteNonQuery();
            }
            List<Specs> items = new List<Specs>();
            string stm = "SELECT Model, Power, Type, Transmission, Color, Mileage, [See More] FROM CarSpecs WHERE Model = 'M3 CS (G26)'";
            using (var command3 = new SQLiteCommand(stm, dbConnection))
            {
                //MessageBox.Show(command3.ExecuteNonQuery().ToString());
                using (SQLiteDataReader rdr = command3.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        items.Add(new Specs() { Title = "Model:", Value = rdr.GetString(0) });
                        items.Add(new Specs() { Title = "Power:", Value = rdr.GetString(1) });
                        items.Add(new Specs() { Title = "Type:", Value = rdr.GetString(2) });
                        items.Add(new Specs() { Title = "Transmission:", Value = rdr.GetString(3) });
                        items.Add(new Specs() { Title = "Color:", Value = rdr.GetString(4) });
                        items.Add(new Specs() { Title = "Mileage:", Value = rdr.GetInt32(5).ToString() });

                        hyperlink = rdr.GetString(6);

                        MyUri = new Uri(hyperlink);
                        DataContext = this;
                    }
                }
            }
            SpecsGrid.ItemsSource = items;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {e.Uri.AbsoluteUri}") { CreateNoWindow = true });
            e.Handled = true;
        }

        public class Specs
        {
            public string Title { get; set; }
            public string Value { get; set; }
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MPower1 obj = new MPower1();
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
