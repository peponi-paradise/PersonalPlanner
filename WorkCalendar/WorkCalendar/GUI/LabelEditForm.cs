using DevExpress.Utils.Drawing;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.CustomEditor;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkCalendar.Parser.YAML;

namespace WorkCalendar.GUI
{
    public partial class LabelEditForm : Form
    {
        private RepositoryItemColorPickEdit ColorPickEdit;

        public LabelEditForm()
        {
            InitializeComponent();
            ColorPickEdit = new RepositoryItemColorPickEdit();
            ColorPickEdit.StoreColorAsInteger = true;
            MainGridControl.DataSourceChanged += MainGridControl_DataSourceChanged;
        }

        private void MainGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            if (!MainGridControl.RepositoryItems.Contains(ColorPickEdit))
            {
                MainGridControl.RepositoryItems.Add(ColorPickEdit);
                ColorPickEdit.AutoHeight = false;
                ColorPickEdit.AutomaticColor = Color.Black;
                ColorPickEdit.Name = "Color Picker";
            }
            if (MainGridView.Columns.ColumnByFieldName("Color") != null) MainGridView.Columns["Color"].ColumnEdit = ColorPickEdit;
        }

        public void SetDataSources(object source) => MainGridControl.DataSource = source;
    }
}