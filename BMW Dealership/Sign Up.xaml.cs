using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
using System.Xml.Linq;

namespace BMW_Dealership
{
    /// <summary>
    /// Interaction logic for Sign_Up.xaml
    /// </summary>
    public partial class Sign_Up : Window
    {
        private SQLiteConnection dbConnection;
        public Sign_Up()
        {
            InitializeComponent();
            if (!File.Exists("UserCredentials.db"))
            {
                SQLiteConnection.CreateFile("UserCredentials.db");
            }
            dbConnection = new SQLiteConnection("Data Source=UserCredentials.db;Version=3;");
            dbConnection.Open();
            using (var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS UserCredentials (id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT UNIQUE, password TEXT)", dbConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordRBox.Password != PasswordBox.Password)
            {
                MessageBox.Show("Passwords don't match.");
            }
            else
            {
                string username = UsernameBox.Text.Trim();
                string password = PasswordRBox.Password;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(PasswordBox.Password))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }



                using (var checkCommand = new SQLiteCommand("SELECT COUNT(*) FROM UserCredentials WHERE username=@username", dbConnection))
                {
                    checkCommand.Parameters.AddWithValue("@username", username);
                    object result = checkCommand.ExecuteScalar();
                    int count = Convert.ToInt32(result);

                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                        return;
                    }
                }



                using (var insertCommand = new SQLiteCommand("INSERT INTO UserCredentials(username, password) VALUES (@username, @password)", dbConnection))
                {
                    insertCommand.Parameters.AddWithValue("@username", username);
                    insertCommand.Parameters.AddWithValue("@password", password);
                    Application.Current.Resources["Username"] = username;
                    insertCommand.ExecuteNonQuery();
                }


                dbConnection.Close();

                // Show a message box to indicate success
                //MessageBox.Show("Account created successfully!");

                Log_In obj = new Log_In();
                obj.Show();
                this.Close();
            }
        }
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
