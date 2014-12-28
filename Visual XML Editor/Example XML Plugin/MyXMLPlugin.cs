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
            get { return "Test XML Plugin"; }
        }

        public override string Description
        {
            get { return "Just a quick plug-in to test the XML Interface"; }
        }

        public override string Author
        {
            get { return "Roger L.S. Griffiths"; }
        }

        private Dictionary<string, CustomEditor> openEditors = new Dictionary<string,CustomEditor>();

        public override void Open(IDictionary<string, System.Xml.XmlDocument> xmlDocList)
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

        public override void Commit()
        {
            foreach (var entry in openEditors)
            {
                entry.Value.Commit();
            }
        }

        public override void Unload()
        {
            foreach (var entry in openEditors)
            {
                entry.Value.Close();
            }
            openEditors.Clear();
        }
    }
}
