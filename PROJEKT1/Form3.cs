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
            this.Load += Form3_Load;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            
        }
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is AnimalRecord record && !string.IsNullOrWhiteSpace(record.ImagePath))
            {
                try
                {
                    if (File.Exists(record.ImagePath))
                    {
                        // load into a copy to avoid locking the file
                        using (var fs = File.OpenRead(record.ImagePath))
                        using (var img = Image.FromStream(fs))
                        {
                            if (pictureBox1.Image != null)
                            {
                                pictureBox1.Image.Dispose();
                                pictureBox1.Image = null;
                            }

                            pictureBox1.Image = new Bitmap(img);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                            pictureBox1.Image = null;
                        }
                    }
                }
                catch
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                }
            }
            else
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var lines = Admin.Svi(); // raw lines with '|' separators
            var records = new List<AnimalRecord>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('|').Select(p => p.Trim()).ToArray();
                if (parts.Length == 0)
                    continue;

                string imageFileName = string.Empty;
                string displayText;

                if (parts.Length == 1)
                {
                    displayText = parts[0];
                }
                else
                {
                    // assume last part is image filename if present
                    imageFileName = parts[^1];
                    displayText = string.Join(" | ", parts.Take(parts.Length - 1));
                }

                string imagePath = null;
                if (!string.IsNullOrWhiteSpace(imageFileName))
                {
                    // images saved to application's startup folder by Form2
                    var candidate = Path.Combine(Application.StartupPath, imageFileName);
                    if (File.Exists(candidate))
                    {
                        imagePath = candidate;
                    }
                    else if (File.Exists(imageFileName))
                    {
                        // fallback if full path was somehow stored
                        imagePath = imageFileName;
                    }
                }

                records.Add(new AnimalRecord { DisplayText = displayText, ImagePath = imagePath });
            }

            listBox1.DataSource = records;
        }
    }
}
    




