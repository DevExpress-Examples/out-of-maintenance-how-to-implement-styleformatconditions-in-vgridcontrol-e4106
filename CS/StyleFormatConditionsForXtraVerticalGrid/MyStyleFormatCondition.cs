using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraVerticalGrid.Data;
using DevExpress.Utils.Serializing;
using DevExpress.Data.Filtering.Helpers;

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
                return Controller.CreateExpressionEvaluator(Expression, true, out e);
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
