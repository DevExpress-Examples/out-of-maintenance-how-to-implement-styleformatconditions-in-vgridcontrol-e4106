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
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraVerticalGrid.Data;
using DevExpress.Utils.Serializing;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.Filtering;

namespace StyleFormatConditionsForXtraVerticalGrid {
    class MyStyleFormatConditionCollection : FormatConditionCollectionBase {
        CustomVGridControl control;
        public MyStyleFormatConditionCollection(CustomVGridControl control) {
            this.control = control;
        }

        protected internal VGridDataManager Controller {
            get {
                return control.DataManager;
            }
        }

        public override int CompareValues(object val1, object val2) {
            if (val1.Equals(val2)) return 1;
            return -1;
        }

        public override bool IsLoading { get { return control == null || control.IsLoading; } }

        protected override void OnCollectionChanged(CollectionChangeEventArgs e) {
            base.OnCollectionChanged(e);
            this.control.Refresh();
        }

    }


    class MyStyleFormatCondition : StyleFormatConditionBase {
        public MyStyleFormatCondition() {
            applyToRow = false;
        }

        protected override DevExpress.Data.DataControllerBase Controller {
            get {
                return Collection.Controller;
            }
        }

        protected override ExpressionEvaluator CreateEvaluator() {
            if (Controller != null) {
                Exception e;
                return Controller.CreateExpressionEvaluator(CriteriaOperator.Parse( Expression), true, out e);
            }
            return null;
        }

        protected override bool IsFitCore(ExpressionEvaluator evaluator, object val, object row) {
            try {
                object res = evaluator.Evaluate(row);
                if (res is bool) return (bool)res;
                return Convert.ToBoolean(res);
            }
            catch {
                return false;
            }
        }

        bool applyToRow;
        [Description("Gets or sets whether the appearance settings are to be applied to rows or individual cells."), DefaultValue(false), XtraSerializableProperty()]
        public virtual bool ApplyToRow {
            get { return applyToRow; }
            set {
                if (ApplyToRow == value) return;
                applyToRow = value;
                ItemChanged();
            }
        }

        [Browsable(false)]
        public new MyStyleFormatConditionCollection Collection {
            get { return base.Collection as MyStyleFormatConditionCollection; }
        }
    }
}
