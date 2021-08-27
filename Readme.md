<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128638813/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4106)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomVGridControl.cs](./CS/StyleFormatConditionsForXtraVerticalGrid/CustomVGridControl.cs) (VB: [CustomVGridControl.vb](./VB/StyleFormatConditionsForXtraVerticalGrid/CustomVGridControl.vb))
* [Form1.cs](./CS/StyleFormatConditionsForXtraVerticalGrid/Form1.cs) (VB: [Form1.vb](./VB/StyleFormatConditionsForXtraVerticalGrid/Form1.vb))
* [MyStyleFormatCondition.cs](./CS/StyleFormatConditionsForXtraVerticalGrid/MyStyleFormatCondition.cs) (VB: [MyStyleFormatCondition.vb](./VB/StyleFormatConditionsForXtraVerticalGrid/MyStyleFormatCondition.vb))
<!-- default file list end -->
# How to implement StyleFormatConditions in VGridControl


<p>This example demonstrates how to implement StyleFormatConditions in VGridControl. The difficulty is in the fact that VGridControl doesn't implement the FormatConditions property at all, if compared to how this behavior is supported in GridControl. </p><p>So, we created a custom class inherited from VGridControl and added the FormatConditions property to it. In this example we override the RecordCellStyle event to set a new style for VGridControl’s cells, which satisfy predefined conditions.</p>

<br/>


