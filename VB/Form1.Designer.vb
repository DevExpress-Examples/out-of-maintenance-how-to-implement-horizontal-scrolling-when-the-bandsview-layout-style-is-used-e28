Imports Microsoft.VisualBasic
Imports System
Namespace WindowsFormsApplication2
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.hScrollableVGrid1 = New WindowsFormsApplication2.HScrollableVGrid()
			Me.SuspendLayout()
			' 
			' hScrollableVGrid1
			' 
			Me.hScrollableVGrid1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.hScrollableVGrid1.Location = New System.Drawing.Point(0, 0)
			Me.hScrollableVGrid1.Name = "hScrollableVGrid1"
			Me.hScrollableVGrid1.Size = New System.Drawing.Size(729, 476)
			Me.hScrollableVGrid1.TabIndex = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(729, 476)
			Me.Controls.Add(Me.hScrollableVGrid1)
			Me.Name = "Form1"
			Me.Text = "XtraVerticalGrid with horizontal scrolling"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private hScrollableVGrid1 As HScrollableVGrid

	End Class
End Namespace

