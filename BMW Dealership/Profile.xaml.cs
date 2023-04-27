using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Data.SQLite;
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
using System.Windows.Shapes;

namespace BMW_Dealership
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public string Hello { get; set; }
        public string FullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string username { get; set; }
        private SQLiteConnection dbConnection;
        public Profile()
        {
            InitializeComponent();
            DataContext = this;
            username = (string)Application.Current.Resources["Username"];
            if (!File.Exists("UserProfiles.db"))
            {
                SQLiteConnection.CreateFile("UserProfiles.db");
            }
            dbConnection = new SQLiteConnection("Data Source=UserProfiles.db;Version=3;");
            dbConnection.Open();
            using (var command4 = new SQLiteCommand("CREATE TABLE IF NOT EXISTS UserProfiles (id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT, firstName TEXT, lastName TEXT, email TEXT, phone TEXT, country TEXT)", dbConnection))
            {
                command4.ExecuteNonQuery();
            }
            //check whether user has edited/completed profile before
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM UserProfiles WHERE username=@username", dbConnection);
            command.Parameters.AddWithValue("@username", username);
            SQLiteDataReader reader = command.ExecuteReader();
            bool usernameExists = reader.HasRows;
            MessageBox.Show(usernameExists.ToString());

            string stm = "";
            if (usernameExists)
            { 
                stm = "SELECT username, firstName, lastName, email, phone, country FROM UserProfiles WHERE username = @username"; 
            }
            else
            {
                //Insert data into the Database
                using (var command2 = new SQLiteCommand("INSERT INTO UserProfiles (username, firstName, lastName, email, phone, country) VALUES (@username, '-', '-', '-', '-', '-')", dbConnection))
                {
                    command2.Parameters.AddWithValue("@username", username);
                    command2.ExecuteNonQuery();
                }
                stm = "SELECT username, firstName, lastName, email, phone, country FROM UserProfiles WHERE username = @username";
            }
            using (var command3 = new SQLiteCommand(stm, dbConnection))
            {
                command3.Parameters.AddWithValue("@username", username);
                //MessageBox.Show(command3.ExecuteNonQuery().ToString());
                using (SQLiteDataReader rdr = command3.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Hello = "Hello," + rdr.GetString(0).ToString();
                        FullName = "Mr/s. "+  rdr.GetString(1).ToString() + " " + rdr.GetString(2).ToString();
                        email = rdr.GetString(3).ToString();
                        phone =rdr.GetString(4).ToString();
                        country = rdr.GetString(5).ToString();
                    }
                }
                FullBox.Text = FullName;
                MailBox.Text = email;
                PhoneBox.Text = phone;
            }
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            Main obj =  new Main();
            obj.Show();
            this.Close();
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            Edit_Profile obj = new Edit_Profile();
            obj.Show();
            this.Close();
        }
    }
}
