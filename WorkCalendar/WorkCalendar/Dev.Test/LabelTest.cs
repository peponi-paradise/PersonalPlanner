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

    public class labeltest : IYAML
    {
        public class nested
        {
            public int A = 0, R = 0, G = 0, B = 0;
            public object Id = 0;
            public string DisplayName = "";
        }

        public List<nested> appointmentLabels;

        public bool LoadData()
        {
            YAMLParser.LoadData($@"{Environment.CurrentDirectory}\labeltest.yaml", out List<nested> appointmentLabels);
            this.appointmentLabels = appointmentLabels;
            return true;
        }

        public void LoadData(IAppointmentLabelStorage labelStorage)
        {
            YAMLParser.LoadData($@"{Environment.CurrentDirectory}\labeltest.yaml", out List<nested> appointmentLabels);
            this.appointmentLabels = appointmentLabels;
            labelStorage.Clear();
            foreach (var item in appointmentLabels)
            {
                var label = labelStorage.CreateNewLabel(item.Id, item.DisplayName, item.DisplayName);
                label.SetColor(Color.FromArgb(item.A, item.R, item.G, item.B));
                labelStorage.Add(label);
            }
        }

        public void SaveData()
        {
            YAMLParser.SaveData($@"{Environment.CurrentDirectory}\labeltest.yaml", appointmentLabels);
        }

        public void SaveData(IAppointmentLabelStorage labelStorage)
        {
            appointmentLabels.Clear();
            foreach (var item in labelStorage)
            {
                var data = new nested() { Id = item.Id, DisplayName = item.DisplayName, A = item.GetColor().A, R = item.GetColor().R, G = item.GetColor().G, B = item.GetColor().B };
                appointmentLabels.Add(data);
            }
            YAMLParser.SaveData($@"{Environment.CurrentDirectory}\labeltest.yaml", appointmentLabels);
        }
    }
}