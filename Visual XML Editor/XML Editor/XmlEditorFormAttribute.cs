using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uk.co.rlsg.apps.xml_editor
{
    public partial class XmlEditorFormAttribute : Form
    {
        internal String value;

        internal XmlEditorFormAttribute(String name, String value)
        {
            this.value = value;

            InitializeComponent();
            this.Text = this.Text + " ["+ name +"]";

            textBoxValue.Text = value;
            textBoxValue.BackColor = Color.FromName("Window");
            buttonOk.Enabled = false;
        }

        private void textBoxBias_TextChanged(object sender, EventArgs e)
        {
            if (!value.Equals(textBoxValue.Text))
            {
                buttonOk.Enabled = true;
                textBoxValue.BackColor = Color.Yellow;
            }
            else
            {
                buttonOk.Enabled = false;
                textBoxValue.BackColor = Color.FromName("Window");
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            value = textBoxValue.Text;
        }

        private void XmlEditorFormAttribute_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control target = sender as Control;

            if (target != null)
            {
                String helpText = target.Tag as String;

                if (helpText != null)
                {
                    hlpevent.Handled = true;
                    MessageBox.Show(this, helpText.Replace("\\n", "\n").Replace("\\t", "\t"), "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
