namespace TreeView
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSalesList = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.下级名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSalesList
            // 
            this.dgvSalesList.AllowUserToAddRows = false;
            this.dgvSalesList.AllowUserToDeleteRows = false;
            this.dgvSalesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.SalesNo,
            this.SalesName,
            this.下级名称});
            this.dgvSalesList.Location = new System.Drawing.Point(231, 23);
            this.dgvSalesList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvSalesList.Name = "dgvSalesList";
            this.dgvSalesList.ReadOnly = true;
            this.dgvSalesList.RowTemplate.Height = 23;
            this.dgvSalesList.Size = new System.Drawing.Size(741, 566);
            this.dgvSalesList.TabIndex = 20;
            // 
            // 序号
            // 
            this.序号.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.序号.DataPropertyName = "No";
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 62;
            // 
            // SalesNo
            // 
            this.SalesNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SalesNo.DataPropertyName = "AssembleNo";
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SalesNo.DefaultCellStyle = dataGridViewCellStyle21;
            this.SalesNo.HeaderText = "上级";
            this.SalesNo.Name = "SalesNo";
            this.SalesNo.ReadOnly = true;
            this.SalesNo.Width = 62;
            // 
            // SalesName
            // 
            this.SalesName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SalesName.DataPropertyName = "NextLevel";
            dataGridViewCellStyle22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SalesName.DefaultCellStyle = dataGridViewCellStyle22;
            this.SalesName.HeaderText = "下级";
            this.SalesName.Name = "SalesName";
            this.SalesName.ReadOnly = true;
            this.SalesName.Width = 62;
            // 
            // 下级名称
            // 
            this.下级名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.下级名称.DataPropertyName = "NextLevelName";
            this.下级名称.HeaderText = "下级名称";
            this.下级名称.Name = "下级名称";
            this.下级名称.ReadOnly = true;
            this.下级名称.Width = 92;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(33, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 23);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.TextUpdate += new System.EventHandler(this.comboBox1_TextUpdate);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 154);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 25);
            this.textBox1.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 615);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgvSalesList);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalesList;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn 下级名称;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

