using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Dataview
{
    public class DataGridViewEventHandlers : EventArgs
    {
        public int ColumnIndex { get; set; }

        public int RowIndex { get; set; }

        public object Value { get; set; }

        public DataGridViewEventHandlers(int columnIndex, int rowIndex, object value)
        {
            this.ColumnIndex = columnIndex;
            this.RowIndex = rowIndex;
            this.Value = value;
        }
    }
    /// <summary>
    /// DataGridViewButtonColumnEx按钮点击事件委托 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataViewBtnClicked(object sender, DataGridViewEventHandlers e);
    public delegate void OnSelectIndexChange(object sender, int rowIndex);
}
