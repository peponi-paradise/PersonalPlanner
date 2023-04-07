using DevExpress.XtraBars;
using DevExpress.XtraRichEdit.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkCalendar.Dev.Test
{
    public partial class MemoUI : DevExpress.XtraEditors.XtraForm
    {
        public delegate void PropertyChangedEventHandler(MemoDefine memoData);

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void MemoUpdateEventHandler(MemoDefine memoData);

        public event MemoUpdateEventHandler MemoUpdated;

        private MemoDefine MemoData;

        private System.Timers.Timer Timer;
        private readonly SynchronizationContext SyncContext;

        public MemoUI()
        {
            InitializeComponent();
            SyncContext = SynchronizationContext.Current;
            MemoData = new MemoDefine();
            repositoryItemColorPickEdit1.StoreColorAsInteger = true;
            ActivateTimer();
        }

        public MemoUI(MemoDefine MemoData)
        {
            InitializeComponent();
            SyncContext = SynchronizationContext.Current;
            this.MemoData = MemoData;
            repositoryItemColorPickEdit1.StoreColorAsInteger = true;
            ApplySettings();
            ActivateTimer();
        }

        private void ActivateTimer()
        {
            Timer = new System.Timers.Timer();
            Timer.Interval = 3000;
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (MemoData.Memo != Memo.Text)
            {
                SyncContext.Post(delegate { MemoData.Memo = Memo.Text; }, null);
                MemoUpdated?.Invoke(MemoData);
            }
        }

        private void BackGroundColor_EditValueChanged(object sender, EventArgs e)
        {
            MemoData.BackColor = Color.FromArgb((int)BackGroundColor.EditValue);
            ChangeSettings();
        }

        private void FontDialogCall_ItemClick(object sender, ItemClickEventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.FontMustExist = true;
            dialog.ShowColor = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MemoData.Font = dialog.Font;
                MemoData.FontColor = dialog.Color;
                ChangeSettings();
            }
        }

        private void ApplySettings()
        {
            this.Text = MemoData.Name;
            Memo.Font = MemoData.Font;
            Memo.ForeColor = MemoData.FontColor;
            Memo.BackColor = MemoData.BackColor;
            this.BackColor = MemoData.BackColor;
            Memo.Text = MemoData.Memo;
        }

        private void ChangeSettings()
        {
            Memo.Font = MemoData.Font;
            Memo.ForeColor = MemoData.FontColor;
            Memo.BackColor = MemoData.BackColor;
            this.BackColor = MemoData.BackColor;
            PropertyChanged?.Invoke(MemoData);
        }
    }
}