// Developer Express Code Central Example:
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StyleFormatConditionsForXtraVerticalGrid {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
