using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.rlsg.apps.xml_editor
{
    /// <summary>
    /// <para>This abstract class is intended to be the base class
    /// used for all plug-ins.</para>
    /// </summary>
    public abstract class PluginBase : IPlugin
    {
        #region IPlugin Interface
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string Author { get; }

        public abstract void Open(IDictionary<string, System.Xml.XmlDocument> xmlDocList);
        public abstract void Commit();
        public abstract void Unload();
        #endregion IPlugin Interface

        /// <summary>
        /// <para>This method provides a way for plug-ins to report
        /// internal errors via the main application.</para>
        /// </summary>
        /// <param name="err"></param>
        public void displayError(Exception err)
        {
            try
            {
                MainForm.displayError(this, err);
            }
            catch (Exception _err)
            {
                MainForm.displayError(_err);
            }
        }
    }
}
