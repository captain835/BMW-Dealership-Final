using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
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
    public partial class Edit_Profile : Window
    {

        public string username;
        private SQLiteConnection dbConnection;

        public Edit_Profile()
        {
            InitializeComponent();
            username = (string)Application.Current.Resources["Username"];
            dbConnection = new SQLiteConnection("Data Source=UserProfiles.db;Version=3;");
            dbConnection.Open();



        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FullNameBox.Text.Trim().Split(' ')[0];
            string lastName = FullNameBox.Text.Trim().Split(' ')[1];
            string email = EmailBox.Text.Trim();
            string phone = PhoneBox.Text.Trim();
            string country = CountryBox.Text.Trim();
            using (var command = new SQLiteCommand("UPDATE UserProfiles SET firstName=@firstName, lastName=@lastName, email=@email, phone=@phone, country=@country WHERE username=@username", dbConnection))
            {
                command.Parameters.AddWithValue("@firstName", firstName); // replace with the new value for the firstName column
                command.Parameters.AddWithValue("@lastName", lastName); // replace with the new value for the lastName column
                command.Parameters.AddWithValue("@email", email); // replace with the new value for the email column
                command.Parameters.AddWithValue("@phone", phone); // replace with the new value for the phone column
                command.Parameters.AddWithValue("@country", country); // replace with the new value for the country column
                command.Parameters.AddWithValue("@username", username);

                Application.Current.Resources["Country"] = country;

                command.ExecuteNonQuery();
            }
            Profile obj= new Profile();
            obj.Show();
            this.Close();
        }
    }
}
