using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridExtension
{
    public class IntegerGridColumn : DataGridViewColumn
    {
        public IntegerGridColumn() : base(new IntegerGridCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(IntegerGridCell)))
                    throw new InvalidCastException("Debe ser del tipo IntegerGridCell");
                base.CellTemplate = value;
            }
        }
        public class IntegerGridCell : DataGridViewTextBoxCell
        {

            public IntegerGridCell() : base() { }

            public override Type ValueType
            {
                get { return typeof(Int32); }
            }

            public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                Control ctl = DataGridView.EditingControl;
                ctl.KeyPress += new KeyPressEventHandler(IntegerGridCell_KeyPress);
            }

            private void IntegerGridCell_KeyPress(object sender, KeyPressEventArgs e)
            {
                DataGridViewCell currentCell = ((IDataGridViewEditingControl)sender).EditingControlDataGridView.CurrentCell;
                if (currentCell is IntegerGridCell)
                    e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }





    }
}
