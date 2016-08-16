using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NetCloneFuzzer
{
    public partial class MainForm : Form
    {
        ReplacementEngine _replacementEngine = new ReplacementEngine();

        public MainForm()
        {
            InitializeComponent();

            //typeComboBox.DataSource = Enum.GetValues(typeof(FilterManipulationType));

            filterEntryBindingSource.DataSource = _replacementEngine.FilterContainer;

            typeDataGridViewTextBoxColumn.DataSource = Enum.GetValues(typeof(FilterType));
            dataGridViewTextBoxColumn2.DataSource = Enum.GetValues(typeof(FilterManipulationType));

#if DEBUG
            this.AddDummyFilters();
#else
            txtHostFilter.Text = "*.jans.li*";
#endif

            FiddlerEngine.HostFilter = txtHostFilter.Text;
            FiddlerEngine.Multiplicator = (int)numMultiplicator.Value;
            FiddlerEngine.Replacer = _replacementEngine;
            FiddlerEngine.Logger = LogWriteLine;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FiddlerEngine.ValidateCertificates();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            FiddlerEngine.Shutdown();
            FiddlerEngine.RemoveCertificates();
        }

        private void AddDummyFilters()
        {
            filterEntryBindingSource.SuspendBinding();
            try
            {
                FilterEntry entry = null;

                entry = new FilterEntry(FilterType.Body, "\"Acronym\": \"(.)(.)(.)(.)\", \"Abbrev\": \"ISO ([0-9]{1,4}): ([0-9]{1,4})\"");
                entry.Manipulations.Add(new FilterMatchGroupManipulation("1", FilterManipulationType.StaticText, "9"));
                entry.Manipulations.Add(new FilterMatchGroupManipulation("2", FilterManipulationType.RandomByte));
                entry.Manipulations.Add(new FilterMatchGroupManipulation("3", FilterManipulationType.RandomCharUpperCase));
                entry.Manipulations.Add(new FilterMatchGroupManipulation("4", FilterManipulationType.RandomNumber));
                entry.Manipulations.Add(new FilterMatchGroupManipulation("5", FilterManipulationType.NumberDecrement));
                entry.Manipulations.Add(new FilterMatchGroupManipulation("6", FilterManipulationType.NumberIncrement));
                _replacementEngine.FilterContainer.Filters.Add(entry);

                entry = new FilterEntry(FilterType.Header, "myheader: (.+)");
                entry.Manipulations.Add(new FilterMatchGroupManipulation("1", FilterManipulationType.RandomByte));
                _replacementEngine.FilterContainer.Filters.Add(entry);
            }
            finally
            {
                filterEntryBindingSource.ResumeBinding();
            }
        }

        private void LogClear()
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action(LogClear));
                return;
            }
            txtOutput.Clear();
        }
        private void LogWriteLine(LogMessageType type, string message)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new AddLogMessageDelegate(LogWriteLine), new object[] { type, message });
                return;
            }
            txtOutput.AppendText(string.Format("{0}: {1}", type, message) + Environment.NewLine);
        }

        private void filterEntryBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            filterMatchGroupManipulationBindingSource.DataSource = null;
            if (filterEntryBindingSource.Current != null)
            {
                filterMatchGroupManipulationBindingSource.DataSource = ((FilterEntry)filterEntryBindingSource.Current).Manipulations;
            }
        }

        private void chkOnOff_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box == null) { return; }

            box.Enabled = false;
            try
            {
                if (box.Checked)
                {
                    txtHostFilter.Enabled = false;
                    numMultiplicator.Enabled = false;
                    this.LogClear();
                    Application.DoEvents();
                    if (!FiddlerEngine.Startup())
                    {
                        box.Checked = false;
                    }
                }
                else
                {
                    FiddlerEngine.Shutdown();
                    txtHostFilter.Enabled = true;
                    numMultiplicator.Enabled = true;
                }
            }
            finally
            {
                box.Enabled = true;
            }
        }

        private void txtHostFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box == null) { return; }
            FiddlerEngine.HostFilter = box.Text;
        }

        private void numMultiplicator_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            if (num == null) { return; }
            FiddlerEngine.Multiplicator = (int)num.Value;
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "NetCloneFuzzer Filter File|*.ncfflt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _replacementEngine.FilterContainer.Save(dlg.FileName);
                }
            }
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterEntryBindingSource.DataSource = null;
            try
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "NetCloneFuzzer Filter File|*.ncfflt";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        _replacementEngine.FilterContainer.Load(dlg.FileName);
                    }
                }
            }
            finally
            {
                filterEntryBindingSource.DataSource = _replacementEngine.FilterContainer;
            }
        }
    }
}
