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
