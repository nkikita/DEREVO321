using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Text;


namespace DEREVO321
{
   
    public partial class MianForm : Form
    {
        private NpgsqlConnection connection;
        private string connectionString = "Host=localhost;Port=5432;Database=testdemo;Username=postgres;Password=nikitos";
        string[] tables = { "Адреса", "Брак", "Директора", "Должность", "Качество", "Материалы", "Партнёры", "Поставщики", "Продукция", "Производство", "Сотрудники", "Тип_продукции" };

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
                    Redactor columnNamesForm = new Redactor(columnNames);
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


        private void подключитьсяКБдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (подключитьсяКБдToolStripMenuItem.Text == "подключиться к бд")
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("Подключение к базе данных PostgreSQL успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                подключитьсяКБдToolStripMenuItem.Text = "Отключиться от БД";
            }
            else if (подключитьсяКБдToolStripMenuItem.Text == "Отключиться от БД")
            {
                connection.Close();
                dataGridView.DataSource = null;
                MessageBox.Show("Отключене от базы данных PostgreSQL успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                подключитьсяКБдToolStripMenuItem.Text = "подключиться к бд";
            }
        }
    
    

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}

public class ApplicationDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testdemo;Username=postgres;Password=nikitos");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Дополнительные настройки модели, если это необходимо
    }
}