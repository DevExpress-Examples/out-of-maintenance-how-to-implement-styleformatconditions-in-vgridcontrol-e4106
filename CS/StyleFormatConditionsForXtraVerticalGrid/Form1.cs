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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace StyleFormatConditionsForXtraVerticalGrid {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            SetStyleConditionForGrid();

            customVGridControl1.DataSource = CreateDataSource();
            gridControl1.DataSource = CreateDataSource();

        }

        private void SetStyleConditionForGrid() {
            StyleFormatCondition condition1 = new StyleFormatCondition();
            condition1.Appearance.BackColor = Color.SeaShell;
            condition1.Appearance.Options.UseBackColor = true;
            condition1.Condition = FormatConditionEnum.Expression;
            condition1.Expression = "[OrderCost] < 1000 AND [OrderCost] > 300";
            condition1.ApplyToRow = false;
            gridView1.FormatConditions.Add(condition1);

            MyStyleFormatCondition conditionForMyControl = new MyStyleFormatCondition();
            conditionForMyControl.Appearance.BackColor = Color.SeaShell;
            conditionForMyControl.Appearance.Options.UseBackColor = true;
            conditionForMyControl.ApplyToRow = false;
            conditionForMyControl.Condition = FormatConditionEnum.Expression;
            conditionForMyControl.Expression = "[OrderCost] < 1000 AND [OrderCost] > 300";
            customVGridControl1.FormatConditions.Add(conditionForMyControl);
            
        }



        private DataTable CreateDataSource() {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Order Date", typeof(DateTime));
            dataTable.Columns.Add("OrderCost", typeof(double));
            dataTable.Rows.Add(new object[] { "John Smith", " 01 / 01 / 2010", 102 });
            dataTable.Rows.Add(new object[] { "Ivanov", "01/01/2011", 2000 });
            dataTable.Rows.Add(new object[] { "Petrov", "01 / 05 / 2011", 345 });
            dataTable.Rows.Add(new object[] { "John Smith", " 04 / 01 / 2010", 102.78 });
            dataTable.Rows.Add(new object[] { "Ivanov", "01/11/2011", 450.78 });
            return dataTable;

        }

    }
}
