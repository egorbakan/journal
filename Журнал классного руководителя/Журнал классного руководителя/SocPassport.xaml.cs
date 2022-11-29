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
using System.Data;
using MySql.Data.MySqlClient;

namespace Журнал_классного_руководителя
{
    /// <summary>
    /// Логика взаимодействия для SocPassport.xaml
    /// </summary>
    public partial class SocPassport : Window
    {

        private MySqlConnection sqlConnection = null;
        private MySqlDataAdapter adapter = null;
        private DataTable table = null;
        public SocPassport()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            adapter = new MySqlDataAdapter("SELECT * FROM socpassport" , sqlConnection);
            table = new DataTable();
            adapter.Fill(table);
            Dg_socpas.DataContext = table;
        }
    }
}
