using NPOI.POIFS.NIO;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK.Dataview
{
    [ToolboxItem(true)]
    public class UIDataGridView : DataGridView
    {
        [Category("UILibrary"), Description("按钮点击事件")]
        public event DataViewBtnClicked ButtonClicked;

        [Category("UILibrary"), Description("选中事件")]
        public event OnSelectIndexChange SelectIndexChange;

  

        public UIDataGridView() : base()
        {
      
            base.DoubleBuffered = true;

      


            //支持自定义标题行风格
            EnableHeadersVisualStyles = false;

            //标题行风格
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //标题行行高，与OnColumnAdded事件配合
            ColumnHeadersHeight = 25;

            //数据行行高
            RowTemplate.Height = 32;
            RowTemplate.MinimumHeight = 10;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            //设置奇偶数行颜色
            StripeEvenColor = Color.White;
            StripeOddColor = Color.LightBlue;

            VerticalScrollBar.ValueChanged += VerticalScrollBar_ValueChanged;
            HorizontalScrollBar.ValueChanged += HorizontalScrollBar_ValueChanged;
            VerticalScrollBar.VisibleChanged += VerticalScrollBar_VisibleChanged;
            HorizontalScrollBar.VisibleChanged += HorizontalScrollBar_VisibleChanged;
        }

        private void HorizontalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            SetScrollInfo();
        }

        private void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            SetScrollInfo();
        }

        public void Init()
        {
            //自动生成行
            AutoGenerateColumns = false;

            //列占满行
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //禁止调整数据行行高
            AllowUserToResizeRows = false;

            //允许调整标题行行宽
            AllowUserToResizeColumns = true;

            //禁用最后一行空白，自动新增行
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;

            //不显示表格线
            CellBorderStyle = DataGridViewCellBorderStyle.None;

            //禁止行多选
            MultiSelect = false;

            //不显示数据行标题
            RowHeadersVisible = false;

            //禁止只读
            //ReadOnly = false;

            //行选
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void VerticalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            
        }

    

        private void HorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void HBar_ValueChanged(object sender, EventArgs e)
        {
       
        }

        public void SetScrollInfo()
        {
         

            if (RowCount > DisplayedRowCount(false))
            {
              
            }
            else
            {
              
            }

            if (HorizontalScrollBar.Visible)
            {
              
            }
            else
            {
             
            }

       
        }

        private int VisibleColumnCount()
        {
            int cnt = 0;
            foreach (DataGridViewColumn column in Columns)
            {
                if (column.Visible) cnt++;
            }
            return cnt;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

        }
   
        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            SetScrollInfo();
        }

        protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
        {
            base.OnRowsRemoved(e);
            SetScrollInfo();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetScrollInfo();
        }



        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);

            //设置可调整标题行行高
            if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            }
        }

   

   

        [DefaultValue(typeof(Color), "White")]
        [Description("偶数行显示颜色"), Category("UILibrary")]
        public Color StripeEvenColor
        {
            get => RowsDefaultCellStyle.BackColor;
            set
            {
                RowsDefaultCellStyle.BackColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "235, 243, 255")]
        [Description("奇数行显示颜色"), Category("UILibrary")]
        public Color StripeOddColor
        {
            get => AlternatingRowsDefaultCellStyle.BackColor;
            set
            {
                AlternatingRowsDefaultCellStyle.BackColor = value;
                Invalidate();
            }
        }



        /// <summary>
        /// 自定义主题风格
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置可以自定义主题风格"), Category("UILibrary")]
        public bool StyleCustomMode { get; set; }



        /// <summary>
        /// Tag字符串
        /// </summary>
        [DefaultValue(null)]
        [Description("获取或设置包含有关控件的数据的对象字符串"), Category("UILibrary")]
        public string TagString { get; set; }

  

        /// <summary>
        /// 是否显示表格线
        /// </summary>
        [Description("是否显示表格线"), Category("UILibrary")]
        [DefaultValue(false)]
        public bool ShowGridLine
        {
            get => CellBorderStyle == DataGridViewCellBorderStyle.Single;
            set => CellBorderStyle = value ? DataGridViewCellBorderStyle.Single : DataGridViewCellBorderStyle.None;
        }

        private Color _rectColor = Color.Blue;

        [DefaultValue(typeof(Color), "80, 160, 255")]
        [Description("边框颜色"), Category("UILibrary")]
        public Color RectColor
        {
            get => _rectColor;
            set
            {
                if (_rectColor != value)
                {
                    _rectColor = value;
                    Invalidate();
                }
            }
        }

        private int selectedIndex = -1;
        private SolidBrush backColorBrush;

        [Browsable(false)]
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (Rows.Count == 0)
                {
                    selectedIndex = -1;
                    return;
                }

                if (value >= 0 && value < Rows.Count)
                {
                    Rows[value].Selected = true;
                    selectedIndex = value;
                    FirstDisplayedScrollingRowIndex = value;
                    SelectIndexChange?.Invoke(this, value);
                }
                else
                {
                    selectedIndex = -1;
                }
            }
        }
        /// <summary>
        /// 触发DataGridViewColumnEx中的按钮点击事件
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="value"></param>
        internal void OnButtonClicked(int columnIndex, int rowIndex, object value)
        {
            this.OnCellButtonClicked(columnIndex, rowIndex, value);
        }

        protected void OnCellButtonClicked(int columnIndex, int rowIndex, object value)
        {
            this.ButtonClicked?.Invoke(this, new DataGridViewEventHandlers(columnIndex, rowIndex, value));
        }
        /// <summary>
        /// SwitchBtn的单元格改变事件
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param>
        public void OnSwtichlCheckedChange(int columnIndex, int rowIndex, bool value)
        {
            DataGridViewBtnCell cellEx;
            //foreach (DataGridViewRow row in this.Rows)
            //{
            cellEx = this.Rows[rowIndex].Cells[columnIndex] as DataGridViewBtnCell;
            if (cellEx == null) return;
            cellEx.Active = value;
            cellEx.DataGridView.Invalidate();
            //}
        }

        public bool GetSwState(int columnIndex, int rowIndex)
        {
            DataGridViewBtnCell cellEx;
            cellEx = this.Rows[rowIndex].Cells[columnIndex] as DataGridViewBtnCell;
            if (cellEx == null) return false;
            return cellEx.Active;
        }
        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            SetScrollInfo();
            selectedIndex = -1;
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            base.OnCellClick(e);

            if (e.RowIndex >= 0 && selectedIndex != e.RowIndex)
            {
                selectedIndex = e.RowIndex;
                SelectIndexChange?.Invoke(this, e.RowIndex);
            }
        }

        protected override void OnGridColorChanged(EventArgs e)
        {
            base.OnGridColorChanged(e);
        }

        protected override void OnDefaultCellStyleChanged(EventArgs e)
        {
            base.OnDefaultCellStyleChanged(e);
        }
        protected override void OnColumnDefaultCellStyleChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnDefaultCellStyleChanged(e);
        }

        public DataGridViewColumn AddColumn(string columnName, string dataPropertyName, int fillWeight = 100, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleCenter, bool readOnly = true)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = columnName;
            column.DataPropertyName = dataPropertyName;
            column.Name = columnName;
            column.ReadOnly = readOnly;
            column.FillWeight = fillWeight;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            column.DefaultCellStyle.Alignment = alignment;
            Columns.Add(column);
            return column;
        }

        public DataGridViewColumn AddCheckBoxColumn(string columnName, string dataPropertyName, int fillWeight = 100, bool readOnly = true)
        {
            DataGridViewColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = columnName;
            column.DataPropertyName = dataPropertyName;
            column.Name = columnName;
            column.ReadOnly = readOnly;
            column.FillWeight = fillWeight;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Columns.Add(column);
            return column;
        }

        public DataGridViewColumn AddButtonColumn(string columnName, string dataPropertyName, int fillWeight = 100, bool readOnly = true)
        {
            DataGridViewColumn column = new DataGridViewButtonColumn();
            column.HeaderText = columnName;
            column.DataPropertyName = dataPropertyName;
            column.Name = columnName;
            column.ReadOnly = readOnly;
            column.FillWeight = fillWeight;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Columns.Add(column);
            return column;
        }

        public void ClearRows()
        {
            if (DataSource != null)
            {
                DataSource = null;
            }

            Rows.Clear();
        }

        public void ClearColumns()
        {
            Columns.Clear();
        }

        public void ClearAll()
        {
            ClearRows();
            ClearColumns();
        }

        // public void AddRow(params object[] values)
        // {
        //     Rows.Add(values);
        // }
    }

    public static class UIDataGridViewHelper
    {
        public static DataGridViewColumn SetFixedMode(this DataGridViewColumn column, int width)
        {
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.Width = width;
            return column;
        }

        public static DataGridViewColumn SetSortMode(this DataGridViewColumn column, DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.Automatic)
        {
            column.SortMode = sortMode;
            return column;
        }
    }
}
