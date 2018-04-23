﻿// Developer Express Code Central Example:
// How to implement StyleFormatConditions in VGridControl
// 
// This example demonstrates how to implement StyleFormatConditions in
// VGridControl. The difficulty is in the fact that VGridControl doesn't implement
// the FormatConditions property at all, if compared to how this behavior is
// supported in GridControl. So, we created a custom class inherited from
// VGridControl and added the FormatConditions property to it. In this example we
// override the RecordCellStyle event to set a new style for VGridControl’s cells,
// which satisfy predefined conditions.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4106

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("StyleFormatConditionsForXtraVerticalGrid")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("StyleFormatConditionsForXtraVerticalGrid")]
[assembly: AssemblyCopyright("Copyright ©  2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("63a58dce-3651-4ef9-b5ab-af0976f70a97")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
