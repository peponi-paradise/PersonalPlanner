using DevExpress.XtraBars;
using PersonalPlanner.Define;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PersonalPlanner.GUI
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
            MemoData.BackColor.ToInternalColor(System.Drawing.Color.FromArgb((int)BackGroundColor.EditValue));
            ChangeSettings();
        }

        private void FontDialogCall_ItemClick(object sender, ItemClickEventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.FontMustExist = true;
            dialog.ShowColor = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MemoData.Font.ToInternalFont(dialog.Font);
                MemoData.FontColor.ToInternalColor(dialog.Color);
                ChangeSettings();
            }
        }

        private void ApplySettings()
        {
            this.Name = MemoData.Name;
            this.Text = MemoData.Name;
            Memo.Font = MemoData.Font.ToDrawingFont();
            Memo.ForeColor = MemoData.FontColor.ToDrawingColor();
            Memo.BackColor = MemoData.BackColor.ToDrawingColor();
            this.BackColor = MemoData.BackColor.ToDrawingColor();
            Memo.Text = MemoData.Memo;
        }

        private void ChangeSettings()
        {
            Memo.Font = MemoData.Font.ToDrawingFont();
            Memo.ForeColor = MemoData.FontColor.ToDrawingColor();
            Memo.BackColor = MemoData.BackColor.ToDrawingColor();
            this.BackColor = MemoData.BackColor.ToDrawingColor();
            PropertyChanged?.Invoke(MemoData);
        }
    }
}