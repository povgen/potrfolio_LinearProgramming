namespace LinearProgramming
{
    partial class Result
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NumTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiCj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Basis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumTable,
            this.CiCj,
            this.Basis,
            this.Bi});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(800, 553);
            this.dataGridView1.TabIndex = 1;
            // 
            // NumTable
            // 
            this.NumTable.HeaderText = "№";
            this.NumTable.Name = "NumTable";
            this.NumTable.Width = 25;
            // 
            // CiCj
            // 
            this.CiCj.HeaderText = "Ci Cj";
            this.CiCj.Name = "CiCj";
            this.CiCj.Width = 25;
            // 
            // Basis
            // 
            this.Basis.HeaderText = "Базис";
            this.Basis.Name = "Basis";
            this.Basis.Width = 50;
            // 
            // Bi
            // 
            this.Bi.HeaderText = "Bi";
            this.Bi.Name = "Bi";
            this.Bi.Width = 50;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 553);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Result";
            this.Text = "Решение";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiCj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Basis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bi;
    }
}