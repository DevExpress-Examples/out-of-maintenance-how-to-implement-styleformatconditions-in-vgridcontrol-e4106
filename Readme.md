<!-- default file list -->
*Files to look at*:

* [CustomVGridControl.cs](./CS/StyleFormatConditionsForXtraVerticalGrid/CustomVGridControl.cs) (VB: [CustomVGridControl.vb](./VB/StyleFormatConditionsForXtraVerticalGrid/CustomVGridControl.vb))
* [Form1.cs](./CS/StyleFormatConditionsForXtraVerticalGrid/Form1.cs) (VB: [Form1.vb](./VB/StyleFormatConditionsForXtraVerticalGrid/Form1.vb))
* [MyStyleFormatCondition.cs](./CS/StyleFormatConditionsForXtraVerticalGrid/MyStyleFormatCondition.cs) (VB: [MyStyleFormatCondition.vb](./VB/StyleFormatConditionsForXtraVerticalGrid/MyStyleFormatCondition.vb))
<!-- default file list end -->
# How to implement StyleFormatConditions in VGridControl


<p>This example demonstrates how to implement StyleFormatConditions in VGridControl. The difficulty is in the fact that VGridControl doesn't implement the FormatConditions property at all, if compared to how this behavior is supported in GridControl. </p><p>So, we created a custom class inherited from VGridControl and added the FormatConditions property to it. In this example we override the RecordCellStyle event to set a new style for VGridControl’s cells, which satisfy predefined conditions.</p>

<br/>


