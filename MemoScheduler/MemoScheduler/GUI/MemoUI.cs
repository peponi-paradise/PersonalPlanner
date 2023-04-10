using DevExpress.XtraBars;
using System;
using System.Threading;
using System.Windows.Forms;
using MemoScheduler.Data;

namespace MemoScheduler.GUI
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
            MemoData.BackColor = MemoData.ToInternalColor(System.Drawing.Color.FromArgb((int)BackGroundColor.EditValue));
            ChangeSettings();
        }

        private void FontDialogCall_ItemClick(object sender, ItemClickEventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.FontMustExist = true;
            dialog.ShowColor = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MemoData.ToInternalFont(dialog.Font);
                MemoData.FontColor = MemoData.ToInternalColor(dialog.Color);
                ChangeSettings();
            }
        }

        private void ApplySettings()
        {
            this.Name= MemoData.Name;
            this.Text = MemoData.Name;
            Memo.Font = MemoData.ToDrawingFont();
            Memo.ForeColor = MemoData.ToDrawingColor(MemoData.FontColor);
            Memo.BackColor = MemoData.ToDrawingColor(MemoData.BackColor);
            this.BackColor = MemoData.ToDrawingColor(MemoData.BackColor);
            Memo.Text = MemoData.Memo;
        }

        private void ChangeSettings()
        {
            Memo.Font = MemoData.ToDrawingFont();
            Memo.ForeColor = MemoData.ToDrawingColor(MemoData.FontColor);
            Memo.BackColor = MemoData.ToDrawingColor(MemoData.BackColor);
            this.BackColor = MemoData.ToDrawingColor(MemoData.BackColor);
            PropertyChanged?.Invoke(MemoData);
        }
    }
}