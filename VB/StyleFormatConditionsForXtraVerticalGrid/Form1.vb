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
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraGrid

Namespace StyleFormatConditionsForXtraVerticalGrid
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			SetStyleConditionForGrid()

			customVGridControl1.DataSource = CreateDataSource()
			gridControl1.DataSource = CreateDataSource()

		End Sub

		Private Sub SetStyleConditionForGrid()
			Dim condition1 As New StyleFormatCondition()
			condition1.Appearance.BackColor = Color.SeaShell
			condition1.Appearance.Options.UseBackColor = True
			condition1.Condition = FormatConditionEnum.Expression
			condition1.Expression = "[OrderCost] < 1000 AND [OrderCost] > 300"
			condition1.ApplyToRow = False
			gridView1.FormatConditions.Add(condition1)

			Dim conditionForMyControl As New MyStyleFormatCondition()
			conditionForMyControl.Appearance.BackColor = Color.SeaShell
			conditionForMyControl.Appearance.Options.UseBackColor = True
			conditionForMyControl.ApplyToRow = False
			conditionForMyControl.Condition = FormatConditionEnum.Expression
			conditionForMyControl.Expression = "[OrderCost] < 1000 AND [OrderCost] > 300"
			customVGridControl1.FormatConditions.Add(conditionForMyControl)

		End Sub



		Private Function CreateDataSource() As DataTable
			Dim dataTable As New DataTable()
			dataTable.Columns.Add("Name", GetType(String))
			dataTable.Columns.Add("Order Date", GetType(DateTime))
			dataTable.Columns.Add("OrderCost", GetType(Double))
			dataTable.Rows.Add(New Object() { "John Smith", " 01 / 01 / 2010", 102 })
			dataTable.Rows.Add(New Object() { "Ivanov", "01/01/2011", 2000 })
			dataTable.Rows.Add(New Object() { "Petrov", "01 / 05 / 2011", 345 })
			dataTable.Rows.Add(New Object() { "John Smith", " 04 / 01 / 2010", 102.78 })
			dataTable.Rows.Add(New Object() { "Ivanov", "01/11/2011", 450.78 })
			Return dataTable

		End Function

	End Class
End Namespace
