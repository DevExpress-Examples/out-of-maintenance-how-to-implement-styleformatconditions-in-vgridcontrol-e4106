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
Imports System.Windows.Forms

Namespace StyleFormatConditionsForXtraVerticalGrid
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace
