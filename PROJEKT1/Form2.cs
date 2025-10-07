using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEKT1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string spol;
            if (radioButton1.Checked)
            {
                spol = "Musko";
            }
            else if (radioButton2.Checked)
            {
                spol = "Zensko";
            }
            else
            {
                spol = "Nije odabrano";
            }
            string cijepljen;
            if (checkBox1.Checked)
            {
                cijepljen = "Cijepljen";
            }
            else
            {
                cijepljen = "Nije cijepljen";
            }
            string kastriran;
            if (checkBox2.Checked)
            {
                kastriran = "Kastriran ";
            }
            else
            { kastriran = "Nije kastriran"; }
            string zapis = textBox1.Text + " | " + textBox2 + " | " + textBox3 + " | " + " | " + spol + " | " + numericUpDown1 + " | " + dateTimePicker1 + " | " + cijepljen + "| " + kastriran;
            Admin.UnosUdatoteku(zapis);
            MessageBox.Show("Uspjesno ste unijeli ljubimca u bazu podataka");
            File.AppendAllText("zivotinje.txt", zapis + Environment.NewLine);

        
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            numericUpDown1.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }
    }
}

