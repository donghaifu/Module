﻿namespace TreeView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dgvSalesList = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.下级名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(38, 23);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(441, 558);
            this.treeView1.TabIndex = 0;
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
            this.dgvSalesList.Location = new System.Drawing.Point(527, 93);
            this.dgvSalesList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvSalesList.Name = "dgvSalesList";
            this.dgvSalesList.ReadOnly = true;
            this.dgvSalesList.RowTemplate.Height = 23;
            this.dgvSalesList.Size = new System.Drawing.Size(776, 496);
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SalesNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.SalesNo.HeaderText = "上级";
            this.SalesNo.Name = "SalesNo";
            this.SalesNo.ReadOnly = true;
            this.SalesNo.Width = 62;
            // 
            // SalesName
            // 
            this.SalesName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SalesName.DataPropertyName = "NextLevel";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SalesName.DefaultCellStyle = dataGridViewCellStyle4;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(527, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 25);
            this.textBox1.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(700, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 615);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvSalesList);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dgvSalesList;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn 下级名称;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

