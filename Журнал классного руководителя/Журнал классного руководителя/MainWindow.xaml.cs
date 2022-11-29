using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Журнал_классного_руководителя
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_authorization_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Bt_reg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Reg registration = new Reg();
            registration.Show();
        }

        private void Button_authorization_Copy_Click(object sender, RoutedEventArgs e)
        {
            String login = TextBox_login.Text;
            String password = Pas.Password;

            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @Log AND `password` = @Pas", db.getConnection());
            command.Parameters.Add("@Log", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@Pas", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0) { 
                MessageBox.Show("Авторизация прошла успешно");
                this.Hide();
                Journal main = new Journal();
                main.Show();
            }

            else
            {
                MessageBox.Show("Не верный логин или пароль");
            }
        }
    }
}
