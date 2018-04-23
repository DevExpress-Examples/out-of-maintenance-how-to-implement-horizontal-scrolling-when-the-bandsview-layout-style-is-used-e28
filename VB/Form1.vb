Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Forms

Namespace WindowsFormsApplication2
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace
