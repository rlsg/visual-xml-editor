namespace uk.co.rlsg.apps.xml_editor
{
    partial class XmlEditorFormSearch
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.checkBoxNodeName = new System.Windows.Forms.CheckBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.checkBoxAttributeName = new System.Windows.Forms.CheckBox();
            this.checkBoxAttributeValue = new System.Windows.Forms.CheckBox();
            this.checkBoxTextNodes = new System.Windows.Forms.CheckBox();
            this.checkBoxCommentNodes = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(176, 114);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 100;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // checkBoxNodeName
            // 
            this.checkBoxNodeName.AutoSize = true;
            this.checkBoxNodeName.Location = new System.Drawing.Point(13, 39);
            this.checkBoxNodeName.Name = "checkBoxNodeName";
            this.checkBoxNodeName.Size = new System.Drawing.Size(83, 17);
            this.checkBoxNodeName.TabIndex = 4;
            this.checkBoxNodeName.Text = "Node Name";
            this.checkBoxNodeName.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(13, 13);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(402, 20);
            this.textBox.TabIndex = 0;
            // 
            // checkBoxAttributeName
            // 
            this.checkBoxAttributeName.AutoSize = true;
            this.checkBoxAttributeName.Location = new System.Drawing.Point(215, 39);
            this.checkBoxAttributeName.Name = "checkBoxAttributeName";
            this.checkBoxAttributeName.Size = new System.Drawing.Size(96, 17);
            this.checkBoxAttributeName.TabIndex = 7;
            this.checkBoxAttributeName.Text = "Attribute Name";
            this.checkBoxAttributeName.UseVisualStyleBackColor = true;
            // 
            // checkBoxAttributeValue
            // 
            this.checkBoxAttributeValue.AutoSize = true;
            this.checkBoxAttributeValue.Location = new System.Drawing.Point(215, 62);
            this.checkBoxAttributeValue.Name = "checkBoxAttributeValue";
            this.checkBoxAttributeValue.Size = new System.Drawing.Size(95, 17);
            this.checkBoxAttributeValue.TabIndex = 8;
            this.checkBoxAttributeValue.Text = "Attribute Value";
            this.checkBoxAttributeValue.UseVisualStyleBackColor = true;
            // 
            // checkBoxTextNodes
            // 
            this.checkBoxTextNodes.AutoSize = true;
            this.checkBoxTextNodes.Location = new System.Drawing.Point(13, 62);
            this.checkBoxTextNodes.Name = "checkBoxTextNodes";
            this.checkBoxTextNodes.Size = new System.Drawing.Size(81, 17);
            this.checkBoxTextNodes.TabIndex = 5;
            this.checkBoxTextNodes.Text = "Text Nodes";
            this.checkBoxTextNodes.UseVisualStyleBackColor = true;
            // 
            // checkBoxCommentNodes
            // 
            this.checkBoxCommentNodes.AutoSize = true;
            this.checkBoxCommentNodes.Location = new System.Drawing.Point(13, 86);
            this.checkBoxCommentNodes.Name = "checkBoxCommentNodes";
            this.checkBoxCommentNodes.Size = new System.Drawing.Size(104, 17);
            this.checkBoxCommentNodes.TabIndex = 6;
            this.checkBoxCommentNodes.Text = "Comment Nodes";
            this.checkBoxCommentNodes.UseVisualStyleBackColor = true;
            // 
            // XmlEditorFormSearch
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 149);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.checkBoxNodeName);
            this.Controls.Add(this.checkBoxTextNodes);
            this.Controls.Add(this.checkBoxCommentNodes);
            this.Controls.Add(this.checkBoxAttributeName);
            this.Controls.Add(this.checkBoxAttributeValue);
            this.Controls.Add(this.buttonSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XmlEditorFormSearch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Search";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XmlEditorFormSearch_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.CheckBox checkBoxNodeName;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckBox checkBoxAttributeName;
        private System.Windows.Forms.CheckBox checkBoxAttributeValue;
        private System.Windows.Forms.CheckBox checkBoxTextNodes;
        private System.Windows.Forms.CheckBox checkBoxCommentNodes;
    }
}