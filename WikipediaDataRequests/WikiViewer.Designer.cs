namespace WikipediaDataRequests
{
    partial class WikiViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.limit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.yPos = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xPos = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.compareInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compareIndexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleImage1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleImage2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compareInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.limit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.yPos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.xPos);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 44);
            this.panel1.TabIndex = 0;
            // 
            // limit
            // 
            this.limit.Location = new System.Drawing.Point(382, 12);
            this.limit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.limit.Name = "limit";
            this.limit.Size = new System.Drawing.Size(120, 20);
            this.limit.TabIndex = 7;
            this.limit.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "limit";
            // 
            // yPos
            // 
            this.yPos.DecimalPlaces = 6;
            this.yPos.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.yPos.Location = new System.Drawing.Point(209, 12);
            this.yPos.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.yPos.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.yPos.Name = "yPos";
            this.yPos.Size = new System.Drawing.Size(120, 20);
            this.yPos.TabIndex = 5;
            this.yPos.Value = new decimal(new int[] {
            122399677,
            0,
            0,
            -2147090432});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "lon";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "lat";
            // 
            // xPos
            // 
            this.xPos.DecimalPlaces = 6;
            this.xPos.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.xPos.Location = new System.Drawing.Point(36, 12);
            this.xPos.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.xPos.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.xPos.Name = "xPos";
            this.xPos.Size = new System.Drawing.Size(120, 20);
            this.xPos.TabIndex = 2;
            this.xPos.Value = new decimal(new int[] {
            37786971,
            0,
            0,
            393216});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.propertyGrid);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 460);
            this.panel2.TabIndex = 1;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGrid.Location = new System.Drawing.Point(748, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(3, 460);
            this.propertyGrid.TabIndex = 2;
            this.propertyGrid.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(745, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 460);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.compareIndexDataGridViewTextBoxColumn,
            this.titleImage1DataGridViewTextBoxColumn,
            this.titleImage2DataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.compareInfoBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(745, 460);
            this.dataGridView.TabIndex = 0;
            // 
            // compareInfoBindingSource
            // 
            this.compareInfoBindingSource.DataSource = typeof(WikipediaDataRequests.CompareInfo);
            // 
            // compareIndexDataGridViewTextBoxColumn
            // 
            this.compareIndexDataGridViewTextBoxColumn.DataPropertyName = "CompareIndex";
            this.compareIndexDataGridViewTextBoxColumn.HeaderText = "CompareIndex";
            this.compareIndexDataGridViewTextBoxColumn.Name = "compareIndexDataGridViewTextBoxColumn";
            this.compareIndexDataGridViewTextBoxColumn.Width = 200;
            // 
            // titleImage1DataGridViewTextBoxColumn
            // 
            this.titleImage1DataGridViewTextBoxColumn.DataPropertyName = "TitleImage1";
            this.titleImage1DataGridViewTextBoxColumn.HeaderText = "TitleImage1";
            this.titleImage1DataGridViewTextBoxColumn.Name = "titleImage1DataGridViewTextBoxColumn";
            this.titleImage1DataGridViewTextBoxColumn.Width = 250;
            // 
            // titleImage2DataGridViewTextBoxColumn
            // 
            this.titleImage2DataGridViewTextBoxColumn.DataPropertyName = "TitleImage2";
            this.titleImage2DataGridViewTextBoxColumn.HeaderText = "TitleImage2";
            this.titleImage2DataGridViewTextBoxColumn.Name = "titleImage2DataGridViewTextBoxColumn";
            this.titleImage2DataGridViewTextBoxColumn.Width = 250;
            // 
            // WikiViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 504);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WikiViewer";
            this.Text = "Wiki";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPos)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compareInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown limit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown yPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown xPos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource compareInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn compareIndexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleImage1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleImage2DataGridViewTextBoxColumn;
    }
}

