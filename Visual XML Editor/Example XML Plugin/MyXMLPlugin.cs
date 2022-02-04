using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.rlsg.apps.example_xml_plugin
{
    public class MyXMLPlugin : uk.co.rlsg.apps.xml_editor.PluginBase
    {
        public override string Name
        {
            get { return "Simple XML Text Editor"; }
        }

        public override string Description
        {
            get
            {
                return
                    "A simple XML text editor example plug-in to\n" +
                    "demonstrate how to write plug-ins for the\n" +
                    "Visual XML Editor.";
            }
        }

        public override string Author
        {
            get { return "S. Lenna R. Griffiths"; }
        }

        private Dictionary<string, CustomEditor> openEditors = new Dictionary<string,CustomEditor>();

        public override void Open(IDictionary<string, System.Xml.XmlDocument> xmlDocList)
        {
            var last = System.Windows.Forms.Cursor.Current;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                foreach (var entry in xmlDocList)
                {
                    var name = entry.Key;
                    var doc = entry.Value;
                    CustomEditor dlg = null;
                    if (openEditors.TryGetValue(name, out dlg))
                    {
                        dlg.Close();
                    }
                    dlg = new CustomEditor(name, doc);
                    dlg.Show();
                    openEditors[name] = dlg;
                }
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = last;
            }
        }

        public override void Commit()
        {
            var last = System.Windows.Forms.Cursor.Current;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                foreach (var entry in openEditors)
                {
                    entry.Value.Commit();
                }
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = last;
            }
        }

        public override void Unload()
        {
            var last = System.Windows.Forms.Cursor.Current;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                foreach (var entry in openEditors)
                {
                    entry.Value.Close();
                }
                openEditors.Clear();
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = last;
            }
        }
    }
}
