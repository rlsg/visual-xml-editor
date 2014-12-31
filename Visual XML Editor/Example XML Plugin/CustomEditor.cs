using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uk.co.rlsg.apps.example_xml_plugin
{
    public partial class CustomEditor : Form
    {
        public CustomEditor(String title, System.Xml.XmlDocument doc)
        {
            InitializeComponent();
            if (title != null && title != "")
            {
                Text += " : " + title;
            }
            var builder = new StringBuilder();
            var settings = new System.Xml.XmlWriterSettings()
                {
                    Async = false,
                    Indent = true,
                    NewLineHandling = System.Xml.NewLineHandling.Replace,
                    NewLineOnAttributes = false
                };
            using (var writer = System.Xml.XmlWriter.Create(builder, settings))
            {
                doc.Save(writer);
                writer.Flush();
            };
            richTextBox.Text = builder.ToString();
            richTextBox.Tag = doc;
        }

        public void Commit()
        {
            if (richTextBox.Tag is System.Xml.XmlDocument)
            {
                var doc = richTextBox.Tag as System.Xml.XmlDocument;
                var _backup = doc.InnerXml;
                try
                {
                    doc.InnerXml = richTextBox.Text;
                }
                catch (Exception)
                {
                    doc.InnerXml = _backup;
                    throw;
                }
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox.Tag is System.Xml.XmlDocument)
            {
                var doc = richTextBox.Tag as System.Xml.XmlDocument;
                try
                {
                    doc.InnerXml = richTextBox.Text;
                    richTextBox.BackColor = Color.White;
                }
                catch (System.Xml.XmlException)
                {
                    richTextBox.BackColor = Color.LightPink;
                }
            }
        }

        private void CustomEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Commit();
            }
            catch (System.Xml.XmlException)
            {
                // XML Format Error
                switch (MessageBox.Show(this, "Do wish to close and lose any unsaved changes?", "XML Validation Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2))
                {
                    case System.Windows.Forms.DialogResult.No:
                        e.Cancel = true;
                        break;
                }

            }
            catch (Exception err)
            {
                // Internal Error
                String message =
                    "Please report the following information to the plugin author:-\n" +
                    "\n    Object: " + err.Source +
                    "\n    Method: " + err.TargetSite +
                    "\n    Message: " + err.Message +
                    "\n\nStack Trace\n-----------\n" + err.StackTrace;
                MessageBox.Show(this, message, "PLUGIN INTERNAL ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }
    }
}
