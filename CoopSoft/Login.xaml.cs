using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CoopSoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        Home welcome = new Home();
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxEmail.Text.Length == 0)
                {
                    errormessage.Text = "Ingresa un email";
                    textBoxEmail.Focus();
                }
                else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errormessage.Text = "Ingresa un email valido.";
                    textBoxEmail.Select(0, textBoxEmail.Text.Length);
                    textBoxEmail.Focus();
                }
                else
                {
                    _loading.Visibility = Visibility.Visible;

                    string email = textBoxEmail.Text;
                    string password = passwordBox1.Password;
                    SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=CoopSoft;Trusted_Connection=True");
                    await con.OpenAsync();
                    SqlCommand cmd = new SqlCommand("Select * from Usuarios where Email='" + email + "'  and Clave='" + password + "'", con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        string username = dataSet.Tables[0].Rows[0]["NombreUsuario"].ToString();
                     //   welcome.TextBlockName.Text = username;//Sending value from one form to another form.  

                        _loading.Visibility = Visibility.Hidden;
                        welcome.Show();
                        Close();
                    }
                    else
                    {
                        errormessage.Text = "Por favor, ingresa credenciales existentes.";
                    }
                    con.Close();
                }
            } catch (Exception ex)
            {
                _loading.Visibility = Visibility.Hidden;
                MessageBox.Show("Error:" + ex, "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
    }
}
