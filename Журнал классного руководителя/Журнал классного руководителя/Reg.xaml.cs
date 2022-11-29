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
using System.Windows.Shapes;

namespace Журнал_классного_руководителя
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_authorization_Click(object sender, RoutedEventArgs e)
        {

            if(TextBox_New_login.Text == "")
            {
                MessageBox.Show("Введите логин или пароль");
                return;
            }

            if (check_user())
            return;

            String login = TextBox_New_login.Text;
            String password = TextBox_New_password.Text;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `login`, `password`) VALUES (NULL, @Login, @Password)",db.getConnection());
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = password;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Регистрация выполнена успешно");

            else
            {
                MessageBox.Show("Регистрация не выполнена");
            }

            db.closeConnection();

        }

        public Boolean check_user()
        {

            String login = TextBox_New_login.Text;
            String password = TextBox_New_password.Text;
            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @ul",db.getConnection());
            command.Parameters.Add("@ul",MySqlDbType.VarChar).Value = TextBox_New_login.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже существует");
                return true;
            }

            else
                return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow registration = new MainWindow();
            registration.Show();
        }
    }
}
