namespace uk.co.rlsg.apps.xml_editor
{
    partial class XmlSettingsForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageNL = new System.Windows.Forms.TabPage();
            this.comboBoxEOL = new System.Windows.Forms.ComboBox();
            this.radioButtonNLAttr = new System.Windows.Forms.RadioButton();
            this.radioButtonNLTag = new System.Windows.Forms.RadioButton();
            this.radioButtonNLNone = new System.Windows.Forms.RadioButton();
            this.tabPageIndent = new System.Windows.Forms.TabPage();
            this.numericUpDownSpaceCount = new System.Windows.Forms.NumericUpDown();
            this.radioButtonIndentSpace = new System.Windows.Forms.RadioButton();
            this.radioButtonIndentTab = new System.Windows.Forms.RadioButton();
            this.radioButtonIndentNone = new System.Windows.Forms.RadioButton();
            this.tabControl.SuspendLayout();
            this.tabPageNL.SuspendLayout();
            this.tabPageIndent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpaceCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageNL);
            this.tabControl.Controls.Add(this.tabPageIndent);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(147, 132);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageNL
            // 
            this.tabPageNL.Controls.Add(this.comboBoxEOL);
            this.tabPageNL.Controls.Add(this.radioButtonNLAttr);
            this.tabPageNL.Controls.Add(this.radioButtonNLTag);
            this.tabPageNL.Controls.Add(this.radioButtonNLNone);
            this.tabPageNL.Location = new System.Drawing.Point(4, 22);
            this.tabPageNL.Name = "tabPageNL";
            this.tabPageNL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNL.Size = new System.Drawing.Size(139, 106);
            this.tabPageNL.TabIndex = 0;
            this.tabPageNL.Text = "New Lines";
            this.tabPageNL.UseVisualStyleBackColor = true;
            // 
            // comboBoxEOL
            // 
            this.comboBoxEOL.FormattingEnabled = true;
            this.comboBoxEOL.Items.AddRange(new object[] {
            "UNIX (LF)",
            "Windows (CR+LF)"});
            this.comboBoxEOL.Location = new System.Drawing.Point(8, 75);
            this.comboBoxEOL.Name = "comboBoxEOL";
            this.comboBoxEOL.Size = new System.Drawing.Size(123, 21);
            this.comboBoxEOL.TabIndex = 7;
            this.comboBoxEOL.SelectedIndexChanged += new System.EventHandler(this.comboBoxEOL_SelectedIndexChanged);
            // 
            // radioButtonNLAttr
            // 
            this.radioButtonNLAttr.AutoSize = true;
            this.radioButtonNLAttr.Location = new System.Drawing.Point(8, 52);
            this.radioButtonNLAttr.Name = "radioButtonNLAttr";
            this.radioButtonNLAttr.Size = new System.Drawing.Size(69, 17);
            this.radioButtonNLAttr.TabIndex = 6;
            this.radioButtonNLAttr.Text = "Attributes";
            this.radioButtonNLAttr.UseVisualStyleBackColor = true;
            this.radioButtonNLAttr.CheckedChanged += new System.EventHandler(this.radioButtonNLAttr_CheckedChanged);
            // 
            // radioButtonNLTag
            // 
            this.radioButtonNLTag.AutoSize = true;
            this.radioButtonNLTag.Location = new System.Drawing.Point(8, 29);
            this.radioButtonNLTag.Name = "radioButtonNLTag";
            this.radioButtonNLTag.Size = new System.Drawing.Size(49, 17);
            this.radioButtonNLTag.TabIndex = 5;
            this.radioButtonNLTag.Text = "Tags";
            this.radioButtonNLTag.UseVisualStyleBackColor = true;
            this.radioButtonNLTag.CheckedChanged += new System.EventHandler(this.radioButtonNLTag_CheckedChanged);
            // 
            // radioButtonNLNone
            // 
            this.radioButtonNLNone.AutoSize = true;
            this.radioButtonNLNone.Location = new System.Drawing.Point(8, 6);
            this.radioButtonNLNone.Name = "radioButtonNLNone";
            this.radioButtonNLNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonNLNone.TabIndex = 4;
            this.radioButtonNLNone.Text = "None";
            this.radioButtonNLNone.UseVisualStyleBackColor = true;
            this.radioButtonNLNone.CheckedChanged += new System.EventHandler(this.radioButtonNLNone_CheckedChanged);
            // 
            // tabPageIndent
            // 
            this.tabPageIndent.Controls.Add(this.numericUpDownSpaceCount);
            this.tabPageIndent.Controls.Add(this.radioButtonIndentSpace);
            this.tabPageIndent.Controls.Add(this.radioButtonIndentTab);
            this.tabPageIndent.Controls.Add(this.radioButtonIndentNone);
            this.tabPageIndent.Location = new System.Drawing.Point(4, 22);
            this.tabPageIndent.Name = "tabPageIndent";
            this.tabPageIndent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIndent.Size = new System.Drawing.Size(139, 106);
            this.tabPageIndent.TabIndex = 1;
            this.tabPageIndent.Text = "Indentation";
            this.tabPageIndent.UseVisualStyleBackColor = true;
            // 
            // numericUpDownSpaceCount
            // 
            this.numericUpDownSpaceCount.Location = new System.Drawing.Point(76, 52);
            this.numericUpDownSpaceCount.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownSpaceCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSpaceCount.Name = "numericUpDownSpaceCount";
            this.numericUpDownSpaceCount.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownSpaceCount.TabIndex = 3;
            this.numericUpDownSpaceCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownSpaceCount.ValueChanged += new System.EventHandler(this.numericUpDownSpaceCount_ValueChanged);
            // 
            // radioButtonIndentSpace
            // 
            this.radioButtonIndentSpace.AutoSize = true;
            this.radioButtonIndentSpace.Location = new System.Drawing.Point(8, 52);
            this.radioButtonIndentSpace.Name = "radioButtonIndentSpace";
            this.radioButtonIndentSpace.Size = new System.Drawing.Size(61, 17);
            this.radioButtonIndentSpace.TabIndex = 2;
            this.radioButtonIndentSpace.Text = "Spaces";
            this.radioButtonIndentSpace.UseVisualStyleBackColor = true;
            this.radioButtonIndentSpace.CheckedChanged += new System.EventHandler(this.radioButtonIndentSpace_CheckedChanged);
            // 
            // radioButtonIndentTab
            // 
            this.radioButtonIndentTab.AutoSize = true;
            this.radioButtonIndentTab.Location = new System.Drawing.Point(8, 29);
            this.radioButtonIndentTab.Name = "radioButtonIndentTab";
            this.radioButtonIndentTab.Size = new System.Drawing.Size(49, 17);
            this.radioButtonIndentTab.TabIndex = 1;
            this.radioButtonIndentTab.Text = "Tabs";
            this.radioButtonIndentTab.UseVisualStyleBackColor = true;
            this.radioButtonIndentTab.CheckedChanged += new System.EventHandler(this.radioButtonIndentTab_CheckedChanged);
            // 
            // radioButtonIndentNone
            // 
            this.radioButtonIndentNone.AutoSize = true;
            this.radioButtonIndentNone.Location = new System.Drawing.Point(8, 6);
            this.radioButtonIndentNone.Name = "radioButtonIndentNone";
            this.radioButtonIndentNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonIndentNone.TabIndex = 0;
            this.radioButtonIndentNone.Text = "None";
            this.radioButtonIndentNone.UseVisualStyleBackColor = true;
            this.radioButtonIndentNone.CheckedChanged += new System.EventHandler(this.radioButtonIndentNone_CheckedChanged);
            // 
            // XmlSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(147, 132);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XmlSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Save Settings";
            this.tabControl.ResumeLayout(false);
            this.tabPageNL.ResumeLayout(false);
            this.tabPageNL.PerformLayout();
            this.tabPageIndent.ResumeLayout(false);
            this.tabPageIndent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpaceCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageNL;
        private System.Windows.Forms.RadioButton radioButtonNLAttr;
        private System.Windows.Forms.RadioButton radioButtonNLTag;
        private System.Windows.Forms.RadioButton radioButtonNLNone;
        private System.Windows.Forms.TabPage tabPageIndent;
        private System.Windows.Forms.ComboBox comboBoxEOL;
        private System.Windows.Forms.NumericUpDown numericUpDownSpaceCount;
        private System.Windows.Forms.RadioButton radioButtonIndentSpace;
        private System.Windows.Forms.RadioButton radioButtonIndentTab;
        private System.Windows.Forms.RadioButton radioButtonIndentNone;
    }
}