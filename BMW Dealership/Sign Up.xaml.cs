using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Sign_Up.xaml
    /// </summary>
    public partial class Sign_Up : Window
    {
        public Sign_Up()
        {
            InitializeComponent();
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog=Database; Integrated Security=True; TrustServerCertificate=True; Encrypt=False";

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand("INSERT INTO UserCredentials(Username, Password) VALUES (@Username, @Password)", sqlcon);
                command.Parameters.AddWithValue("@Username", username.Text);
                command.Parameters.AddWithValue("@Password", password.Password);
                command.ExecuteNonQuery();
            }
        }
    }
}
