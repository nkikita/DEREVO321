using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DEREVO321
{
    public partial class Redactor : Form
    {
        private readonly List<TextBox> textBoxes = new List<TextBox>();
        private readonly ApplicationContext _dbContext;
        private readonly string _tableName;
        private readonly List<string> _columnNames;

        public Redactor(List<string> columnNames, string tableName, ApplicationContext dbContext)
        {
            InitializeComponent();

            _columnNames = columnNames;
            _tableName = tableName;
            _dbContext = dbContext;

            Font coreFont = new Font("Segoe UI", 12, FontStyle.Bold);

            Button bt = new Button
            {
                Width = 200,
                Height = 70,
                Text = "Записать",
                Dock = DockStyle.Bottom,
                Font = coreFont,
            };

            int yPos = 10;

            foreach (var name in columnNames)
            {
                Label label = new Label
                {
                    Text = name,
                    Location = new Point(10, yPos),
                    Font = coreFont,
                    AutoSize = true
                };

                TextBox tb = new TextBox
                {
                    Location = new Point(360, yPos),
                    Font = coreFont,
                    AutoSize = true
                };

                this.Controls.Add(label);
                this.Controls.Add(tb);
                textBoxes.Add(tb);

                yPos += 30;
            }

            bt.Click += async (sender, e) =>
            {
                try
                {
                    await _dbContext.AddToTableAsync(_tableName, _columnNames, textBoxes);
                    MessageBox.Show("Данные успешно записаны!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Controls.Add(bt);
        }

        private void Redactor_Load(object sender, EventArgs e)
        {
        }
    }

    public class ApplicationContext : DbContext
    {
        public async Task<Dictionary<string, string>> GetColumnTypesAsync(string tableName)
        {
            var columnTypes = new Dictionary<string, string>();

            var query = @"
            SELECT column_name, data_type
            FROM information_schema.columns
            WHERE table_name = @p0";

            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.Parameters.Add(new Npgsql.NpgsqlParameter("@p0", tableName));

                await Database.OpenConnectionAsync();
                try
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            columnTypes.Add(reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
                finally
                {
                    await Database.CloseConnectionAsync();
                }
            }

            return columnTypes;
        }

        public async Task AddToTableAsync(string tableName, List<string> columnNames, List<TextBox> textBoxes)
        {
            var values = new List<object>();
            var columnTypes = await GetColumnTypesAsync(tableName);

            for (int i = 0; i < columnNames.Count; i++)
            {
                string columnName = columnNames[i];
                string dataType = columnTypes.ContainsKey(columnName) ? columnTypes[columnName] : "text";

                var inputValue = textBoxes[i].Text;

                object convertedValue = dataType switch
                {
                    "integer" => int.TryParse(inputValue, out var intValue) ? intValue : throw new FormatException($"Неверный формат числа для столбца {columnName}"),
                    "decimal" or "numeric" => decimal.TryParse(inputValue, out var decimalValue) ? decimalValue : throw new FormatException($"Неверный формат числа для столбца {columnName}"),
                    "float" or "double precision" => float.TryParse(inputValue, out var floatValue) ? floatValue : throw new FormatException($"Неверный формат числа для столбца {columnName}"),
                    "boolean" => bool.TryParse(inputValue, out var boolValue) ? boolValue : throw new FormatException($"Неверный формат булевого значения для столбца {columnName}"),
                    "date" => DateTime.TryParse(inputValue, out var dateValue) ? dateValue : throw new FormatException($"Неверный формат даты для столбца {columnName}"),
                    _ => inputValue
                };

                values.Add(convertedValue);
            }

            var query = $@"
            INSERT INTO ""{tableName}"" ({string.Join(", ", columnNames)})
            VALUES ({string.Join(", ", columnNames.Select((_, i) => $"@p{i}"))})";

            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                for (int i = 0; i < values.Count; i++)
                {
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = $"@p{i}";
                    parameter.Value = values[i] ?? DBNull.Value;
                    command.Parameters.Add(parameter);
                }

                await Database.OpenConnectionAsync();
                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                finally
                {
                    await Database.CloseConnectionAsync();
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DEMO;Username=postgres;Password=nikitos");
        }
    }

}