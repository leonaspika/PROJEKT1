namespace PROJEKT1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 255, 255);
            button1.Font = new Font("Kristen ITC", 14.25F, FontStyle.Bold);
            button1.Location = new Point(284, 64);
            button1.Margin = new Padding(5, 5, 5, 5);
            button1.Name = "button1";
            button1.Size = new Size(537, 63);
            button1.TabIndex = 0;
            button1.Text = "Unos životinje";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 255, 192);
            button3.Font = new Font("Kristen ITC", 14.25F, FontStyle.Bold);
            button3.Location = new Point(284, 217);
            button3.Margin = new Padding(5, 5, 5, 5);
            button3.Name = "button3";
            button3.Size = new Size(537, 69);
            button3.TabIndex = 2;
            button3.Text = "Filtriranje";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(192, 192, 255);
            button4.Font = new Font("Kristen ITC", 14.25F, FontStyle.Bold);
            button4.Location = new Point(284, 296);
            button4.Margin = new Padding(5, 5, 5, 5);
            button4.Name = "button4";
            button4.Size = new Size(537, 59);
            button4.TabIndex = 3;
            button4.Text = "Udomljavanje";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 192, 192);
            button5.Font = new Font("Kristen ITC", 14.25F, FontStyle.Bold);
            button5.Location = new Point(284, 365);
            button5.Margin = new Padding(5, 5, 5, 5);
            button5.Name = "button5";
            button5.Size = new Size(537, 61);
            button5.TabIndex = 4;
            button5.Text = "Statistika";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(224, 224, 224);
            button6.Font = new Font("Kristen ITC", 14.25F, FontStyle.Bold);
            button6.Location = new Point(376, 463);
            button6.Margin = new Padding(5, 5, 5, 5);
            button6.Name = "button6";
            button6.Size = new Size(352, 41);
            button6.TabIndex = 5;
            button6.Text = "Izlaz";
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(255, 192, 255);
            button7.Font = new Font("Kristen ITC", 14.25F, FontStyle.Bold);
            button7.Location = new Point(284, 139);
            button7.Margin = new Padding(5, 5, 5, 5);
            button7.Name = "button7";
            button7.Size = new Size(537, 68);
            button7.TabIndex = 1;
            button7.Text = "Pregled";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1600, 810);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button7);
            Controls.Add(button1);
            Font = new Font("Kristen ITC", 14.25F, FontStyle.Bold);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
