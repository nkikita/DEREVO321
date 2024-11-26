using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DEREVO321
{
    public partial class MianForm : Form
    {
        private NpgsqlConnection connection;
<<<<<<< HEAD

=======
        private string connectionString = "Host=localhost;Port=5432;Database=DEMO;Username=postgres;Password=nikitos";
>>>>>>> 2cfd712cf51c423a54ff441844a3e92136468d34

        private DataGridView dataGridView;
        public MianForm()
        {
            connection = new NpgsqlConnection();
            InitializeComponent();
            dataGridView = new DataGridView();
            dataGridView.Top = 60;
            dataGridView.Width = 1000;
            dataGridView.Height = 400;
            dataGridView.Left = 20;
            dataGridView.BackgroundColor = Color.LightBlue;
            this.Controls.Add(dataGridView);
            string[] tables = GetTableNames();
            for (int i = 0; i < tables.Length; i++)
            {
                ToolStripMenuItem openItem = new ToolStripMenuItem(tables[i]);
                openItem.Click += OpenItem_Click;
                открытьТаблицыToolStripMenuItem.DropDownItems.Add(openItem);

                ToolStripMenuItem editItem = new ToolStripMenuItem(tables[i]);
                editItem.Click += EditItem_Click;
                редактированиеToolStripMenuItem.DropDownItems.Add(editItem);
            }
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;

            if (clickedItem != null)
            {
                string tableName = clickedItem.Text;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter($"SELECT * FROM {tableName}", connection);
                DataTable dataTable = new DataTable();

                if (connection.State == ConnectionState.Closed)
                {
                    MessageBox.Show("Выполните подключение!");
                }
                else
                {
                    dataAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            var dbContext = new ApplicationContext();
            if (clickedItem != null)
            {
                string tableName = clickedItem.Text;
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = {tableName};", connection);


                if (connection.State == ConnectionState.Closed)
                {
                    MessageBox.Show("Выполните подключение!");
                }
                else
                {
                    var columnNames = GetColumnNames(tableName);
                    Redactor columnNamesForm = new Redactor(columnNames, tableName, dbContext);
                    columnNamesForm.Show();
                }
            }
        }
        public List<string> GetColumnNames(string tableName)
        {
            var columnNames = new List<string>();

            using (var context = new ApplicationDbContext())
            {
                context.Database.OpenConnection(); // Открываем соединение

                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = $"SELECT column_name FROM information_schema.columns WHERE table_name = '{tableName}'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnNames.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return columnNames;
        }

        public string[] GetTableNames()
        {
<<<<<<< HEAD
            var tableNames = new List<string>();
=======
            var tableNames = new List<string>(); 

            using (var context = new ApplicationDbContext())
            {
                context.Database.OpenConnection();

                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    // SQL-запрос для получения списка таблиц
                    command.CommandText = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return tableNames.ToArray(); 
        }


>>>>>>> 2cfd712cf51c423a54ff441844a3e92136468d34

            using (var context = new ApplicationDbContext())
            {
                context.Database.OpenConnection();

                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    // SQL-запрос для получения списка таблиц
                    command.CommandText = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return tableNames.ToArray();
        }
        private void подключитьсяКБдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            if (подключитьсяКБдToolStripMenuItem.Text == "подключиться к бд")
            {

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    string connectionString = $"Host=localhost;Port=5432;Database=DerevoTestDatabase;Username={name};Password={password}";
                    connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    MessageBox.Show("Подключение успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    подключитьсяКБдToolStripMenuItem.Text = "Отключиться от БД";
                    textBox1.Hide();
                    textBox2.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (подключитьсяКБдToolStripMenuItem.Text == "Отключиться от БД")
            {

                textBox1.Clear();
                textBox2.Clear();
                textBox1.Show();
                textBox2.Show();
                connection.Close();
                dataGridView.DataSource = null;
                MessageBox.Show("Отключене от базы данных PostgreSQL успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                подключитьсяКБдToolStripMenuItem.Text = "подключиться к бд";
            }
        }

        private void MianForm_Load(object sender, EventArgs e)
        {

        }
    }
}

public class ApplicationDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
<<<<<<< HEAD
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DerevoTestDatabase;Username=postgres;Password=nikitos");
=======
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DEMO;Username=postgres;Password=nikitos");
>>>>>>> 2cfd712cf51c423a54ff441844a3e92136468d34
    }

}