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
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraGrid;
using System.ComponentModel;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraVerticalGrid.Data;

namespace StyleFormatConditionsForXtraVerticalGrid {
    class CustomVGridControl:VGridControl {
        MyStyleFormatConditionCollection formatConditions;
        public CustomVGridControl() {
            this.formatConditions = new MyStyleFormatConditionCollection(this);
        }

        public VGridDataManager DataManager { get { return base.DataManager; } }

        private void FillCellCollectionStyle() {
            for(int i=0; i < this.RecordCount; i++)
                cellStyleCollection.Add(i,false);
        }
       
        Dictionary<int, bool> cellStyleCollection;
        protected override void RaiseRecordCellStyle(DevExpress.XtraVerticalGrid.Events.GetCustomRowCellStyleEventArgs e) {
            if (cellStyleCollection == null) {
                cellStyleCollection = new Dictionary<int, bool>();
                FillCellCollectionStyle();
            }
            int conditionsCount = FormatConditions.Count;
            if (conditionsCount == 0) return;

            for (int n = 0; n < conditionsCount; n++) {
                MyStyleFormatCondition cond = FormatConditions[n] as MyStyleFormatCondition;
                bool isSatisfyCondition = CalcCondition(e.Row, e.RecordIndex, cond);

                if (isSatisfyCondition)
                    cellStyleCollection[e.RecordIndex] = isSatisfyCondition;

      
                if (cond.ApplyToRow) {
                    if (cellStyleCollection[e.RecordIndex]) {
                        e.Appearance = cond.Appearance;
                    }

                }
                else if (!cond.ApplyToRow && isSatisfyCondition) {
                    e.Appearance = cond.Appearance;
                }

            }
        }


        private bool CalcCondition(BaseRow row, int recordIndex, MyStyleFormatCondition cond) {
            if (!cond.IsValid) return false;

            return cond.CheckValue(row, GetCellValue(row, recordIndex), recordIndex);
        }


        public MyStyleFormatConditionCollection FormatConditions { get { return formatConditions; } }
   
    }
   
}
