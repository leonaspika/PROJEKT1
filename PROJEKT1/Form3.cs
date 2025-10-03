using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEKT1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadRecords();
        }
        private void LoadRecords()
        {
            string filePath = "zivotinje.txt";
            if(File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                listBox1.Items.Clear();
                foreach (string line in lines)
                {
                    string formattedLine = line.Replace("|", " "); 
                    listBox1.Items.Add(formattedLine);
                }
            }
            else
            {
                listBox1.Items.Add("Nema zapisa.");  
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
