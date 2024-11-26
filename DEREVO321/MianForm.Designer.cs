namespace DEREVO321
{
    partial class MianForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MianForm));
            menuStrip1 = new MenuStrip();
            подключитьсяКБдToolStripMenuItem = new ToolStripMenuItem();
            открытьТаблицыToolStripMenuItem = new ToolStripMenuItem();
            редактированиеToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.GradientActiveCaption;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { подключитьсяКБдToolStripMenuItem, открытьТаблицыToolStripMenuItem, редактированиеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1126, 36);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // подключитьсяКБдToolStripMenuItem
            // 
            подключитьсяКБдToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            подключитьсяКБдToolStripMenuItem.Name = "подключитьсяКБдToolStripMenuItem";
            подключитьсяКБдToolStripMenuItem.Size = new Size(222, 32);
            подключитьсяКБдToolStripMenuItem.Text = "подключиться к бд";
            подключитьсяКБдToolStripMenuItem.Click += подключитьсяКБдToolStripMenuItem_Click;
            // 
            // открытьТаблицыToolStripMenuItem
            // 
            открытьТаблицыToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            открытьТаблицыToolStripMenuItem.Name = "открытьТаблицыToolStripMenuItem";
            открытьТаблицыToolStripMenuItem.Size = new Size(193, 32);
            открытьТаблицыToolStripMenuItem.Text = "открыть таблицy";
            // 
            // редактированиеToolStripMenuItem
            // 
            редактированиеToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            редактированиеToolStripMenuItem.Size = new Size(192, 32);
            редактированиеToolStripMenuItem.Text = "редактирование";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(989, 477);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(989, 510);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;
            // 
            // MianForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 232, 211);
            ClientSize = new Size(1126, 541);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            Cursor = Cursors.SizeAll;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MianForm";
            RightToLeftLayout = true;
            Text = "Мастер Пол";
            Load += MianForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem открытьТаблицыToolStripMenuItem;
        private ToolStripMenuItem редактированиеToolStripMenuItem;
        private ToolStripMenuItem подключитьсяКБдToolStripMenuItem;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
