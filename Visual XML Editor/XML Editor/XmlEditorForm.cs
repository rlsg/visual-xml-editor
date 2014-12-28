using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace uk.co.rlsg.apps.xml_editor
{
    /// <summary>
    /// This is an implementation of a very basic graphical
    /// XML Editor. This was generated primarily as a stop-gap
    /// file editor for MD and MCSI scripts.
    /// </summary>
    public partial class XmlEditorForm : Form
    {
        private DateTime dragSelectTime = System.DateTime.Now;
        protected XmlDocument doc;
        private XmlEditorFormSearch dlgSearch; 

        /// <summary>
        /// This constructor allows for the creation of a
        /// new XML document from scratch
        /// </summary>
        public XmlEditorForm() :
            this("")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public XmlEditorForm(string title)
        {
            InitializeComponent();

            doc = new XmlDocument();

            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", null));

            xmlNodeTreeView.Tag = doc;

            if (title != null && title != "")
            {
                Text += ": " + title;
            }

            dlgSearch = new XmlEditorFormSearch(title, xmlNodeTreeView);
            refreshTree(true);
        }

        /// <summary>
        /// This constructor allows for the editing of
        /// an existing XML document
        /// </summary>
        /// <param name="doc"></param>
        public XmlEditorForm(XmlDocument doc) :
            this("", doc)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="doc"></param>
        public XmlEditorForm(string title, XmlDocument doc)
        {
            InitializeComponent();

            this.doc = doc;
            xmlNodeTreeView.Tag = doc;

            if (title != null && title != "")
            {
                Text += ": " + title;
            }

            dlgSearch = new XmlEditorFormSearch(title, xmlNodeTreeView);
            refreshTree(true);
        }

        /// <summary>
        /// This constructor allows for the editing/creation of
        /// a sub-tree of an existing XML document.
        /// </summary>
        /// <param name="root"></param>
        public XmlEditorForm(XmlNode root) :
            this("", root)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="root"></param>
        public XmlEditorForm(string title, XmlNode root)
        {
            InitializeComponent();

            this.doc = root.OwnerDocument;
            xmlNodeTreeView.Tag = root;

            if (title != null && title != "")
            {
                Text += ": " + title;
            }

            dlgSearch = new XmlEditorFormSearch(title, xmlNodeTreeView);
            refreshTree(true);
        }

        /// <summary>
        /// This constructor allows for the editing of
        /// an XML document that is to be read from
        /// the given data stream
        /// </summary>
        /// <param name="dataStream">Input stream containing an XML document</param>
        public XmlEditorForm(Stream dataStream) :
            this("", dataStream)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="dataStream"></param>
        public XmlEditorForm(string title, Stream dataStream)
        {
            InitializeComponent();

            doc = new XmlDocument();

            doc.Load(dataStream);
            xmlNodeTreeView.Tag = doc;

            if (title != null && title != "")
            {
                Text += ": " + title;
            }

            dlgSearch = new XmlEditorFormSearch(title, xmlNodeTreeView);
            refreshTree(true);
        }

        /// <summary>
        /// This method allows for the saving of
        /// the edited/created XML document to
        /// the given data stream
        /// </summary>
        /// <param name="dataStream">Output stream which is to receive the XML document</param>
        public void save(Stream dataStream)
        {
            doc.Save(dataStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal Stream save()
        {
            Stream rval = new MemoryStream();

            doc.Save(rval);

            rval.Seek(0, SeekOrigin.Begin);

            return rval;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal XmlDocument get()
        {
            return doc;
        }

        /// <summary>
        /// This method ensures that the tree pane containing the
        /// XML heirarchy is initialised and up to date
        /// </summary>
        protected void refreshTree(bool force)
        {
            Cursor last = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            xmlNodeTreeView.BeginUpdate();
            if (force || xmlNodeTreeView.SelectedNode == null)
            {
                xmlNodeTreeView.Nodes.Clear();
                TreeNode treeRoot = new TreeNode("XML");
                treeRoot.Expand();

                if (xmlNodeTreeView.Tag is XmlNode)
                {
                    XmlNode root = xmlNodeTreeView.Tag as XmlNode;

                    populateTree(root.ChildNodes, treeRoot.Nodes);
                }

                xmlNodeTreeView.Nodes.Add(treeRoot);
            }
            else
            {
                var subTreeRoot = xmlNodeTreeView.SelectedNode;
                
                subTreeRoot.Nodes.Clear();
                subTreeRoot.Expand();

                if (subTreeRoot.Tag is XmlNode)
                {
                    XmlNode root = xmlNodeTreeView.Tag as XmlNode;

                    populateTree(root.ChildNodes, subTreeRoot.Nodes);
                }
            }
            xmlNodeTreeView.EndUpdate();
            Cursor.Current = last;
        }

        /// <summary>
        /// This method is used to replicate the given XML heirarchies in the
        /// given sub-tree of a TreeView control
        /// </summary>
        /// <param name="xmlNodeList">The XML nodes to be added</param>
        /// <param name="treeNodeCollection">The TreeView node list that will display the given XML</param>
        private void populateTree(XmlNodeList xmlNodeList, TreeNodeCollection treeNodeCollection)
        {
            try
            {
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    TreeNode node = new TreeNode(xmlNode.Name);

                    node.Tag = xmlNode;
                    node.Text = xmlNode.LocalName;
                    if (xmlNode.HasChildNodes)
                    {
                        populateTree(xmlNode.ChildNodes, node.Nodes);
                    }
                    else
                    {
                        node.ToolTipText = xmlNode.InnerText;
                    }

                    treeNodeCollection.Add(node);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlNode"></param>
        protected void refreshDetails(XmlNode xmlNode)
        {
            try
            {
                xmlAttributesListView.Tag = null;
                xmlAttributesListView.Items.Clear();

                xmlNodeTextTextBox.ReadOnly = true;
                xmlNodeTextTextBox.Tag = null;
                xmlNodeTextTextBox.Text = "";
                xmlNodeTextTextBox.BackColor = Color.LightGray;

                if (xmlNode != null)
                {
                    if (!xmlNode.HasChildNodes)
                    {
                        if (xmlNode is XmlComment || xmlNode is XmlText)
                        {
                            xmlNodeTextTextBox.Tag = xmlNode;
                            xmlNodeTextTextBox.Text = xmlNode.InnerText;
                            xmlNodeTextTextBox.ReadOnly = false;
                            xmlNodeTextTextBox.BackColor = Color.White;
                        }
                    }

                    xmlAttributesListView.Enabled = true;
                    xmlAttributesListView.BackColor = Color.White;
                    xmlAttributesListView.Tag = xmlNode;
                    if (xmlNode is XmlDeclaration)
                    {
                        XmlDeclaration xmlDecl = xmlNode as XmlDeclaration;

                        xmlAttributesListView.Items.Add(new ListViewItem(new string[] {
                            "XML Version",
                            xmlDecl.Version
                        }));

                        xmlAttributesListView.Items.Add(new ListViewItem(new string[] {
                            "Encoding",
                            xmlDecl.Encoding
                        }));

                        xmlAttributesListView.Items.Add(new ListViewItem(new string[] {
                            "Standalone",
                            xmlDecl.Standalone
                        }));
                    }
                    else if (xmlNode is XmlElement)
                    {
                        foreach (XmlAttribute xmlAttr in xmlNode.Attributes)
                        {
                            ListViewItem item = new ListViewItem(new String[] { xmlAttr.Name, xmlAttr.Value });

                            item.Tag = xmlAttr;
                            item.Text = xmlAttr.LocalName;

                            xmlAttributesListView.Items.Add(item);
                        }
                    }
                    else
                    {
                        xmlAttributesListView.Enabled = false;
                        xmlAttributesListView.BackColor = Color.LightGray;
                    }
                }

                if (xmlAttributesListView.Items.Count > 0)
                {
                    xmlAttributesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {
                    xmlAttributesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlNode"></param>
        protected void refreshSource(XmlNode xmlNode)
        {
            try
            {
                xmlNodeSourceTextBox.ReadOnly = true;
                xmlNodeSourceTextBox.Tag = null;
                xmlNodeSourceTextBox.Text = "";
                xmlNodeSourceTextBox.BackColor = Color.LightGray;

                if (xmlNode != null)
                {
                    if (xmlNodeTabControl.SelectedTab == xmlNodeSourceTab)
                    {
                        xmlNodeSourceTextBox.Tag = xmlNode;
                        xmlNodeSourceTextBox.Text = xmlNode.InnerXml;
                        if (!(xmlNode is XmlComment ||
                              xmlNode is XmlText ||
                              xmlNode is XmlDeclaration ||
                              xmlNode.IsReadOnly))
                        {
                            xmlNodeSourceTextBox.ReadOnly = false;
                            xmlNodeSourceTextBox.BackColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XmlNodeTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor last = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            XmlNode xmlNode = null;
            if (e.Node != null)
            {
                xmlNode = e.Node.Tag as XmlNode;

                if (e.Node.Tag == null)
                {
                    xmlNode = xmlNodeTreeView.Tag as XmlNode;
                }
            }
            refreshDetails(xmlNode);
            refreshSource(xmlNode);
            Cursor.Current = last;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeTextTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!xmlNodeTextTextBox.ReadOnly)
            {
                if (xmlNodeTextTextBox.Tag is XmlNode)
                {
                    XmlNode xmlNode = xmlNodeTextTextBox.Tag as XmlNode;

                    xmlNode.InnerText = xmlNodeTextTextBox.Text;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!xmlNodeSourceTextBox.ReadOnly)
            {
                try
                {
                    if (xmlNodeSourceTextBox.Tag is XmlDocument)
                    {
                        doc.InnerXml = xmlNodeSourceTextBox.Text;

                        refreshTree(true);
                    }
                    else if (xmlNodeSourceTextBox.Tag is XmlNode)
                    {
                        XmlNode xmlNode = xmlNodeSourceTextBox.Tag as XmlNode;

                        xmlNode.InnerXml = xmlNodeSourceTextBox.Text;

                        refreshTree(false);
                    }
                    xmlNodeSourceTextBox.BackColor = Color.White;
                }
                catch (XmlException)
                {
                    xmlNodeSourceTextBox.BackColor = Color.LightPink;
                }
            }
            else
            {
                xmlNodeSourceTextBox.BackColor = Color.LightGray;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == xmlNodeSourceTab)
            {
                Cursor last = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                refreshSource(xmlNodeSourceTab.Tag as XmlNode);
                Cursor.Current = last;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlAttributesContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            editAttrToolStripMenuItem.Enabled = (xmlAttributesListView.SelectedItems.Count == 1);
            addAttrToolStripMenuItem.Enabled = xmlAttributesListView.Tag is XmlElement && xmlAttributesListView.Enabled;
            deleteAttrToolStripMenuItem.Enabled = xmlAttributesListView.Tag is XmlElement && (xmlAttributesListView.SelectedItems.Count != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editAttrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = xmlAttributesListView.SelectedItems[0];

            try
            {
                if (xmlAttributesListView.Tag is XmlElement)
                {
                    XmlAttribute attr = item.Tag as XmlAttribute;
                    XmlEditorFormAttribute dlg = new XmlEditorFormAttribute(item.Text, item.SubItems[1].Text);

                    switch (dlg.ShowDialog())
                    {
                    case System.Windows.Forms.DialogResult.OK:
                        attr.Value = dlg.value;
                        item.SubItems[1].Text = dlg.value;
                        break;
                    }
                }
                else if (xmlAttributesListView.Tag is XmlDeclaration)
                {
                    XmlDeclaration decl = xmlAttributesListView.Tag as XmlDeclaration;
                    XmlDeclaration newDecl = decl;
                    XmlEditorFormAttribute dlg = new XmlEditorFormAttribute(item.Text, item.SubItems[1].Text);

                    switch (dlg.ShowDialog())
                    {
                    case System.Windows.Forms.DialogResult.OK:
                        switch (item.Text)
                        {
                        case "XML Version":
                            newDecl = doc.CreateXmlDeclaration(dlg.value, decl.Encoding, decl.Standalone);
                            item.SubItems[1].Text = dlg.value;
                            break;

                        case "Encoding":
                            decl.Encoding = dlg.value;
                            item.SubItems[1].Text = dlg.value;
                            break;

                        case "Standalone":
                            decl.Standalone = dlg.value;
                            item.SubItems[1].Text = dlg.value;
                            break;

                        default:
                            System.Media.SystemSounds.Beep.Play();
                            break;
                        }
                        if (newDecl != decl)
                        {
                            doc.ReplaceChild(newDecl, decl);
                            refreshTree(true);
                        }
                        break;
                    }
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            catch (Exception)
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAttrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlElement elem = xmlAttributesListView.Tag as XmlElement;

            if (elem != null)
            {
                String newAttrName="dummy";
                String newAttrValue=DateTime.Now.ToString();

                if (elem.HasAttribute(newAttrName))
                {
                    System.Media.SystemSounds.Beep.Play();
                }
                else
                {
                    elem.SetAttribute(newAttrName, newAttrValue);
                    XmlAttribute newAttr=elem.Attributes[newAttrName];

                    if (newAttr!=null)
                    {
                        ListViewItem newItem=new ListViewItem(new String[] {
                            newAttr.LocalName,
                            newAttr.Value
                        });

                        newItem.Name = newAttr.Name;
                        newItem.Tag = newAttr;

                        xmlAttributesListView.Items.Add(newItem);
                    }
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAttrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (xmlAttributesListView.SelectedItems.Count > 0)
            {
                ListViewItem item=xmlAttributesListView.SelectedItems[0];

                if (item.Tag is XmlAttribute)
                {
                    XmlAttribute xmlAttr=item.Tag as XmlAttribute;

                    xmlAttr.OwnerElement.RemoveAttribute(xmlAttr.Name);
                }

                item.Remove();
            }
            xmlNodeSourceTextBox.ReadOnly = true;
            xmlNodeSourceTextBox.Tag = null;
            xmlNodeSourceTextBox.Text = "";
            xmlNodeSourceTextBox.BackColor = Color.LightGray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = !(e.Node.Tag is XmlElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            Cursor last = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            XmlElement xmlNode = e.Node.Tag as XmlElement;

            if (xmlNode != null)
            {
                if (e.Label == null)
                {
                    // DO NOTHING
                }
                else if (e.Label != e.Node.Text)
                {
                    e.Node.Tag = null;
                    XmlElement newXmlNode = doc.CreateElement(e.Label);

                    while (xmlNode.HasChildNodes)
                    {
                        newXmlNode.AppendChild(xmlNode.RemoveChild(xmlNode.ChildNodes[0]));
                    }

                    foreach (XmlAttribute xmlAttr in xmlNode.Attributes)
                    {
                        newXmlNode.SetAttribute(xmlAttr.Name, xmlAttr.Value);
                    }

                    xmlNode.ParentNode.ReplaceChild(newXmlNode, xmlNode);
                    e.Node.Tag = newXmlNode;
                }
            }
            Cursor.Current = last;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private XmlNode getCurrentXmlNode()
        {
            XmlNode node = xmlNodeTreeView.Tag as XmlNode;

            if (xmlNodeTreeView.SelectedNode != null)
            {
                if (xmlNodeTreeView.SelectedNode.Tag != null)
                {
                    node = xmlNodeTreeView.SelectedNode.Tag as XmlNode;
                }
            }

            return node;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            XmlNode node = getCurrentXmlNode();

            addCommentXmlNodeToolStripMenuItem.Enabled = node is XmlElement || node is XmlDocument;
            deleteXmlNodeToolStripMenuItem.Enabled = node is XmlText || node is XmlComment || node is XmlElement;

            if (node is XmlElement)
            {
                addTextXmlNodeToolStripMenuItem.Enabled = true;

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    addTextXmlNodeToolStripMenuItem.Enabled &= !(childNode is XmlText);
                }
            }
            else
            {
                addTextXmlNodeToolStripMenuItem.Enabled = false;
            }

            if (node is XmlDocument)
            {
                addElementXmlNodeToolStripMenuItem.Enabled = true;

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    addElementXmlNodeToolStripMenuItem.Enabled &= !(childNode is XmlElement);
                }
            }
            else
            {
                addElementXmlNodeToolStripMenuItem.Enabled = node is XmlElement;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteXmlNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (xmlNodeTreeView.SelectedNode != null)
            {
                XmlNode node = getCurrentXmlNode();

                xmlNodeTreeView.SelectedNode.Tag = null;

                if (node != null)
                {
                    node.ParentNode.RemoveChild(node);
                }
                xmlNodeTreeView.SelectedNode.Remove();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTextXmlNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (xmlNodeTreeView.SelectedNode != null)
            {
                XmlNode node = getCurrentXmlNode();
                XmlNode newXmlNode = doc.CreateTextNode("*** Text ***");

                node.AppendChild(newXmlNode);

                TreeNode newTreeNode = new TreeNode(newXmlNode.Name);

                newTreeNode.Tag = newXmlNode;
                newTreeNode.Text = newXmlNode.LocalName;

                xmlNodeTreeView.SelectedNode.Nodes.Add(newTreeNode);
                refreshSource(node);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCommentXmlNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (xmlNodeTreeView.SelectedNode != null)
            {
                XmlNode node = getCurrentXmlNode();
                XmlNode newXmlNode = doc.CreateComment("*** Comment ****");

                node.AppendChild(newXmlNode);

                TreeNode newTreeNode = new TreeNode(newXmlNode.Name);

                newTreeNode.Tag = newXmlNode;
                newTreeNode.Text = newXmlNode.LocalName;

                xmlNodeTreeView.SelectedNode.Nodes.Add(newTreeNode);
                refreshSource(node);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addElementXmlNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (xmlNodeTreeView.SelectedNode != null)
            {
                XmlNode node = getCurrentXmlNode();
                XmlNode newXmlNode = doc.CreateElement("Element");

                node.AppendChild(newXmlNode);

                TreeNode newTreeNode = new TreeNode(newXmlNode.Name);

                newTreeNode.Tag = newXmlNode;
                newTreeNode.Text = newXmlNode.LocalName;

                xmlNodeTreeView.SelectedNode.Nodes.Add(newTreeNode);
                refreshSource(node);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            switch (e.Button)
            {
            case System.Windows.Forms.MouseButtons.Left:
                if (e.Item is TreeNode)
                {
                    TreeNode node = e.Item as TreeNode;

                    if (node.Tag is XmlElement || node.Tag is XmlComment || node.Tag is XmlText)
                    {
                        dragSelectTime = System.DateTime.Now;

                        DoDragDrop(node, DragDropEffects.Move | DragDropEffects.Copy | DragDropEffects.Scroll);
                    }
                }
                break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeTreeView_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = xmlNodeTreeView.PointToClient(new Point(e.X, e.Y));

            if (targetPoint.Y < (xmlNodeTreeView.ItemHeight / 2))
            {
                if (xmlNodeTreeView.TopNode.PrevVisibleNode != null)
                {
                    xmlNodeTreeView.TopNode = xmlNodeTreeView.TopNode.PrevVisibleNode;
                }
            }
            else if (targetPoint.Y >= ((xmlNodeTreeView.VisibleCount - 1) * xmlNodeTreeView.ItemHeight))
            {
                if (xmlNodeTreeView.TopNode.NextVisibleNode != null)
                {
                    xmlNodeTreeView.TopNode = xmlNodeTreeView.TopNode.NextVisibleNode;
                }
            }

            // Select the node at the mouse position.
            TreeNode targetNode = xmlNodeTreeView.GetNodeAt(targetPoint);
            TreeNode subjectNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (targetNode == null || subjectNode == null)
            {
                e.Effect = DragDropEffects.None;
            }
            else if (targetNode.TreeView != subjectNode.TreeView)
            {
                if (xmlNodeTreeView.SelectedNode != targetNode)
                {
                    dragSelectTime = System.DateTime.Now;
                    xmlNodeTreeView.SelectedNode = targetNode;

                    if (subjectNode.Tag is XmlNode)
                    {
                        if (subjectNode.Tag is XmlText)
                        {
                            if (subjectNode.Parent == targetNode)
                            {
                                e.Effect = DragDropEffects.Copy;
                            }
                            else
                            {
                                e.Effect = DragDropEffects.None;
                            }
                        }
                        else if (targetNode.Tag is XmlDocument || targetNode.Tag is XmlElement)
                        {
                            e.Effect = DragDropEffects.Copy;
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                        }
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
                else if (System.DateTime.Now.Subtract(dragSelectTime).TotalSeconds >= 1.0)
                {
                    dragSelectTime = System.DateTime.Now.AddSeconds(10);
                    if (targetNode.IsExpanded)
                    {
                        targetNode.Collapse();
                    }
                    else
                    {
                        targetNode.Expand();
                    }
                }
            }
            else
            {
                if (xmlNodeTreeView.SelectedNode != targetNode)
                {
                    dragSelectTime = System.DateTime.Now;
                    xmlNodeTreeView.SelectedNode = targetNode;

                    if (subjectNode.Tag is XmlNode)
                    {
                        if (subjectNode.Tag is XmlText)
                        {
                            if (subjectNode.Parent == targetNode)
                            {
                                e.Effect = ((e.KeyState & 8) == 0) ? DragDropEffects.Move : DragDropEffects.Copy;
                            }
                            else
                            {
                                e.Effect = DragDropEffects.None;
                            }
                        }
                        else if (targetNode.Tag is XmlDocument || targetNode.Tag is XmlElement)
                        {
                            e.Effect = ((e.KeyState & 8) == 0) ? DragDropEffects.Move : DragDropEffects.Copy;
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                        }
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
                else if (System.DateTime.Now.Subtract(dragSelectTime).TotalSeconds >= 1.0)
                {
                    dragSelectTime = System.DateTime.Now.AddSeconds(10);
                    if (targetNode.IsExpanded)
                    {
                        targetNode.Collapse();
                    }
                    else
                    {
                        targetNode.Expand();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeTreeView_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = xmlNodeTreeView.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = xmlNodeTreeView.GetNodeAt(targetPoint);
            TreeNode subjectNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            xmlNodeTreeView.SelectedNode = targetNode;

            if (targetNode == null || subjectNode == null)
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else if (targetNode != subjectNode)
            {
                XmlNode xmlTarget = targetNode.Tag as XmlNode;
                XmlNode xmlSubject = subjectNode.Tag as XmlNode;

                if (xmlTarget!=null && xmlSubject!=null)
                {
                    switch (e.Effect)
                    {
                    case DragDropEffects.Move:
                        if (targetNode.TreeView == subjectNode.TreeView)
                        {
                            xmlSubject.ParentNode.RemoveChild(xmlSubject);
                            xmlTarget.AppendChild(xmlSubject);
                            subjectNode.Remove();
                            targetNode.Nodes.Add(subjectNode);
                            refreshSource(xmlTarget);
                        }
                        else
                        {
                            System.Media.SystemSounds.Beep.Play();
                        }
                        break;

                    case DragDropEffects.Copy:
                        {
                            Cursor last = Cursor.Current;
                            Cursor.Current = Cursors.WaitCursor;
                            try
                            {
                                xmlTarget.InnerXml += xmlSubject.OuterXml;
                                refreshTree(false);
                                refreshSource(xmlTarget);
                            }
                            finally
                            {
                                Cursor.Current = last;
                            }
                        }
                        break;

                    default:
                        System.Media.SystemSounds.Beep.Play();
                        break;
                    }
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlNodeTreeView_DragEnter(object sender, DragEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlAttributesListView_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit=!(xmlAttributesListView.Items[e.Item].Tag is XmlAttribute);

            if (e.CancelEdit)
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xmlAttributesListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem item=xmlAttributesListView.Items[e.Item];
            XmlAttribute attr=item.Tag as XmlAttribute;

            if (attr != null)
            {
                XmlElement elem = attr.OwnerElement;

                if (elem != null)
                {
                    if (elem.GetAttributeNode(e.Label) == null)
                    {
                        elem.Attributes.Remove(attr);
                        elem.SetAttribute(e.Label, attr.Value);

                        item.Tag=elem.GetAttributeNode(e.Label);
                    }
                    else
                    {
                        e.CancelEdit = true;
                        System.Media.SystemSounds.Beep.Play();
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            else
            {
                e.CancelEdit = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgSearch.Show(this);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
