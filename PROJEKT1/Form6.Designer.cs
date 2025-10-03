namespace PROJEKT1
{
    partial class Form6
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Lucida Console", 12F);
            label1.ForeColor = Color.FromArgb(255, 192, 192);
            label1.Location = new Point(40, 106);
            label1.Name = "label1";
            label1.Size = new Size(237, 16);
            label1.TabIndex = 0;
            label1.Text = "Broj ukupnih životinja:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("Lucida Console", 12F);
            label2.ForeColor = Color.FromArgb(255, 192, 192);
            label2.Location = new Point(40, 154);
            label2.Name = "label2";
            label2.Size = new Size(247, 16);
            label2.TabIndex = 1;
            label2.Text = "Broj trenutno prisutnih:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Font = new Font("Lucida Console", 12F);
            label3.ForeColor = Color.FromArgb(255, 192, 192);
            label3.Location = new Point(40, 209);
            label3.Name = "label3";
            label3.Size = new Size(167, 16);
            label3.TabIndex = 2;
            label3.Text = "Broj udomljenih:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(323, 104);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(323, 202);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(323, 152);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(323, 244);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(323, 291);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaption;
            label5.Font = new Font("Lucida Console", 12F);
            label5.ForeColor = Color.FromArgb(255, 192, 192);
            label5.Location = new Point(40, 298);
            label5.Name = "label5";
            label5.Size = new Size(267, 16);
            label5.TabIndex = 4;
            label5.Text = "Broj životinja po vrstama:";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Font = new Font("Lucida Console", 12F);
            label4.ForeColor = Color.FromArgb(255, 192, 192);
            label4.Location = new Point(40, 251);
            label4.Name = "label4";
            label4.Size = new Size(147, 16);
            label4.TabIndex = 3;
            label4.Text = "Prosječna dob:";
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form6";
            Text = "Form6";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label5;
        private Label label4;
    }
}