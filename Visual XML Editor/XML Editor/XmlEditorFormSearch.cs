using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace uk.co.rlsg.apps.xml_editor
{
    public partial class XmlEditorFormSearch : Form
    {
        private TreeView xmlNodeView;

        public XmlEditorFormSearch(String title, TreeView xmlNodeView)
        {
            InitializeComponent();

            if (title != null && title != "")
            {
                Text += " : " + title;
            }

            this.xmlNodeView = xmlNodeView;
        }

        private bool testNode(TreeNode testNode)
        {
            if (testNode.Tag is XmlComment)
            {
                var xmlComment = testNode.Tag as XmlComment;
                if (checkBoxCommentNodes.Checked)
                {
                    return xmlComment.Value.Contains(textBox.Text);
                }
                else
                {
                    return false;
                }
            }
            else if (testNode.Tag is XmlText)
            {
                var xmlText = testNode.Tag as XmlText;
                if (checkBoxTextNodes.Checked)
                {
                    return xmlText.Value.Contains(textBox.Text);
                }
                else
                {
                    return false;
                }
            }
            else if (testNode.Tag is XmlNode)
            {
                var xmlNode = testNode.Tag as XmlNode;
                if (checkBoxNodeName.Checked)
                {
                    if (xmlNode.Name.Contains(textBox.Text))
                    {
                        return true;
                    }
                }
                if (xmlNode.Attributes != null)
                {
                    if (checkBoxAttributeName.Checked)
                    {
                        foreach (var attr in xmlNode.Attributes.OfType<XmlAttribute>())
                        {
                            if (attr.Name.Contains(textBox.Text))
                            {
                                return true;
                            }
                        }
                    }
                    if (checkBoxAttributeValue.Checked)
                    {
                        foreach (var attr in xmlNode.Attributes.OfType<XmlAttribute>())
                        {
                            if (attr.Value.Contains(textBox.Text))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private TreeNode searchChildren(TreeNode rootNode)
        {
            foreach (var node in rootNode.Nodes.OfType<TreeNode>())
            {
                if (testNode(node))
                {
                    return node;
                }
                else
                {
                    var rval = searchChildren(node);
                    if (rval != null)
                    {
                        return rval;
                    }
                }
            }
            return null;
        }

        private TreeNode findNextNode(TreeNode currentNode)
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (currentNode.NextNode != null)
            {
                return currentNode.NextNode;
            }
            else
            {
                return findNextNode(currentNode.Parent);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Cursor last = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var startNode = xmlNodeView.SelectedNode;

                if (startNode == null)
                {
                    if (xmlNodeView.Nodes.Count > 0)
                    {
                        startNode = xmlNodeView.Nodes[0];
                    }
                }

                var foundNode = startNode;
                if (startNode != null)
                {
                    var currentNode = startNode;

                    do
                    {
                        var checkNode = searchChildren(currentNode);
                        if (checkNode != null)
                        {
                            foundNode = checkNode;
                        }
                        else
                        {
                            currentNode = findNextNode(currentNode);

                            if (currentNode != null)
                            {
                                if (testNode(currentNode))
                                {
                                    foundNode = currentNode;
                                }
                            }
                        }
                    }
                    while ((currentNode != null) && (foundNode == startNode));
                }

                if (foundNode != startNode)
                {
                    xmlNodeView.SelectedNode = foundNode;
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            catch (Exception)
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
            Cursor.Current = last;
        }

        private void XmlEditorFormSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Visible)
            {
                switch (e.CloseReason)
                {
                    case CloseReason.UserClosing:
                        Hide();
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
