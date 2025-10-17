using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJEKT1
{
    public partial class Form4 : Form
    {
        private List<string[]> allRecords = new List<string[]>();
        private const int VrstaIndex = 1;    // "vrsta" polje
        private const int CijepljenIndex = 6; // "cijepljen:da/ne" polje
        private const int KastriranIndex = 7; // "kastriran:da/ne" polje

        public Form4()
        {
            InitializeComponent();

            // ensure handlers are attached (safe if Designer created controls)
            if (comboBox1 != null)
                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            if (button1 != null)
                button1.Click += button1_Click;

            UcitajZapise();
            PopuniComboBox();
        }

        private void UcitajZapise()
        {
            allRecords.Clear();
            string filePath = "zivotinje.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    var fields = line.Split('|');
                    if (fields.Length >= 10)
                        allRecords.Add(fields);
                }
            }
        }

        private void PopuniComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Prikaži sve");

            var vrste = allRecords.Select(r => r[VrstaIndex]).Distinct().OrderBy(x => x);
            foreach (var vrsta in vrste)
                comboBox1.Items.Add("Vrsta: " + vrsta);

            comboBox1.Items.Add("Cijepljeni");
            comboBox1.Items.Add("Nisu cijepljeni");

            comboBox1.Items.Add("Kastrirani");
            comboBox1.Items.Add("Nisu kastrirani");

            comboBox1.SelectedIndex = 0;
        }

        // helper to show all records in listBox1 using same display format as Form3
        private void PrikaziSve()
        {
            listBox1.Items.Clear();
            foreach (var fields in allRecords)
                listBox1.Items.Add($"{fields[0]} ({fields[VrstaIndex]})");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string selected = comboBox1.SelectedItem?.ToString();

            if (selected == "Prikaži sve")
            {
                PrikaziSve();
            }
            else if (selected != null && selected.StartsWith("Vrsta: "))
            {
                string vrsta = selected.Substring(7);
                foreach (var fields in allRecords.Where(r => r[VrstaIndex] == vrsta))
                    listBox1.Items.Add($"{fields[0]} ({fields[VrstaIndex]})");
            }
            else if (selected == "Cijepljeni")
            {
                foreach (var fields in allRecords.Where(r => r[CijepljenIndex].ToLower().Contains("da")))
                    listBox1.Items.Add($"{fields[0]} ({fields[VrstaIndex]})");
            }
            else if (selected == "Nisu cijepljeni")
            {
                foreach (var fields in allRecords.Where(r => r[CijepljenIndex].ToLower().Contains("ne")))
                    listBox1.Items.Add($"{fields[0]} ({fields[VrstaIndex]})");
            }
            else if (selected == "Kastrirani")
            {
                foreach (var fields in allRecords.Where(r => r[KastriranIndex].ToLower().Contains("da")))
                    listBox1.Items.Add($"{fields[0]} ({fields[VrstaIndex]})");
            }
            else if (selected == "Nisu kastrirani")
            {
                foreach (var fields in allRecords.Where(r => r[KastriranIndex].ToLower().Contains("ne")))
                    listBox1.Items.Add($"{fields[0]} ({fields[VrstaIndex]})");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Move comboBox to "Prikaži sve" item when reset button is clicked
            if (comboBox1 != null)
            {
                int index = comboBox1.Items.IndexOf("Prikaži sve");
                if (index >= 0)
                    comboBox1.SelectedIndex = index;
                else if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }

            // Ensure list shows all items
            PrikaziSve();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
