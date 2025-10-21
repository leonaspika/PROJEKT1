using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PROJEKT1
{
    public partial class Form5 : Form
    {
        // all lines from file
        private List<string> allLines = new List<string>();

        // mapping from displayed ListBox index -> index in allLines
        private List<int> displayedIndexes = new List<int>();

        // map a semantic name to the textbox that holds contact info
        // use the textbox name that exists in the Designer (textBox1 is used elsewhere in this class)
        private TextBox textBoxKontakt => textBox1;

        public Form5()
        {
            InitializeComponent();
            LoadRecords();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            button1.Click += button1_Click;
        }

        private void LoadRecords()
        {
            string filePath = "zivotinje.txt";
            allLines.Clear();
            displayedIndexes.Clear();
            listBox1.Items.Clear();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                allLines.AddRange(lines);

                for (int i = 0; i < allLines.Count; i++)
                {
                    string line = allLines[i] ?? string.Empty;
                    var fields = line.Split('|');
                    string napomena = fields.Length > 8 ? (fields[8] ?? string.Empty) : string.Empty;

                    // skip records that contain "udomljen" in napomena (case-insensitive)
                    if (!string.IsNullOrEmpty(napomena) &&
                        napomena.IndexOf("udomljen", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        continue;
                    }

                    // display non-adopted records (take up to first 9 fields)
                    string formattedLine = string.Join(", ", line.Split('|').Take(9));
                    listBox1.Items.Add(formattedLine);

                    // MAP displayed item back to real index in allLines
                    displayedIndexes.Add(i);
                }

                if (listBox1.Items.Count == 0)
                    listBox1.Items.Add("Nema dostupnih (neudomljenih) zapisa.");
            }
            else
            {
                listBox1.Items.Add("Nema zapisa.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int displayedIdx = listBox1.SelectedIndex;
            if (displayedIdx < 0 || displayedIdx >= displayedIndexes.Count)
            {
                MessageBox.Show("Odaberite životinju iz popisa prije udomljavanja.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string datumUdomljavanja = dateTimePicker1.Value.Date.ToString("dd.MM.yyyy");
            string udomitelj = (textBox1?.Text ?? string.Empty).Trim();
            string kontakt = (textBoxKontakt?.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(udomitelj))
            {
                MessageBox.Show("Unesite ime udomitelja.", "Nedostaje podatak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Map displayed index to real index in allLines
            int realIndex = displayedIndexes[displayedIdx];
            var fields = allLines[realIndex].Split('|').ToList();
            while (fields.Count < 10)
                fields.Add(string.Empty);

            string napomena = fields[8] ?? string.Empty;

            if (!string.IsNullOrEmpty(napomena) &&
                napomena.IndexOf("udomljen", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var res = MessageBox.Show("Ova životinja izgleda već označena kao udomljena. Želite li ipak nastaviti i ažurirati podatke udomljavanja?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    return;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(napomena))
                    napomena = napomena.Trim() + " ; ";
                napomena += "udomljen";
            }

            napomena = napomena.Trim();
            napomena += $";DatumUdomljavanja:{datumUdomljavanja};Udomitelj:{udomitelj};Kontakt:{kontakt}";

            fields[8] = napomena;

            string updatedLine = string.Join("|", fields);
            allLines[realIndex] = updatedLine;

            try
            {
                File.WriteAllLines("zivotinje.txt", allLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri spremanju datoteke zivotinje.txt: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string logLine = $"{fields.ElementAtOrDefault(0)}|{fields.ElementAtOrDefault(1)}|DatumUdomljavanja:{datumUdomljavanja}|Udomitelj:{udomitelj}|Kontakt:{kontakt}";
                File.AppendAllText("udomljavanja.txt", logLine + Environment.NewLine);
            }
            catch
            {
                // non-fatal; ignore logging failure
            }

            // remove from displayed list because now it's adopted
            if (displayedIdx >= 0 && displayedIdx < listBox1.Items.Count)
            {
                listBox1.Items.RemoveAt(displayedIdx);
                displayedIndexes.RemoveAt(displayedIdx);
            }

            if (listBox1.Items.Count == 0)
                listBox1.Items.Add("Nema dostupnih (neudomljenih) zapisa.");

            MessageBox.Show("Podaci spremljeni. Životinja je označena kao udomljena.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // intentionally left blank (designer event handler)
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // optionally handle selection changes here
        }
    }
}
