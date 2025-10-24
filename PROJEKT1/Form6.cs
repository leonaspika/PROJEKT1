using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PROJEKT1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            string path = "zivotinje.txt";

            Label lbl6 = FindLabel("label6"); // broj ukupnih životinja
            Label lbl7 = FindLabel("label7"); // broj trenutno prisutnih
            Label lbl8 = FindLabel("label8"); // broj udomljenih
            Label lbl9 = FindLabel("label9"); // prosječna dob
            Label lbl10 = FindLabel("label10"); // broj životinja po vrstama (multiline)

            if (!File.Exists(path))
            {
                if (lbl6 != null) lbl6.Text = "0";
                if (lbl7 != null) lbl7.Text = "0";
                if (lbl8 != null) lbl8.Text = "0";
                if (lbl9 != null) lbl9.Text = "-";
                if (lbl10 != null) lbl10.Text = "Nema zapisa.";
                return;
            }

            var lines = File.ReadAllLines(path)
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .ToArray();

            int total = lines.Length;
            int adopted = 0;
            int sumAges = 0;
            int ageCount = 0;
            var speciesCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in lines)
            {
                var fields = line.Split('|');

                // napomena (index 8) may contain "udomljen"
                string napomena = fields.Length > 8 ? (fields[8] ?? string.Empty) : string.Empty;
                if (!string.IsNullOrWhiteSpace(napomena) && napomena.IndexOf("udomljen", StringComparison.OrdinalIgnoreCase) >= 0)
                    adopted++;

                // dob at index 4
                if (fields.Length > 4 && int.TryParse(fields[4], out int dob))
                {
                    sumAges += dob;
                    ageCount++;
                }

                // vrsta at index 1
                string vrsta = (fields.Length > 1 && !string.IsNullOrWhiteSpace(fields[1])) ? fields[1] : "Nepoznato";
                if (speciesCounts.ContainsKey(vrsta))
                    speciesCounts[vrsta]++;
                else
                    speciesCounts[vrsta] = 1;
            }

            int present = total - adopted;
            string avgAge = ageCount > 0 ? Math.Round((double)sumAges / ageCount, 2).ToString("0.##") : "-";

            if (lbl6 != null) lbl6.Text = total.ToString();
            if (lbl7 != null) lbl7.Text = present.ToString();
            if (lbl8 != null) lbl8.Text = adopted.ToString();
            if (lbl9 != null) lbl9.Text = avgAge;

            if (lbl10 != null)
            {
                if (speciesCounts.Count == 0)
                {
                    lbl10.Text = "Nema podataka o vrstama.";
                }
                else
                {
                    var outLines = speciesCounts
                        .OrderByDescending(k => k.Value)
                        .ThenBy(k => k.Key)
                        .Select(kvp => $"{kvp.Key}: {kvp.Value}");
                    lbl10.Text = string.Join(Environment.NewLine, outLines);
                }
            }
        }

        private Label? FindLabel(string name)
        {
            var ctrl = this.Controls.Find(name, true).FirstOrDefault();
            return ctrl as Label;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
