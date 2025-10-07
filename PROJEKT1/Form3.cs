using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PROJEKT1
{
    public partial class Form3 : Form
    {
        private class AnimalRecord
        {
            public string DisplayText { get; set; }
            public string ImagePath { get; set; }
            public override string ToString() => DisplayText;
        }
      

        public Form3()
        {
            InitializeComponent();
            LoadRecords();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void LoadRecords()
        {
            string filePath = "zivotinje.txt";
            listBox1.Items.Clear();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length >= 8) // prilagodi broj prema stvarnom broju polja
                    {
                        // Prilagodi redoslijed i nazive prema stvarnim podacima!
                        string displayText =
                            $"Ime: {parts[0].Trim()}  " +
                            $"Pasmina: {parts[1].Trim()}  " +
                            $"Vrsta: {parts[2].Trim()}  " +
                            $"Spol: {parts[3].Trim()}  " +
                            $"Dob: {parts[4].Trim()}  " +
                            $"Datum: {parts[5].Trim()}  " +
                            $"Cijepljen: {parts[6].Trim()}  " +
                            $"Kastriran: {parts[7].Trim()}";
                        var record = new AnimalRecord
                        {
                            DisplayText = displayText,
                            ImagePath = parts.Length > 8 ? parts[8].Trim() : ""
                        };
                        listBox1.Items.Add(record);
                    }
                    else
                    {
                        listBox1.Items.Add(line.Replace("|", " "));
                    }
                }
            }
            else
            {
                listBox1.Items.Add("Nema zapisa.");
            }
        }
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is AnimalRecord record && !string.IsNullOrWhiteSpace(record.ImagePath))
            {
                try
                {
                    if (File.Exists(record.ImagePath))
                    {
                        pictureBox1.Image = Image.FromFile(record.ImagePath);
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = null;
            }

        } 
    

  
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}




