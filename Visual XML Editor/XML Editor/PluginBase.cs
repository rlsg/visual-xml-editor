using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.rlsg.apps.xml_editor
{
    public abstract class PluginBase : IPlugin
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string Author { get; }

        public abstract void Open(IDictionary<string, System.Xml.XmlDocument> xmlDocList);
        public abstract void Commit();
        public abstract void Unload();
    }
}
