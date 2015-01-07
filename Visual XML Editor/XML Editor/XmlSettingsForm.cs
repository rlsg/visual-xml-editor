using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uk.co.rlsg.apps.xml_editor
{
    public partial class XmlSettingsForm : Form
    {
        private System.Xml.XmlWriterSettings xmlSettings;

        public XmlSettingsForm(System.Xml.XmlWriterSettings _xmlSettings)
        {
            xmlSettings = _xmlSettings;

            InitializeComponent();

            switch (xmlSettings.IndentChars)
            {
                case "":
                    radioButtonIndentNone.Select();
                    break;

                case "\t":
                    radioButtonIndentTab.Select();
                    break;

                default:
                    numericUpDownSpaceCount.Value = Math.Max(numericUpDownSpaceCount.Minimum, Math.Min(xmlSettings.IndentChars.Length, numericUpDownSpaceCount.Maximum));
                    radioButtonIndentSpace.Select();
                    break;
            }

            if (xmlSettings.Indent)
            {
                if (xmlSettings.NewLineOnAttributes)
                {
                    radioButtonNLAttr.Select();
                }
                else
                {
                    radioButtonNLTag.Select();
                }
            }
            else
            {
                radioButtonNLNone.Select();
            }

            switch (xmlSettings.NewLineChars)
            {
                case "\n":
                    comboBoxEOL.SelectedIndex = 0;
                    break;

                default:
                    comboBoxEOL.SelectedIndex = 1;
                    break;
            }
        }

        private void XmlSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void radioButtonNLNone_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNLNone.Checked)
            {
                comboBoxEOL.Enabled = false;

                xmlSettings.Indent = false;
                xmlSettings.NewLineOnAttributes = false;
            }
        }

        private void radioButtonNLTag_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNLTag.Checked)
            {
                comboBoxEOL.Enabled = true;

                xmlSettings.Indent = true;
                xmlSettings.NewLineOnAttributes = false;
            }
        }

        private void radioButtonNLAttr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNLAttr.Checked)
            {
                comboBoxEOL.Enabled = true;

                xmlSettings.Indent = true;
                xmlSettings.NewLineOnAttributes = true;
            }
        }

        private void comboBoxEOL_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEOL.SelectedIndex)
            {
                case 0:
                    xmlSettings.NewLineChars = "\n";
                    break;

                default:
                    xmlSettings.NewLineChars = "\r\n";
                    break;
            }
        }

        private void radioButtonIndentNone_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIndentNone.Checked)
            {
                numericUpDownSpaceCount.Enabled = false;

                xmlSettings.IndentChars = "";
            }
        }

        private void radioButtonIndentTab_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIndentTab.Checked)
            {
                numericUpDownSpaceCount.Enabled = false;

                xmlSettings.IndentChars = "\t";
            }
        }

        private void radioButtonIndentSpace_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIndentSpace.Checked)
            {
                numericUpDownSpaceCount.Enabled = true;

                xmlSettings.IndentChars=new String(' ', (int)numericUpDownSpaceCount.Value);
            }
        }

        private void numericUpDownSpaceCount_ValueChanged(object sender, EventArgs e)
        {
            xmlSettings.IndentChars = new String(' ', (int)numericUpDownSpaceCount.Value);
        }
    }
}
