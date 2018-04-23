' Developer Express Code Central Example:
' How to implement StyleFormatConditions in VGridControl
' 
' This example demonstrates how to implement StyleFormatConditions in
' VGridControl. The difficulty is in the fact that VGridControl doesn't implement
' the FormatConditions property at all, if compared to how this behavior is
' supported in GridControl. So, we created a custom class inherited from
' VGridControl and added the FormatConditions property to it. In this example we
' override the RecordCellStyle event to set a new style for VGridControl’s cells,
' which satisfy predefined conditions.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4106


Imports Microsoft.VisualBasic
Imports System
Namespace StyleFormatConditionsForXtraVerticalGrid
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
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.customVGridControl1 = New StyleFormatConditionsForXtraVerticalGrid.CustomVGridControl()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.customVGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.gridControl1.Location = New System.Drawing.Point(0, 214)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(581, 239)
			Me.gridControl1.TabIndex = 4
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' customVGridControl1
			' 
			Me.customVGridControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.customVGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.customVGridControl1.Name = "customVGridControl1"
			Me.customVGridControl1.Size = New System.Drawing.Size(581, 200)
			Me.customVGridControl1.TabIndex = 5
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(581, 453)
			Me.Controls.Add(Me.customVGridControl1)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "implement StyleFormatConditions in VGridControl"
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.customVGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private customVGridControl1 As CustomVGridControl
	End Class
End Namespace

