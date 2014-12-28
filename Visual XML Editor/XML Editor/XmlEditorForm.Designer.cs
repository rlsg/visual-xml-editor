namespace uk.co.rlsg.apps.tools
{
    partial class XmlEditorForm
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
            System.Windows.Forms.ColumnHeader Attribute;
            System.Windows.Forms.ColumnHeader Value;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlEditorForm));
            this.XmlViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.xmlNodeTreeView = new System.Windows.Forms.TreeView();
            this.xmlNodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTextXmlNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCommentXmlNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addElementXmlNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteXmlNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmlNodeTabControl = new System.Windows.Forms.TabControl();
            this.xmlNodeDataTab = new System.Windows.Forms.TabPage();
            this.xmlNodeDetailSplitContainer = new System.Windows.Forms.SplitContainer();
            this.xmlAttributesListView = new System.Windows.Forms.ListView();
            this.xmlAttributesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editAttrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAttrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAttrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmlNodeTextTextBox = new System.Windows.Forms.TextBox();
            this.xmlNodeSourceTab = new System.Windows.Forms.TabPage();
            this.xmlNodeSourceTextBox = new System.Windows.Forms.TextBox();
            Attribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.XmlViewSplitContainer)).BeginInit();
            this.XmlViewSplitContainer.Panel1.SuspendLayout();
            this.XmlViewSplitContainer.Panel2.SuspendLayout();
            this.XmlViewSplitContainer.SuspendLayout();
            this.xmlNodeContextMenuStrip.SuspendLayout();
            this.xmlNodeTabControl.SuspendLayout();
            this.xmlNodeDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xmlNodeDetailSplitContainer)).BeginInit();
            this.xmlNodeDetailSplitContainer.Panel1.SuspendLayout();
            this.xmlNodeDetailSplitContainer.Panel2.SuspendLayout();
            this.xmlNodeDetailSplitContainer.SuspendLayout();
            this.xmlAttributesContextMenuStrip.SuspendLayout();
            this.xmlNodeSourceTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Attribute
            // 
            Attribute.Text = "Attribute";
            // 
            // Value
            // 
            Value.Text = "Value";
            // 
            // XmlViewSplitContainer
            // 
            this.XmlViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XmlViewSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.XmlViewSplitContainer.Name = "XmlViewSplitContainer";
            // 
            // XmlViewSplitContainer.Panel1
            // 
            this.XmlViewSplitContainer.Panel1.Controls.Add(this.xmlNodeTreeView);
            // 
            // XmlViewSplitContainer.Panel2
            // 
            this.XmlViewSplitContainer.Panel2.Controls.Add(this.xmlNodeTabControl);
            this.XmlViewSplitContainer.Size = new System.Drawing.Size(752, 610);
            this.XmlViewSplitContainer.SplitterDistance = 250;
            this.XmlViewSplitContainer.TabIndex = 0;
            // 
            // xmlNodeTreeView
            // 
            this.xmlNodeTreeView.AllowDrop = true;
            this.xmlNodeTreeView.ContextMenuStrip = this.xmlNodeContextMenuStrip;
            this.xmlNodeTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlNodeTreeView.HideSelection = false;
            this.xmlNodeTreeView.LabelEdit = true;
            this.xmlNodeTreeView.Location = new System.Drawing.Point(0, 0);
            this.xmlNodeTreeView.Name = "xmlNodeTreeView";
            this.xmlNodeTreeView.ShowNodeToolTips = true;
            this.xmlNodeTreeView.Size = new System.Drawing.Size(250, 610);
            this.xmlNodeTreeView.TabIndex = 0;
            this.xmlNodeTreeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.xmlNodeTreeView_BeforeLabelEdit);
            this.xmlNodeTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.xmlNodeTreeView_AfterLabelEdit);
            this.xmlNodeTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.xmlNodeTreeView_ItemDrag);
            this.xmlNodeTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.XmlNodeTreeView_AfterSelect);
            this.xmlNodeTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.xmlNodeTreeView_DragDrop);
            this.xmlNodeTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.xmlNodeTreeView_DragEnter);
            this.xmlNodeTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.xmlNodeTreeView_DragOver);
            // 
            // xmlNodeContextMenuStrip
            // 
            this.xmlNodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteXmlNodeToolStripMenuItem});
            this.xmlNodeContextMenuStrip.Name = "xmlNodeContextMenuStrip";
            this.xmlNodeContextMenuStrip.Size = new System.Drawing.Size(108, 48);
            this.xmlNodeContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.xmlNodeContextMenuStrip_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTextXmlNodeToolStripMenuItem,
            this.addCommentXmlNodeToolStripMenuItem,
            this.addElementXmlNodeToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // addTextXmlNodeToolStripMenuItem
            // 
            this.addTextXmlNodeToolStripMenuItem.Name = "addTextXmlNodeToolStripMenuItem";
            this.addTextXmlNodeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addTextXmlNodeToolStripMenuItem.Text = "#text";
            this.addTextXmlNodeToolStripMenuItem.Click += new System.EventHandler(this.addTextXmlNodeToolStripMenuItem_Click);
            // 
            // addCommentXmlNodeToolStripMenuItem
            // 
            this.addCommentXmlNodeToolStripMenuItem.Name = "addCommentXmlNodeToolStripMenuItem";
            this.addCommentXmlNodeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addCommentXmlNodeToolStripMenuItem.Text = "#comment";
            this.addCommentXmlNodeToolStripMenuItem.Click += new System.EventHandler(this.addCommentXmlNodeToolStripMenuItem_Click);
            // 
            // addElementXmlNodeToolStripMenuItem
            // 
            this.addElementXmlNodeToolStripMenuItem.Name = "addElementXmlNodeToolStripMenuItem";
            this.addElementXmlNodeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addElementXmlNodeToolStripMenuItem.Text = "Element";
            this.addElementXmlNodeToolStripMenuItem.Click += new System.EventHandler(this.addElementXmlNodeToolStripMenuItem_Click);
            // 
            // deleteXmlNodeToolStripMenuItem
            // 
            this.deleteXmlNodeToolStripMenuItem.Name = "deleteXmlNodeToolStripMenuItem";
            this.deleteXmlNodeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteXmlNodeToolStripMenuItem.Text = "Delete";
            this.deleteXmlNodeToolStripMenuItem.Click += new System.EventHandler(this.deleteXmlNodeToolStripMenuItem_Click);
            // 
            // xmlNodeTabControl
            // 
            this.xmlNodeTabControl.Controls.Add(this.xmlNodeDataTab);
            this.xmlNodeTabControl.Controls.Add(this.xmlNodeSourceTab);
            this.xmlNodeTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlNodeTabControl.Location = new System.Drawing.Point(0, 0);
            this.xmlNodeTabControl.Name = "xmlNodeTabControl";
            this.xmlNodeTabControl.SelectedIndex = 0;
            this.xmlNodeTabControl.Size = new System.Drawing.Size(498, 610);
            this.xmlNodeTabControl.TabIndex = 2;
            this.xmlNodeTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.xmlNodeTabControl_Selected);
            // 
            // xmlNodeDataTab
            // 
            this.xmlNodeDataTab.Controls.Add(this.xmlNodeDetailSplitContainer);
            this.xmlNodeDataTab.Location = new System.Drawing.Point(4, 22);
            this.xmlNodeDataTab.Name = "xmlNodeDataTab";
            this.xmlNodeDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.xmlNodeDataTab.Size = new System.Drawing.Size(490, 584);
            this.xmlNodeDataTab.TabIndex = 0;
            this.xmlNodeDataTab.Text = "Data";
            this.xmlNodeDataTab.UseVisualStyleBackColor = true;
            // 
            // xmlNodeDetailSplitContainer
            // 
            this.xmlNodeDetailSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlNodeDetailSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.xmlNodeDetailSplitContainer.Name = "xmlNodeDetailSplitContainer";
            this.xmlNodeDetailSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // xmlNodeDetailSplitContainer.Panel1
            // 
            this.xmlNodeDetailSplitContainer.Panel1.Controls.Add(this.xmlAttributesListView);
            // 
            // xmlNodeDetailSplitContainer.Panel2
            // 
            this.xmlNodeDetailSplitContainer.Panel2.Controls.Add(this.xmlNodeTextTextBox);
            this.xmlNodeDetailSplitContainer.Size = new System.Drawing.Size(484, 578);
            this.xmlNodeDetailSplitContainer.SplitterDistance = 475;
            this.xmlNodeDetailSplitContainer.TabIndex = 1;
            // 
            // xmlAttributesListView
            // 
            this.xmlAttributesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Attribute,
            Value});
            this.xmlAttributesListView.ContextMenuStrip = this.xmlAttributesContextMenuStrip;
            this.xmlAttributesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlAttributesListView.LabelEdit = true;
            this.xmlAttributesListView.Location = new System.Drawing.Point(0, 0);
            this.xmlAttributesListView.Name = "xmlAttributesListView";
            this.xmlAttributesListView.Size = new System.Drawing.Size(484, 475);
            this.xmlAttributesListView.TabIndex = 0;
            this.xmlAttributesListView.UseCompatibleStateImageBehavior = false;
            this.xmlAttributesListView.View = System.Windows.Forms.View.Details;
            this.xmlAttributesListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.xmlAttributesListView_AfterLabelEdit);
            this.xmlAttributesListView.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.xmlAttributesListView_BeforeLabelEdit);
            // 
            // xmlAttributesContextMenuStrip
            // 
            this.xmlAttributesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAttrToolStripMenuItem,
            this.addAttrToolStripMenuItem,
            this.deleteAttrToolStripMenuItem});
            this.xmlAttributesContextMenuStrip.Name = "xmlAttributesContextMenuStrip";
            this.xmlAttributesContextMenuStrip.Size = new System.Drawing.Size(108, 70);
            this.xmlAttributesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.xmlAttributesContextMenuStrip_Opening);
            // 
            // editAttrToolStripMenuItem
            // 
            this.editAttrToolStripMenuItem.Name = "editAttrToolStripMenuItem";
            this.editAttrToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editAttrToolStripMenuItem.Text = "Edit";
            this.editAttrToolStripMenuItem.Click += new System.EventHandler(this.editAttrToolStripMenuItem_Click);
            // 
            // addAttrToolStripMenuItem
            // 
            this.addAttrToolStripMenuItem.Name = "addAttrToolStripMenuItem";
            this.addAttrToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addAttrToolStripMenuItem.Text = "Add";
            this.addAttrToolStripMenuItem.Click += new System.EventHandler(this.addAttrToolStripMenuItem_Click);
            // 
            // deleteAttrToolStripMenuItem
            // 
            this.deleteAttrToolStripMenuItem.Name = "deleteAttrToolStripMenuItem";
            this.deleteAttrToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteAttrToolStripMenuItem.Text = "Delete";
            this.deleteAttrToolStripMenuItem.Click += new System.EventHandler(this.deleteAttrToolStripMenuItem_Click);
            // 
            // xmlNodeTextTextBox
            // 
            this.xmlNodeTextTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlNodeTextTextBox.Location = new System.Drawing.Point(0, 0);
            this.xmlNodeTextTextBox.Multiline = true;
            this.xmlNodeTextTextBox.Name = "xmlNodeTextTextBox";
            this.xmlNodeTextTextBox.Size = new System.Drawing.Size(484, 99);
            this.xmlNodeTextTextBox.TabIndex = 0;
            this.xmlNodeTextTextBox.TextChanged += new System.EventHandler(this.xmlNodeTextTextBox_TextChanged);
            // 
            // xmlNodeSourceTab
            // 
            this.xmlNodeSourceTab.Controls.Add(this.xmlNodeSourceTextBox);
            this.xmlNodeSourceTab.Location = new System.Drawing.Point(4, 22);
            this.xmlNodeSourceTab.Name = "xmlNodeSourceTab";
            this.xmlNodeSourceTab.Padding = new System.Windows.Forms.Padding(3);
            this.xmlNodeSourceTab.Size = new System.Drawing.Size(490, 584);
            this.xmlNodeSourceTab.TabIndex = 1;
            this.xmlNodeSourceTab.Text = "Source";
            this.xmlNodeSourceTab.UseVisualStyleBackColor = true;
            // 
            // xmlNodeSourceTextBox
            // 
            this.xmlNodeSourceTextBox.AcceptsReturn = true;
            this.xmlNodeSourceTextBox.AcceptsTab = true;
            this.xmlNodeSourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlNodeSourceTextBox.Location = new System.Drawing.Point(3, 3);
            this.xmlNodeSourceTextBox.MaxLength = 2147483647;
            this.xmlNodeSourceTextBox.Multiline = true;
            this.xmlNodeSourceTextBox.Name = "xmlNodeSourceTextBox";
            this.xmlNodeSourceTextBox.Size = new System.Drawing.Size(484, 578);
            this.xmlNodeSourceTextBox.TabIndex = 0;
            this.xmlNodeSourceTextBox.TextChanged += new System.EventHandler(this.xmlNodeSourceTextBox_TextChanged);
            // 
            // XmlEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 610);
            this.Controls.Add(this.XmlViewSplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XmlEditorForm";
            this.Text = "Visual XML Editor";
            this.XmlViewSplitContainer.Panel1.ResumeLayout(false);
            this.XmlViewSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XmlViewSplitContainer)).EndInit();
            this.XmlViewSplitContainer.ResumeLayout(false);
            this.xmlNodeContextMenuStrip.ResumeLayout(false);
            this.xmlNodeTabControl.ResumeLayout(false);
            this.xmlNodeDataTab.ResumeLayout(false);
            this.xmlNodeDetailSplitContainer.Panel1.ResumeLayout(false);
            this.xmlNodeDetailSplitContainer.Panel2.ResumeLayout(false);
            this.xmlNodeDetailSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xmlNodeDetailSplitContainer)).EndInit();
            this.xmlNodeDetailSplitContainer.ResumeLayout(false);
            this.xmlAttributesContextMenuStrip.ResumeLayout(false);
            this.xmlNodeSourceTab.ResumeLayout(false);
            this.xmlNodeSourceTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer XmlViewSplitContainer;
        private System.Windows.Forms.TreeView xmlNodeTreeView;
        private System.Windows.Forms.ListView xmlAttributesListView;
        private System.Windows.Forms.SplitContainer xmlNodeDetailSplitContainer;
        private System.Windows.Forms.TextBox xmlNodeTextTextBox;
        private System.Windows.Forms.TabControl xmlNodeTabControl;
        private System.Windows.Forms.TabPage xmlNodeDataTab;
        private System.Windows.Forms.TextBox xmlNodeSourceTextBox;
        private System.Windows.Forms.TabPage xmlNodeSourceTab;
        private System.Windows.Forms.ContextMenuStrip xmlAttributesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editAttrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAttrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAttrToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip xmlNodeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTextXmlNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCommentXmlNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addElementXmlNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteXmlNodeToolStripMenuItem;
    }
}