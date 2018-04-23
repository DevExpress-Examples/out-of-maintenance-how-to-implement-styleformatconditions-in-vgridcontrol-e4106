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
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports DevExpress.XtraVerticalGrid.Data
Imports DevExpress.Utils.Serializing
Imports DevExpress.Data.Filtering.Helpers
Imports DevExpress.Data.Filtering

Namespace StyleFormatConditionsForXtraVerticalGrid
	Friend Class MyStyleFormatConditionCollection
		Inherits FormatConditionCollectionBase
		Private control As CustomVGridControl
		Public Sub New(ByVal control As CustomVGridControl)
			Me.control = control
		End Sub

		Protected Friend ReadOnly Property Controller() As VGridDataManager
			Get
				Return control.DataManager
			End Get
		End Property

		Public Overrides Function CompareValues(ByVal val1 As Object, ByVal val2 As Object) As Integer
			If val1.Equals(val2) Then
				Return 1
			End If
			Return -1
		End Function

		Public Overrides ReadOnly Property IsLoading() As Boolean
			Get
				Return control Is Nothing OrElse control.IsLoading
			End Get
		End Property

		Protected Overrides Sub OnCollectionChanged(ByVal e As CollectionChangeEventArgs)
			MyBase.OnCollectionChanged(e)
			Me.control.Refresh()
		End Sub

	End Class


	Friend Class MyStyleFormatCondition
		Inherits StyleFormatConditionBase
		Public Sub New()
			applyToRow_Renamed = False
		End Sub

		Protected Overrides ReadOnly Property Controller() As DevExpress.Data.DataControllerBase
			Get
				Return Collection.Controller
			End Get
		End Property

		Protected Overrides Function CreateEvaluator() As ExpressionEvaluator
			If Controller IsNot Nothing Then
				Dim e As Exception
				Return Controller.CreateExpressionEvaluator(CriteriaOperator.Parse(Expression), True, e)
			End If
			Return Nothing
		End Function

		Protected Overrides Function IsFitCore(ByVal evaluator As ExpressionEvaluator, ByVal val As Object, ByVal row As Object) As Boolean
			Try
				Dim res As Object = evaluator.Evaluate(row)
				If TypeOf res Is Boolean Then
					Return CBool(res)
				End If
				Return Convert.ToBoolean(res)
			Catch
				Return False
			End Try
		End Function

		Private applyToRow_Renamed As Boolean
		<Description("Gets or sets whether the appearance settings are to be applied to rows or individual cells."), DefaultValue(False), XtraSerializableProperty()> _
		Public Overridable Property ApplyToRow() As Boolean
			Get
				Return applyToRow_Renamed
			End Get
			Set(ByVal value As Boolean)
				If ApplyToRow = value Then
					Return
				End If
				applyToRow_Renamed = value
				ItemChanged()
			End Set
		End Property

		<Browsable(False)> _
		Public Shadows ReadOnly Property Collection() As MyStyleFormatConditionCollection
			Get
				Return TryCast(MyBase.Collection, MyStyleFormatConditionCollection)
			End Get
		End Property
	End Class
End Namespace
