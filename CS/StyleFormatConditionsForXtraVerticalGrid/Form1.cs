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
