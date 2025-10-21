using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PROJEKT1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populate TextBox controls named textBox1, textBox2, ... with fields from a '|' separated line.
        /// Safe: will only set Text for TextBoxes that actually exist in the Designer.
        /// </summary>
        /// <param name="line">Single record line with fields separated by '|'</param>
        public void PopulateFromLine(string line)
        {
            var fields = (line ?? string.Empty).Split('|').ToList();
            PopulateFromFields(fields);
        }

        /// <summary>
        /// Populate TextBox controls named textBox1..textBoxN from a list of field values.
        /// </summary>
        /// <param name="fields">Field values where fields[0] -> textBox1, fields[1] -> textBox2, ...</param>
        public void PopulateFromFields(IList<string> fields)
        {
            if (fields == null) return;

            // Try to set for textBox1 .. textBox20 (adjust upper bound if your Designer has more)
            int maxBoxes = 20;
            for (int i = 0; i < Math.Min(fields.Count, maxBoxes); i++)
            {
                var tb = FindTextBoxByIndex(i + 1);
                if (tb != null)
                    tb.Text = fields[i] ?? string.Empty;
            }
        }

        /// <summary>
        /// Finds a TextBox by the conventional designer name textBox{index} (searches child controls recursively).
        /// Returns null if not found.
        /// </summary>
        private TextBox? FindTextBoxByIndex(int index)
        {
            string name = "textBox" + index;
            var ctrl = this.Controls.Find(name, true).FirstOrDefault();
            return ctrl as TextBox;
        }

        // Optional: convenience overload to populate from an array
        public void PopulateFromFields(params string[] fields) => PopulateFromFields((IList<string>)fields);

        private void label5_Click(object sender, EventArgs e)
        {
            // designer handler — intentionally left blank
        }
    }
}
