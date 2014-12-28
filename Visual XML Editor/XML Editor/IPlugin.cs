using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.rlsg.apps.xml_editor
{
    /// <summary>
    /// <para>This interface defines how the Visual XML Editor
    /// will interact with plug-ins.</para>
    /// </summary>
    interface IPlugin
    {
        /// <summary>
        /// <para>This property is used for the Tool menu label and is
        /// presented in plug-in error reports after a plug-in has been
        /// successfully loaded</para>
        /// </summary>
        String Name { get; }
        /// <summary>
        /// <para>This property is used for the Tool menu tool tip.</para>
        /// </summary>
        String Description { get; }
        /// <summary>
        /// <para>This property is used in error handling to indicate
        /// the plug-in author to the user after a plug-in has been
        /// successfully loaded.</para>
        /// </summary>
        String Author { get; }

        /// <summary>
        /// <para>This method is called when the plugin is activated
        /// from the Tools menu.</para>
        /// </summary>
        /// <param name="xmlDocList">The list of currently selected XML documents indexed by XML alias.</param>
        void Open(IDictionary<String, System.Xml.XmlDocument> xmlDocList);
        /// <summary>
        /// <para>This method is called immediately prior to a save operation to
        /// ensure all current open plug-ins apply any necessary changes to the
        /// source XML DOM object(s).</para>
        /// </summary>
        void Commit();
        /// <summary>
        /// <para>This method is called immediately prior to the application
        /// explicitly unloading the plug-in. It is used primarilly to ensure
        /// that all open windows are closed and any resources are released.</para>
        /// </summary>
        void Unload();
    }
}
