using DevExpress.Utils.Drawing;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.CustomEditor;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkCalendar.GUI
{
    public partial class LabelTest : Form
    {
        private RepositoryItemColorPickEdit ColorPickEdit;

        public LabelTest()
        {
            InitializeComponent();
            ColorPickEdit = new RepositoryItemColorPickEdit();
            ColorPickEdit.StoreColorAsInteger = true;
            gridControl1.DataSourceChanged += GridControl1_DataSourceChanged;
        }

        private void GridControl1_DataSourceChanged(object sender, EventArgs e)
        {
            if (!gridControl1.RepositoryItems.Contains(ColorPickEdit))
            {
                gridControl1.RepositoryItems.Add(ColorPickEdit);
                ColorPickEdit.AutoHeight = false;
                ColorPickEdit.AutomaticColor = Color.Black;
                ColorPickEdit.Name = "Color Picker";
            }
            if (gridView1.Columns.ColumnByFieldName("Color") != null) gridView1.Columns["Color"].ColumnEdit = ColorPickEdit;
        }

        public void SetDataSources(object source) => gridControl1.DataSource = source;
    }
}