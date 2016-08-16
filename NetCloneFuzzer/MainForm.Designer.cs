namespace NetCloneFuzzer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDomain = new System.Windows.Forms.Label();
            this.chkOnOff = new System.Windows.Forms.CheckBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.numMultiplicator = new System.Windows.Forms.NumericUpDown();
            this.txtHostFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.filterListDataGridView = new System.Windows.Forms.DataGridView();
            this.filterMatchGroupManipulationDataGridView = new System.Windows.Forms.DataGridView();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.regexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filterEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.filterMatchGroupManipulationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpOutput.SuspendLayout();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMultiplicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterMatchGroupManipulationDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterMatchGroupManipulationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(12, 74);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(63, 13);
            this.lblDomain.TabIndex = 0;
            this.lblDomain.Text = "Multiplicator";
            // 
            // chkOnOff
            // 
            this.chkOnOff.AutoSize = true;
            this.chkOnOff.Location = new System.Drawing.Point(12, 3);
            this.chkOnOff.Name = "chkOnOff";
            this.chkOnOff.Size = new System.Drawing.Size(59, 17);
            this.chkOnOff.TabIndex = 7;
            this.chkOnOff.Text = "On/Off";
            this.chkOnOff.UseVisualStyleBackColor = true;
            this.chkOnOff.CheckedChanged += new System.EventHandler(this.chkOnOff_CheckedChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 16);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(1180, 224);
            this.txtOutput.TabIndex = 8;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.txtOutput);
            this.grpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOutput.Location = new System.Drawing.Point(0, 0);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(1186, 243);
            this.grpOutput.TabIndex = 9;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Log Output";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.splitContainer1);
            this.grpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSettings.Location = new System.Drawing.Point(0, 0);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(1186, 334);
            this.grpSettings.TabIndex = 10;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings Window";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.numMultiplicator);
            this.splitContainer1.Panel1.Controls.Add(this.txtHostFilter);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.chkOnOff);
            this.splitContainer1.Panel1.Controls.Add(this.lblDomain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1180, 315);
            this.splitContainer1.SplitterDistance = 278;
            this.splitContainer1.TabIndex = 10;
            // 
            // numMultiplicator
            // 
            this.numMultiplicator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numMultiplicator.Location = new System.Drawing.Point(12, 90);
            this.numMultiplicator.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMultiplicator.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMultiplicator.Name = "numMultiplicator";
            this.numMultiplicator.Size = new System.Drawing.Size(263, 20);
            this.numMultiplicator.TabIndex = 11;
            this.numMultiplicator.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMultiplicator.ValueChanged += new System.EventHandler(this.numMultiplicator_ValueChanged);
            // 
            // txtHostFilter
            // 
            this.txtHostFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHostFilter.Location = new System.Drawing.Point(12, 45);
            this.txtHostFilter.Name = "txtHostFilter";
            this.txtHostFilter.Size = new System.Drawing.Size(263, 20);
            this.txtHostFilter.TabIndex = 9;
            this.txtHostFilter.Text = "*gargo.ch*";
            this.txtHostFilter.TextChanged += new System.EventHandler(this.txtHostFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Domain";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.filterListDataGridView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.filterMatchGroupManipulationDataGridView);
            this.splitContainer3.Size = new System.Drawing.Size(898, 315);
            this.splitContainer3.SplitterDistance = 154;
            this.splitContainer3.TabIndex = 2;
            // 
            // filterListDataGridView
            // 
            this.filterListDataGridView.AutoGenerateColumns = false;
            this.filterListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeDataGridViewTextBoxColumn,
            this.regexDataGridViewTextBoxColumn});
            this.filterListDataGridView.DataSource = this.filterEntryBindingSource;
            this.filterListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.filterListDataGridView.Name = "filterListDataGridView";
            this.filterListDataGridView.Size = new System.Drawing.Size(898, 154);
            this.filterListDataGridView.TabIndex = 0;
            // 
            // filterMatchGroupManipulationDataGridView
            // 
            this.filterMatchGroupManipulationDataGridView.AutoGenerateColumns = false;
            this.filterMatchGroupManipulationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filterMatchGroupManipulationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Value});
            this.filterMatchGroupManipulationDataGridView.DataSource = this.filterMatchGroupManipulationBindingSource;
            this.filterMatchGroupManipulationDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterMatchGroupManipulationDataGridView.Location = new System.Drawing.Point(0, 0);
            this.filterMatchGroupManipulationDataGridView.Name = "filterMatchGroupManipulationDataGridView";
            this.filterMatchGroupManipulationDataGridView.Size = new System.Drawing.Size(898, 157);
            this.filterMatchGroupManipulationDataGridView.TabIndex = 1;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Width = 300;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grpSettings);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grpOutput);
            this.splitContainer2.Size = new System.Drawing.Size(1186, 581);
            this.splitContainer2.SplitterDistance = 334;
            this.splitContainer2.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1186, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernToolStripMenuItem,
            this.ladenToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "&Filter";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.speichernToolStripMenuItem.Text = "&Speichern ...";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ladenToolStripMenuItem.Text = "&Laden ...";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.FillWeight = 1F;
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.typeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // regexDataGridViewTextBoxColumn
            // 
            this.regexDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.regexDataGridViewTextBoxColumn.DataPropertyName = "Regex";
            this.regexDataGridViewTextBoxColumn.FillWeight = 47.71573F;
            this.regexDataGridViewTextBoxColumn.HeaderText = "Regex";
            this.regexDataGridViewTextBoxColumn.Name = "regexDataGridViewTextBoxColumn";
            // 
            // filterEntryBindingSource
            // 
            this.filterEntryBindingSource.DataSource = typeof(NetCloneFuzzer.FilterEntry);
            this.filterEntryBindingSource.CurrentChanged += new System.EventHandler(this.filterEntryBindingSource_CurrentChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "GroupName";
            this.dataGridViewTextBoxColumn1.HeaderText = "GroupName";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ManipulationType";
            this.dataGridViewTextBoxColumn2.HeaderText = "ManipulationType";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // filterMatchGroupManipulationBindingSource
            // 
            this.filterMatchGroupManipulationBindingSource.DataSource = typeof(NetCloneFuzzer.FilterMatchGroupManipulation);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 605);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetCloneFuzzer";
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMultiplicator)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filterListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterMatchGroupManipulationDataGridView)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterMatchGroupManipulationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.CheckBox chkOnOff;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtHostFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMultiplicator;
        private System.Windows.Forms.DataGridView filterListDataGridView;
        private System.Windows.Forms.BindingSource filterEntryBindingSource;
        private System.Windows.Forms.BindingSource filterMatchGroupManipulationBindingSource;
        private System.Windows.Forms.DataGridView filterMatchGroupManipulationDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
    }
}

