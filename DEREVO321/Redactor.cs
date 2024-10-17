using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEREVO321
{
    public partial class Redactor : Form
    {
        public Redactor(List<string> columnNames)
        {
            Font coreFont = new Font("Segoe UI", 12, FontStyle.Bold);
            InitializeComponent();
            Button bt = new Button
            {
                Width = 200,
                Height = 70,
                Text = "Записать",
                Dock = DockStyle.Bottom,
                Font = coreFont,
            };
            int yPos = 10; // Начальная позиция по Y
            foreach (var name in columnNames)
            {
                Label label = new Label
                {
                    Text = name,
                    Location = new Point(10, yPos),
                    Font = coreFont,
                    AutoSize = true 
                };
                TextBox Tb = new TextBox
                {
                    Location = new Point(360, yPos ),
                    Font = coreFont,
                    AutoSize = true
                };
               
                this.Controls.Add(label); // Добавляем Label на форму
                Controls.Add(Tb);
                yPos += 30; // Увеличиваем Y позицию для следующего Label
            }
            Controls.Add(bt);
        }

        private void Redactor_Load(object sender, EventArgs e)
        {
           
        }
    }
}
