namespace LinearProgramming
{
    partial class Form1
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
            this.button3 = new System.Windows.Forms.Button();
            this.countOfLimit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CounOfX = new System.Windows.Forms.NumericUpDown();
            this.funcPanel = new System.Windows.Forms.Panel();
            this.maxOrMinComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.limitPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.countOfLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounOfX)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(137, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "записать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // countOfLimit
            // 
            this.countOfLimit.Location = new System.Drawing.Point(180, 36);
            this.countOfLimit.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.countOfLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countOfLimit.Name = "countOfLimit";
            this.countOfLimit.Size = new System.Drawing.Size(65, 20);
            this.countOfLimit.TabIndex = 11;
            this.countOfLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countOfLimit.ValueChanged += new System.EventHandler(this.DrawInputsBoxes);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Кол-во ограничений задачи:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Кол-во x в функции:";
            // 
            // CounOfX
            // 
            this.CounOfX.Location = new System.Drawing.Point(180, 10);
            this.CounOfX.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.CounOfX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CounOfX.Name = "CounOfX";
            this.CounOfX.Size = new System.Drawing.Size(65, 20);
            this.CounOfX.TabIndex = 7;
            this.CounOfX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CounOfX.ValueChanged += new System.EventHandler(this.DrawInputsBoxes);
            // 
            // funcPanel
            // 
            this.funcPanel.Location = new System.Drawing.Point(262, 36);
            this.funcPanel.Name = "funcPanel";
            this.funcPanel.Size = new System.Drawing.Size(706, 98);
            this.funcPanel.TabIndex = 0;
            // 
            // maxOrMinComboBox
            // 
            this.maxOrMinComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maxOrMinComboBox.FormattingEnabled = true;
            this.maxOrMinComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maxOrMinComboBox.Items.AddRange(new object[] {
            "max f(x)",
            "min f(x)"});
            this.maxOrMinComboBox.Location = new System.Drawing.Point(180, 67);
            this.maxOrMinComboBox.Name = "maxOrMinComboBox";
            this.maxOrMinComboBox.Size = new System.Drawing.Size(65, 21);
            this.maxOrMinComboBox.TabIndex = 16;
            this.maxOrMinComboBox.SelectedIndexChanged += new System.EventHandler(this.DrawInputsBoxes);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Функция на:";
            // 
            // limitPanel
            // 
            this.limitPanel.Location = new System.Drawing.Point(28, 156);
            this.limitPanel.Name = "limitPanel";
            this.limitPanel.Size = new System.Drawing.Size(940, 378);
            this.limitPanel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Введите функцию";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Введите ограничения, кроме X1-n>0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 546);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.funcPanel);
            this.Controls.Add(this.limitPanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxOrMinComboBox);
            this.Controls.Add(this.countOfLimit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CounOfX);
            this.Name = "Form1";
            this.Text = "М-метод";
            ((System.ComponentModel.ISupportInitialize)(this.countOfLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounOfX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown countOfLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown CounOfX;
        private System.Windows.Forms.ComboBox maxOrMinComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel funcPanel;
        private System.Windows.Forms.Panel limitPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

