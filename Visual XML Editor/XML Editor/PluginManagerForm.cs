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
    public partial class PluginManagerForm : Form
    {
        public PluginManagerForm()
        {
            InitializeComponent();

            pluginListView.Items.Clear();
            foreach (var path in Properties.Settings.Default.Plugins)
            {
                pluginListView.Items.Add(path);
            }
            pluginListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();

            dlg.Title = "Add Plugins";
            dlg.Filter = "DLL Files (*.dll)|*.dll";
            dlg.DefaultExt = ".dll";
            dlg.Multiselect = true;

            switch (dlg.ShowDialog(this))
            {
                case System.Windows.Forms.DialogResult.OK:
                    var pluginRegister = Properties.Settings.Default.Plugins;
                    foreach (var fileName in dlg.FileNames)
                    {
                        if (!pluginRegister.Contains(fileName))
                        {
                            pluginListView.Items.Add(fileName);
                            pluginRegister.Add(fileName);
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pluginRegister = Properties.Settings.Default.Plugins;
            while (pluginListView.SelectedItems.Count > 0)
            {
                pluginListView.Items.Remove(pluginListView.SelectedItems[0]);
            }
            
            pluginRegister.Clear();
            pluginRegister.AddRange(
                (from item in pluginListView.Items.OfType<ListViewItem>()
                 select item.Text).ToArray());

        }
    }
}
