﻿namespace EmployeeControlWinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.словарьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.местоЖительстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.страныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.областиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.городаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.улицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рОВДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.военныеКомисариатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.составСемьиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отпускаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.ExcelButton = new System.Windows.Forms.Button();
            this.WordT2ExportButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FilterLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.AddButton2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(474, 327);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(76, 29);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Location = new System.Drawing.Point(555, 327);
            this.EditButton.Margin = new System.Windows.Forms.Padding(2);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(76, 29);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(636, 327);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(76, 29);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(9, 81);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(704, 216);
            this.dataGridView1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.словарьToolStripMenuItem,
            this.сотрудникиToolStripMenuItem,
            this.отпускаToolStripMenuItem,
            this.SearchTextBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(722, 27);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // словарьToolStripMenuItem
            // 
            this.словарьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.местоЖительстваToolStripMenuItem,
            this.сотрудникиToolStripMenuItem1});
            this.словарьToolStripMenuItem.Name = "словарьToolStripMenuItem";
            this.словарьToolStripMenuItem.Size = new System.Drawing.Size(72, 23);
            this.словарьToolStripMenuItem.Text = "Словарь";
            // 
            // местоЖительстваToolStripMenuItem
            // 
            this.местоЖительстваToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.страныToolStripMenuItem,
            this.областиToolStripMenuItem,
            this.городаToolStripMenuItem,
            this.улицыToolStripMenuItem,
            this.рОВДToolStripMenuItem,
            this.военныеКомисариатыToolStripMenuItem});
            this.местоЖительстваToolStripMenuItem.Name = "местоЖительстваToolStripMenuItem";
            this.местоЖительстваToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.местоЖительстваToolStripMenuItem.Text = "Населенные пункты";
            // 
            // страныToolStripMenuItem
            // 
            this.страныToolStripMenuItem.Name = "страныToolStripMenuItem";
            this.страныToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.страныToolStripMenuItem.Text = "Страны";
            this.страныToolStripMenuItem.Click += new System.EventHandler(this.страныToolStripMenuItem_Click);
            // 
            // областиToolStripMenuItem
            // 
            this.областиToolStripMenuItem.Name = "областиToolStripMenuItem";
            this.областиToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.областиToolStripMenuItem.Text = "Области";
            this.областиToolStripMenuItem.Click += new System.EventHandler(this.областиToolStripMenuItem_Click);
            // 
            // городаToolStripMenuItem
            // 
            this.городаToolStripMenuItem.Name = "городаToolStripMenuItem";
            this.городаToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.городаToolStripMenuItem.Text = "Города";
            this.городаToolStripMenuItem.Click += new System.EventHandler(this.городаToolStripMenuItem_Click);
            // 
            // улицыToolStripMenuItem
            // 
            this.улицыToolStripMenuItem.Name = "улицыToolStripMenuItem";
            this.улицыToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.улицыToolStripMenuItem.Text = "Улицы";
            this.улицыToolStripMenuItem.Click += new System.EventHandler(this.улицыToolStripMenuItem_Click);
            // 
            // рОВДToolStripMenuItem
            // 
            this.рОВДToolStripMenuItem.Name = "рОВДToolStripMenuItem";
            this.рОВДToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.рОВДToolStripMenuItem.Text = "РОВД";
            this.рОВДToolStripMenuItem.Click += new System.EventHandler(this.рОВДToolStripMenuItem_Click);
            // 
            // военныеКомисариатыToolStripMenuItem
            // 
            this.военныеКомисариатыToolStripMenuItem.Name = "военныеКомисариатыToolStripMenuItem";
            this.военныеКомисариатыToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.военныеКомисариатыToolStripMenuItem.Text = "Военные комисариаты";
            this.военныеКомисариатыToolStripMenuItem.Click += new System.EventHandler(this.военныеКомисариатыToolStripMenuItem_Click);
            // 
            // сотрудникиToolStripMenuItem1
            // 
            this.сотрудникиToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.составСемьиToolStripMenuItem});
            this.сотрудникиToolStripMenuItem1.Name = "сотрудникиToolStripMenuItem1";
            this.сотрудникиToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.сотрудникиToolStripMenuItem1.Text = "Сотрудники";
            // 
            // составСемьиToolStripMenuItem
            // 
            this.составСемьиToolStripMenuItem.Name = "составСемьиToolStripMenuItem";
            this.составСемьиToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.составСемьиToolStripMenuItem.Text = "Состав семьи";
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(89, 23);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // отпускаToolStripMenuItem
            // 
            this.отпускаToolStripMenuItem.Name = "отпускаToolStripMenuItem";
            this.отпускаToolStripMenuItem.Size = new System.Drawing.Size(67, 23);
            this.отпускаToolStripMenuItem.Text = "Отпуска";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SearchTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(150, 23);
            this.SearchTextBox.Text = "Поиск:";
            this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyDown);
            this.SearchTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SearchTextBox_MouseDown);
            this.SearchTextBox.MouseLeave += new System.EventHandler(this.SearchTextBox_MouseLeave);
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // ExcelButton
            // 
            this.ExcelButton.Location = new System.Drawing.Point(4, 16);
            this.ExcelButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExcelButton.Name = "ExcelButton";
            this.ExcelButton.Size = new System.Drawing.Size(86, 29);
            this.ExcelButton.TabIndex = 5;
            this.ExcelButton.Text = "Excel";
            this.ExcelButton.UseVisualStyleBackColor = true;
            this.ExcelButton.Click += new System.EventHandler(this.ExcelButton_Click);
            // 
            // WordT2ExportButton
            // 
            this.WordT2ExportButton.Location = new System.Drawing.Point(95, 17);
            this.WordT2ExportButton.Margin = new System.Windows.Forms.Padding(2);
            this.WordT2ExportButton.Name = "WordT2ExportButton";
            this.WordT2ExportButton.Size = new System.Drawing.Size(160, 29);
            this.WordT2ExportButton.TabIndex = 6;
            this.WordT2ExportButton.Text = "Личная карточка работника";
            this.WordT2ExportButton.UseVisualStyleBackColor = true;
            this.WordT2ExportButton.Click += new System.EventHandler(this.WordT2ExportButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.WordT2ExportButton);
            this.groupBox1.Controls.Add(this.ExcelButton);
            this.groupBox1.Location = new System.Drawing.Point(9, 311);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(260, 54);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Экспорт";
            // 
            // FilterLayoutPanel
            // 
            this.FilterLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterLayoutPanel.Location = new System.Drawing.Point(9, 25);
            this.FilterLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.FilterLayoutPanel.Name = "FilterLayoutPanel";
            this.FilterLayoutPanel.Size = new System.Drawing.Size(704, 52);
            this.FilterLayoutPanel.TabIndex = 8;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // AddButton2
            // 
            this.AddButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton2.Location = new System.Drawing.Point(311, 327);
            this.AddButton2.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton2.Name = "AddButton2";
            this.AddButton2.Size = new System.Drawing.Size(148, 29);
            this.AddButton2.TabIndex = 9;
            this.AddButton2.Text = "Добавить2";
            this.AddButton2.UseVisualStyleBackColor = true;
            this.AddButton2.Visible = false;
            this.AddButton2.Click += new System.EventHandler(this.AddButton2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 366);
            this.Controls.Add(this.AddButton2);
            this.Controls.Add(this.FilterLayoutPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem словарьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.Button ExcelButton;
        private System.Windows.Forms.Button WordT2ExportButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem местоЖительстваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem городаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem улицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem составСемьиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отпускаToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel FilterLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem рОВДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem военныеКомисариатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem страныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem областиToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button AddButton2;
        private System.Windows.Forms.ToolStripTextBox SearchTextBox;
    }
}

