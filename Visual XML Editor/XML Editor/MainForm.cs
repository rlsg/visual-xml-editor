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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Plugins == null)
            {
                Properties.Settings.Default.Plugins = new System.Collections.Specialized.StringCollection();
            }
        }

        private IDictionary<String, System.Xml.XmlDocument> SelectedDocuments
        {
            get
            {
                return
                    (from fileItem in listViewFiles.SelectedItems.OfType<ListViewItem>()
                     where fileItem.Tag is System.Xml.XmlDocument
                     select new
                     {
                         name = fileItem.Name,
                         doc = fileItem.Tag as System.Xml.XmlDocument
                     }).ToDictionary((_) => _.name, (_) => _.doc);
            }
        }

        static internal void displayError(Exception err, bool fatal = false)
        {
            displayError(ActiveForm, err, fatal);
        }

        static internal void displayError(IWin32Window wnd, Exception err, bool fatal = false)
        {
            MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];

            String message =
                "Please report the following information to the author:-\n" +
                "\n    Object: " + err.Source +
                "\n    Method: " + err.TargetSite +
                "\n    Message: " + err.Message +
                "\n\nStack Trace\n-----------\n" + err.StackTrace;

            if (fatal)
            {
                MessageBox.Show(wnd,
                    "The application needs to restart because of an unrecoverable error.\n\n" +
                    message, "FATAL ERROR REPORT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                System.Windows.Forms.Application.Restart();
            }
            else
            {
                MessageBox.Show(wnd, message, "RECOVERABLE ERROR REPORT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        static internal void displayError(string path, Exception err)
        {
            displayError(ActiveForm, path, err);
        }

        static internal void displayError(IWin32Window wnd, string path, Exception err)
        {
            MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];

            String message =
                "Please report the following information to the plugin author:-\n" +
                "\n    Plug-in Path: " + path +
                "\n    Object: " + err.Source +
                "\n    Method: " + err.TargetSite +
                "\n    Message: " + err.Message +
                "\n\nStack Trace\n-----------\n" + err.StackTrace;

            MessageBox.Show(wnd, message, "PLUGIN LOAD ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        static internal void displayError(IPlugin plugin, Exception err)
        {
            displayError(ActiveForm, plugin, err);
        }

        static internal void displayError(IWin32Window wnd, IPlugin plugin, Exception err)
        {
            MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];

            String message =
                "Please report the following information to the plugin author:-\n" +
                "\n    Plug-in Name: " + plugin.Name +
                "\n    Plug-in Author: " + plugin.Author +
                "\n    Object: " + err.Source +
                "\n    Method: " + err.TargetSite +
                "\n    Message: " + err.Message +
                "\n\nStack Trace\n-----------\n" + err.StackTrace;

            MessageBox.Show(wnd, message, "PLUGIN INTERNAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private ListViewItem getContextMenuItem(object sender)
        {
            ListViewItem subject = listViewFiles.FocusedItem;

            if (typeof(ListViewItem).IsInstanceOfType(sender))
            {
                if (subject != sender)
                {
                    subject = (ListViewItem)sender;
                    listViewFiles.FocusedItem = subject;
                }
            }

            return subject;
        }

        private bool openItem(string title, object data)
        {
            bool operatedOn = true;

            var last = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (data == null)
                {
                    // Do Nothing
                    operatedOn = false;
                }
                else if (data is System.Xml.XmlDocument)
                {
                    new uk.co.rlsg.apps.xml_editor.XmlEditorForm(title, data as System.Xml.XmlDocument).Show(this);
                }
                else
                {
                    operatedOn = false;
                }
            }
            catch (Exception err)
            {
                displayError(err);
            }
            Cursor.Current = last;

            return operatedOn;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _listLabel = "newFile";
            var listLabel = _listLabel;
            var fileNo = 1;
            while (listViewFiles.Items.ContainsKey(listLabel))
            {
                listLabel = _listLabel + "_" + (fileNo++).ToString();
            }
            var newItem = listViewFiles.Items.Add(new ListViewItem(new string[]
            {
                listLabel,
                ""
            })
            {
                Name = listLabel
            });
            if (newItem != null)
            {
                var xmlDoc = new uk.co.rlsg.apps.xml_editor.XmlEditorForm(listLabel).get();

                if (xmlDoc != null)
                {
                    newItem.Tag = xmlDoc;
                }
                else
                {
                    listViewFiles.Items.Remove(newItem);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();

            dlg.Title = "Open XML File";
            dlg.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            dlg.DefaultExt = ".xml";
            dlg.Multiselect = true;

            switch (dlg.ShowDialog(this))
            {
                case System.Windows.Forms.DialogResult.OK:
                    addFiles(dlg.FileNames);
                    break;

                default:
                    break;
            }
        }

        private void addFiles(IEnumerable<string> fileList)
        {
            var last = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (var fileName in fileList)
                {
                    try
                    {
                        var xmlDoc = new System.Xml.XmlDocument();
                        xmlDoc.Load(fileName);
                        var _listLabel = System.IO.Path.GetFileNameWithoutExtension(fileName);
                        var listLabel = _listLabel;
                        var fileNo = 1;
                        while (listViewFiles.Items.ContainsKey(listLabel))
                        {
                            listLabel = _listLabel + "_" + (fileNo++).ToString();
                        }

                        var newItem = listViewFiles.Items.Add(new ListViewItem(new string[]
                                    {
                                        listLabel,
                                        fileName
                                    })
                                    {
                                        Name = listLabel
                                    });
                        if (newItem != null)
                        {
                            newItem.Tag = xmlDoc;
                        }
                    }
                    catch (OutOfMemoryException)
                    {
                        throw;
                    }
                    catch (Exception err)
                    {
                        displayError(err);
                    }
                }
            }
            catch (Exception err)
            {
                displayError(err);
            }
            listViewFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Cursor.Current = last;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commitPlugins();
            foreach (var item in listViewFiles.SelectedItems.OfType<ListViewItem>())
            {
                var xmlDoc = item.Tag as System.Xml.XmlDocument;
                if (xmlDoc != null)
                {
                    var path = item.SubItems[1] as ListViewItem.ListViewSubItem;

                    if (path != null)
                    {
                        try
                        {
                            var fileName = path.Text;
                            if (fileName != "")
                            {
                                var file = new System.IO.FileInfo(fileName);
                                if (file.Exists)
                                {
                                    file.MoveTo(System.IO.Path.ChangeExtension(fileName, "bak"));
                                }
                                xmlDoc.Save(fileName);
                            }
                            else
                            {
                                var dlg = new SaveFileDialog();

                                dlg.Title = "Save XML File";
                                dlg.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                                dlg.DefaultExt = ".xml";
                                dlg.FileName = item.Text;

                                switch (dlg.ShowDialog(this))
                                {
                                    case System.Windows.Forms.DialogResult.OK:
                                        xmlDoc.Save(dlg.FileName);
                                        path.Text = dlg.FileName;
                                        break;
                                }
                            }
                        }
                        catch (Exception err)
                        {
                            displayError(err);
                        }
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commitPlugins();
            foreach (var item in listViewFiles.SelectedItems.OfType<ListViewItem>())
            {
                var xmlDoc = item.Tag as System.Xml.XmlDocument;
                if (xmlDoc != null)
                {
                    var path = item.SubItems[1] as ListViewItem.ListViewSubItem;

                    if (path != null)
                    {
                        try
                        {
                            var fileName = path.Text;
                            var dlg = new SaveFileDialog();

                            dlg.Title = "Save XML File";
                            dlg.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                            dlg.DefaultExt = ".xml";
                            if (fileName != "")
                            {
                                dlg.InitialDirectory = System.IO.Path.GetDirectoryName(fileName);
                            }
                            dlg.FileName = item.Text;

                            switch (dlg.ShowDialog(this))
                            {
                                case System.Windows.Forms.DialogResult.OK:
                                    xmlDoc.Save(dlg.FileName);
                                    path.Text = dlg.FileName;
                                    break;
                            }
                        }
                        catch (Exception err)
                        {
                            displayError(err);
                        }
                    }
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unloadPlugins();
            var last = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                while (listViewFiles.SelectedItems.Count > 0)
                {
                    listViewFiles.Items.Remove(listViewFiles.SelectedItems[0]);
                }
            }
            catch (Exception err)
            {
                displayError(err);
            }
            Cursor.Current = last;
        }

        private void xMLDiffGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count != 2)
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else
            {
                // TODO: Implement XML Diff generation
                var itemA = listViewFiles.SelectedItems[0];
                var itemB = listViewFiles.SelectedItems[1];
                var xmlDocA = itemA.Tag as System.Xml.XmlDocument;
                var xmlDocB = itemB.Tag as System.Xml.XmlDocument;
            }
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            enablePlugins();
        }

        private void listViewFiles_ItemActivate(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 1)
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else
            {
                ListViewItem item = getContextMenuItem(sender);

                if (item != null)
                {
                    openItem(item.Text, item.Tag);
                }
            }
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            var fileList = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (fileList != null)
            {
                addFiles(fileList);
            }
        }

        private void listViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            var item = listViewFiles.Items[e.Item];
            if (item.Text == e.Label)
            {
                e.CancelEdit = true;
            }
            else if (listViewFiles.Items.ContainsKey(e.Label))
            {
                e.CancelEdit = true;
            }
            else
            {
                item.Name = e.Label;
                item.Text = e.Label;
                listViewFiles.Sort();
                e.CancelEdit = true;
            }
        }

        private void pluginsManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new PluginManagerForm();

            dlg.ShowDialog();

            Properties.Settings.Default.Save();

            loadPlugins();
        }

        private void commitPlugins()
        {
            try
            {
                var list = pluginsToolStripMenuItem.DropDownItems;

                foreach (var item in list.OfType<ToolStripMenuItem>().Skip(1))
                {
                    if (item.Tag is IPlugin)
                    {
                        var plugin = item.Tag as IPlugin;

                        try
                        {
                            plugin.Commit();
                        }
                        catch (Exception err)
                        {
                            displayError(plugin, err);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                displayError(err);
            }
        }

        private void unloadPlugins()
        {
            try
            {
                var list = pluginsToolStripMenuItem.DropDownItems;

                while (list.Count > 2)
                {
                    var item = list[2];

                    if (item.Tag is IPlugin)
                    {
                        var plugin = item.Tag as IPlugin;

                        try
                        {
                            plugin.Unload();
                        }
                        catch (Exception err)
                        {
                            displayError(plugin, err);
                        }
                    }

                    list.Remove(item);
                }
            }
            catch (Exception err)
            {
                displayError(err);
            }
        }

        private void enablePlugins()
        {
            try
            {
                var selectionCount = listViewFiles.SelectedItems.Count;
                var list = pluginsToolStripMenuItem.DropDownItems;

                foreach (var item in list.OfType<ToolStripMenuItem>().Skip(1))
                {
                    if (item.Tag is IPlugin)
                    {
                        var plugin = item.Tag as IPlugin;

                        item.Enabled = selectionCount >= 1;
                    }
                }
            }
            catch (Exception err)
            {
                displayError(err);
            }
        }

        private void loadPlugins()
        {
            unloadPlugins();
            try
            {
                var list = pluginsToolStripMenuItem.DropDownItems;

                foreach (var path in Properties.Settings.Default.Plugins)
                {
                    try
                    {
                        var _dll = System.Reflection.Assembly.LoadFile(path);

                        if (_dll != null)
                        {
                            var pluginList =
                                (from _type in _dll.GetExportedTypes()
                                 where _type.IsClass && _type.BaseType == typeof(PluginBase)
                                 orderby _type.Name
                                 select _type);
                            foreach (var pluginType in pluginList)
                            {
                                var _instance = _dll.CreateInstance(pluginType.FullName);
                                var instance = _instance as PluginBase;
                                if (instance != null)
                                {
                                    var newPlugin = new ToolStripMenuItem
                                    {
                                        Text = instance.Name,
                                        ToolTipText = instance.Description,
                                        Tag = instance,
                                    };

                                    newPlugin.Click += launchPlugin_Click;
                                    list.Add(newPlugin);
                                }
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        displayError(path, err);
                    }
                }
            }
            catch (Exception err)
            {
                displayError(err);
            }
            enablePlugins();
        }

        private void launchPlugin_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripMenuItem)
                {
                    var pluginItem = sender as ToolStripMenuItem;


                    if (pluginItem.Tag is IPlugin)
                    {
                        var plugin = pluginItem.Tag as IPlugin;

                        try
                        {
                            plugin.Open(SelectedDocuments);
                        }
                        catch (Exception err)
                        {
                            displayError(plugin, err);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                displayError(err);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            loadPlugins();
        }
    }
}
