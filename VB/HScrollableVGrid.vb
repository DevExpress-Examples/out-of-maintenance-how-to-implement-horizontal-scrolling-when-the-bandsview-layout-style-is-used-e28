Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Windows
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraVerticalGrid
Imports System.Drawing

Namespace WindowsFormsApplication2
	Partial Public Class HScrollableVGrid
		Inherits UserControl
		Private Shared scrollStrategyField As FieldInfo = GetType(VGridScroller).GetField("scrollStrategy", BindingFlags.NonPublic Or BindingFlags.Instance)
		Private Shared bandWidthProperty As PropertyInfo = GetType(BandsScrollStrategy).GetProperty("BandWidth", BindingFlags.NonPublic Or BindingFlags.Instance)
		Private Shared bandIntervalProperty As PropertyInfo = GetType(BandsScrollStrategy).GetProperty("BandInterval", BindingFlags.NonPublic Or BindingFlags.Instance)
		Private Shared bandsInfoField As FieldInfo = GetType(BandsScrollStrategy).GetField("BandsInfo", BindingFlags.NonPublic Or BindingFlags.Instance)

		Private vGridWidthIsInit As Boolean = False

		Public Sub New()
			InitializeComponent()
			UpdateVGridWidth()
		End Sub
		Public ReadOnly Property VGridControl() As VGridControl
			Get
				Return vGridControl1
			End Get
		End Property
		Private Sub UpdateVGridWidth()
			Dim scroller As VGridScroller = vGridControl1.ViewInfo.Scroller
			Dim scrollStrategy As BandsScrollStrategy = CType(scrollStrategyField.GetValue(scroller), BandsScrollStrategy)
			Dim bandWidth As Integer = CInt(Fix(bandWidthProperty.GetValue(scrollStrategy, Nothing)))
			Dim bandInterval As Integer = CInt(Fix(bandIntervalProperty.GetValue(scrollStrategy, Nothing)))
			Dim bandsCount As Integer = CInt(Fix((CType(bandsInfoField.GetValue(scrollStrategy), ArrayList)).Count))
			Dim width As Integer = bandsCount * (bandWidth + bandInterval)
			vGridControl1.Width = width
		End Sub
		Private Sub UpdateHScroll()
			If (Not xtraScrollableControl1.HorizontalScroll.Visible) Then
				Return
			End If
			Dim rect As Rectangle = vGridControl1.ViewInfo(vGridControl1.FocusedRow).RowRect
			If rect.X < xtraScrollableControl1.HorizontalScroll.Value Then
				xtraScrollableControl1.HorizontalScroll.Value = rect.X
			End If
			If xtraScrollableControl1.HorizontalScroll.Value + xtraScrollableControl1.Width < rect.Right Then
				xtraScrollableControl1.HorizontalScroll.Value = rect.Right - xtraScrollableControl1.Width
			End If
		End Sub
		Private Sub vGridControl1_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles vGridControl1.SizeChanged
			UpdateVGridWidth()
		End Sub
		Private Delegate Sub Action()
		Private Sub vGridControl1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs) Handles vGridControl1.FocusedRowChanged
			If FindForm() Is Nothing Then
				Return
			End If
			If (Not vGridWidthIsInit) Then
				UpdateVGridWidth()
				vGridWidthIsInit = True
			End If
			BeginInvoke(CType(AddressOf UpdateHScroll, Action))
		End Sub
	End Class
End Namespace
