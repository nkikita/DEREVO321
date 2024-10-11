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
            menuStrip1.Size = new Size(1126, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // подключитьсяКБдToolStripMenuItem
            // 
            подключитьсяКБдToolStripMenuItem.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            подключитьсяКБдToolStripMenuItem.Name = "подключитьсяКБдToolStripMenuItem";
            подключитьсяКБдToolStripMenuItem.Size = new Size(225, 28);
            подключитьсяКБдToolStripMenuItem.Text = "подключиться к бд";
            подключитьсяКБдToolStripMenuItem.Click += подключитьсяКБдToolStripMenuItem_Click;
            // 
            // открытьТаблицыToolStripMenuItem
            // 
            открытьТаблицыToolStripMenuItem.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            открытьТаблицыToolStripMenuItem.Name = "открытьТаблицыToolStripMenuItem";
            открытьТаблицыToolStripMenuItem.Size = new Size(202, 28);
            открытьТаблицыToolStripMenuItem.Text = "открыть таблицy";
            // 
            // редактированиеToolStripMenuItem
            // 
            редактированиеToolStripMenuItem.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            редактированиеToolStripMenuItem.Size = new Size(196, 28);
            редактированиеToolStripMenuItem.Text = "редактирование";
            // 
            // MianForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1126, 541);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MianForm";
            RightToLeftLayout = true;
            Text = "Form1";
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
    }
}
