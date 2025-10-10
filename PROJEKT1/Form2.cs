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
        private string selectedImagePath;
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

            string savedImageFileName = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    string destDir = Application.StartupPath; // typically bin\Debug\net8.0\...
                    string fileName = Path.GetFileName(selectedImagePath);
                    string destPath = Path.Combine(destDir, fileName);

                    // avoid overwriting existing file in startup folder
                    if (File.Exists(destPath))
                    {
                        string unique = $"{Path.GetFileNameWithoutExtension(fileName)}_{DateTime.Now:yyyyMMddHHmmssfff}{Path.GetExtension(fileName)}";
                        destPath = Path.Combine(destDir, unique);
                        fileName = unique;
                    }

                    File.Copy(selectedImagePath, destPath);
                    savedImageFileName = fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ne mogu kopirati sliku: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Build zapis and append saved image filename as last field if present
            string zapis = textBox1.Text + " | " + textBox2.Text + " | " + textBox3.Text + " | " + " | " + spol + " | " + numericUpDown1.Text + " | " + dateTimePicker1.Text + " | " + cijepljen + "| " + kastriran;
            if (!string.IsNullOrEmpty(savedImageFileName))
            {
                zapis += " | " + savedImageFileName;
            }

            Admin.UnosUdatoteku(zapis);
            MessageBox.Show("Uspjesno ste unijeli ljubimca u bazu podataka");

            // reset form and selected image path
            selectedImagePath = null;
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }



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
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
            openFileDialog1.Title = "Select an image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // store selected path so it can be copied on save
                    selectedImagePath = openFileDialog1.FileName;

                    // Load image from file into a cloned Bitmap to avoid locking the file
                    using (var fs = File.OpenRead(openFileDialog1.FileName))
                    using (var img = Image.FromStream(fs))
                    {
                        // Dispose previous image if any
                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                            pictureBox1.Image = null;
                        }

                        pictureBox1.Image = new Bitmap(img);
                    }

                    // Fit image nicely inside picture box
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ne mogu ucitati sliku: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

