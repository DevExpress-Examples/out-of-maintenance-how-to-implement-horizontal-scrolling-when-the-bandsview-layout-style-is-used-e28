using System;
using System.Collections;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using System.Drawing;

namespace WindowsFormsApplication2 {
    public partial class HScrollableVGrid : UserControl {
        static FieldInfo scrollStrategyField = typeof(VGridScroller).GetField("scrollStrategy", BindingFlags.NonPublic | BindingFlags.Instance);
        static PropertyInfo bandWidthProperty = typeof(BandsScrollStrategy).GetProperty("BandWidth", BindingFlags.NonPublic | BindingFlags.Instance);
        static PropertyInfo bandIntervalProperty = typeof(BandsScrollStrategy).GetProperty("BandInterval", BindingFlags.NonPublic | BindingFlags.Instance);
        static FieldInfo bandsInfoField = typeof(BandsScrollStrategy).GetField("BandsInfo", BindingFlags.NonPublic | BindingFlags.Instance);
        static PropertyInfo bandsInfoProperty = typeof(BandsScrollStrategy).GetProperty("BandsInfo", BindingFlags.NonPublic | BindingFlags.Instance);

        bool vGridWidthIsInit = false;

        public HScrollableVGrid() {
            InitializeComponent();
            UpdateVGridWidth();
        }
        public VGridControl VGridControl { get { return vGridControl1; } }
        void UpdateVGridWidth() {
            VGridScroller scroller = vGridControl1.ViewInfo.Scroller;
            BandsScrollStrategy scrollStrategy = (BandsScrollStrategy)scrollStrategyField.GetValue(scroller);
            int bandWidth = (int)bandWidthProperty.GetValue(scrollStrategy, null);
            int bandInterval = (int)bandIntervalProperty.GetValue(scrollStrategy, null);
            object bansInfoObject = bandsInfoProperty != null ? bandsInfoProperty.GetValue(scrollStrategy, null) : bandsInfoField.GetValue(scrollStrategy);
            int bandsCount = (int)((ArrayList)bansInfoObject).Count;
            int width = bandsCount * (bandWidth + bandInterval);
            vGridControl1.Width = width;
        }
        void UpdateHScroll() {
            if(!xtraScrollableControl1.HorizontalScroll.Visible) return;
            Rectangle rect = vGridControl1.ViewInfo[vGridControl1.FocusedRow].RowRect;
            if(rect.X < xtraScrollableControl1.HorizontalScroll.Value) {
                xtraScrollableControl1.HorizontalScroll.Value = rect.X;
            }
            if(xtraScrollableControl1.HorizontalScroll.Value + xtraScrollableControl1.Width < rect.Right) {
                xtraScrollableControl1.HorizontalScroll.Value = rect.Right - xtraScrollableControl1.Width;
            }
        }
        void vGridControl1_SizeChanged(object sender, EventArgs e) {
            if(FindForm() != null && FindForm().IsHandleCreated)
                BeginInvoke((Action)UpdateVGridWidth);
        }
        delegate void Action();
        void vGridControl1_FocusedRowChanged(object sender, DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e) {
            if(FindForm() == null) return;
            if(!vGridWidthIsInit) {
                UpdateVGridWidth();
                vGridWidthIsInit = true;
            }
            BeginInvoke((Action)UpdateHScroll);
        }
    }
}
