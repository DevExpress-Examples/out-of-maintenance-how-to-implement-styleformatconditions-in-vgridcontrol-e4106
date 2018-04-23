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
Imports System.Linq
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraGrid
Imports System.ComponentModel
Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraVerticalGrid.Data

Namespace StyleFormatConditionsForXtraVerticalGrid
	Friend Class CustomVGridControl
		Inherits VGridControl
		Private formatConditions_Renamed As MyStyleFormatConditionCollection
		Public Sub New()
			Me.formatConditions_Renamed = New MyStyleFormatConditionCollection(Me)
		End Sub

		Public ReadOnly Property DataManager() As VGridDataManager
			Get
				Return MyBase.DataManager
			End Get
		End Property

		Private Sub FillCellCollectionStyle()
			For i As Integer = 0 To Me.RecordCount - 1
				cellStyleCollection.Add(i,False)
			Next i
		End Sub

		Private cellStyleCollection As Dictionary(Of Integer, Boolean)
		Protected Overrides Sub RaiseRecordCellStyle(ByVal e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellStyleEventArgs)
			If cellStyleCollection Is Nothing Then
				cellStyleCollection = New Dictionary(Of Integer, Boolean)()
				FillCellCollectionStyle()
			End If
			Dim conditionsCount As Integer = FormatConditions.Count
			If conditionsCount = 0 Then
				Return
			End If

			For n As Integer = 0 To conditionsCount - 1
				Dim cond As MyStyleFormatCondition = TryCast(FormatConditions(n), MyStyleFormatCondition)
				Dim isSatisfyCondition As Boolean = CalcCondition(e.Row, e.RecordIndex, cond)

				If isSatisfyCondition Then
					cellStyleCollection(e.RecordIndex) = isSatisfyCondition
				End If


				If cond.ApplyToRow Then
					If cellStyleCollection(e.RecordIndex) Then
						e.Appearance = cond.Appearance
					End If

				ElseIf (Not cond.ApplyToRow) AndAlso isSatisfyCondition Then
					e.Appearance = cond.Appearance
				End If

			Next n
		End Sub


		Private Function CalcCondition(ByVal row As BaseRow, ByVal recordIndex As Integer, ByVal cond As MyStyleFormatCondition) As Boolean
			If (Not cond.IsValid) Then
				Return False
			End If

			Return cond.CheckValue(row, GetCellValue(row, recordIndex), recordIndex)
		End Function


		Public ReadOnly Property FormatConditions() As MyStyleFormatConditionCollection
			Get
				Return formatConditions_Renamed
			End Get
		End Property

	End Class

End Namespace
