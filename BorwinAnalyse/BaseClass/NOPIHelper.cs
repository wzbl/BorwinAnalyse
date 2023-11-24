using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinAnalyse.BaseClass
{
    public class NOPIHelper
    {
        /// <summary>
        /// 将Excel导入到Datatable
        /// </summary>
        /// <param name="filePath">excel路径</param>
        /// <param name="isColumnName">第一行是否是列名</param>
        /// <returns>返回datatable</returns>
        public static DataTable ExcelToDataTable(string filePath, bool isColumnName)
        {
            try
            {
                DataTable dataTable = null;
                IWorkbook workbook = null;
                ISheet sheet = null;
                int startRow = 0;
                using (FileStream fs = File.OpenRead(filePath))
                {
                    // 2007版本
                    if (filePath.IndexOf(".xlsx") > 0 || filePath.IndexOf(".XLSX") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本
                    else if (filePath.IndexOf(".xls") > 0 || filePath.IndexOf(".XLS") > 0)
                        workbook = new HSSFWorkbook(fs);
                    if (workbook != null)
                    {
                        dataTable = new DataTable();
                        for (int index = 0; index < workbook.NumberOfSheets; index++)
                        {
                            sheet = workbook.GetSheetAt(index);//遍历sheet
                            if (sheet != null)
                            {
                                int rowCount = sheet.LastRowNum;//总行数
                                if (rowCount > 0)
                                {
                                    IRow firstRow = null;
                                    int cellCount = 0;
                                    for (int i = 0; i < sheet.LastRowNum; i++)
                                    {
                                        if (sheet.GetRow(i) != null)//第一行
                                        {
                                            firstRow = sheet.GetRow(i);
                                            cellCount = firstRow.LastCellNum;//列数
                                            break;
                                        }
                                    }
                                    if (cellCount <= 2)
                                    {
                                        cellCount = rowORcolAllCount(filePath, 0, false);
                                    }
                                    cellCount = cellCount <= 2 ? 20 : cellCount;
                                    //构建datatable的列
                                    if (isColumnName)
                                    {
                                        startRow = 1;//如果第一行是列名，则从第二行开始读取
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            ICell cell = firstRow.GetCell(i);
                                            if (cell != null)
                                            {
                                                cell.SetCellType(CellType.String);
                                                if (cell.StringCellValue != null)
                                                {
                                                    DataColumn column = new DataColumn(cell.StringCellValue);

                                                    if (!dataTable.Columns.Contains("A" + i.ToString()))
                                                    {
                                                        dataTable.Columns.Add("A" + i.ToString());
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (!dataTable.Columns.Contains("A" + i.ToString()))
                                                {
                                                    dataTable.Columns.Add("A" + i.ToString());
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        startRow = sheet.FirstRowNum;
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            DataColumn column = new DataColumn("A" + i);
                                            if (!dataTable.Columns.Contains("A" + i.ToString()))
                                            {
                                                dataTable.Columns.Add(column);
                                            }
                                        }
                                    }

                                    for (int i = startRow; i <= rowCount; ++i)
                                    {
                                        IRow row = sheet.GetRow(i);
                                        if (row == null) continue; //没有数据的行默认是null　　　　　　　
                                        DataRow dataRow = dataTable.NewRow();
                                        int CellNum = row.FirstCellNum;
                                        if (CellNum < 0) { CellNum = 0; }
                                        for (int j = CellNum; j < cellCount; j++)
                                        {
                                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                                dataRow[j] = row.GetCell(j).ToString();
                                        }
                                        dataTable.Rows.Add(dataRow);
                                    }
                                }
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.tr());
                return null;
            }
        }


        /// <summary>
        /// 读取excel某个工作表的有效行数或者最大有效列数
        /// </summary>
        /// <param name="filePath">代表excel表格保存的地址</param>
        /// <param name="sheetNumber">代表将要读取的sheet表的索引位置</param>
        /// <param name="readFlag">为true代表读取的为：有效行数，为：false代表读取的为：最大有效列数</param>
        /// <returns>返回值 “不为-1” 代表读取成功，否则为读取失败</returns>
        private static int rowORcolAllCount(string filePath, int sheetNumber, bool readFlag = false)
        {
            try
            {
                int rowORcolCnt = -1;//初始化为-1
                FileStream fs = null;
                IWorkbook workbook = null;
                ISheet sheet = null;
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);
                    sheet = workbook.GetSheetAt(sheetNumber);
                    if (sheet != null)
                    {
                        if (readFlag)//如果需要读取‘有效行数’
                        {
                            rowORcolCnt = sheet.LastRowNum + 1;//有效行数(NPOI读取的有效行数不包括列头，所以需要加1)
                        }
                        else  //如果需要读取‘最大有效列数’
                        {
                            for (int rowCnt = sheet.FirstRowNum; rowCnt <= sheet.LastRowNum; rowCnt++)//迭代所有行
                            {
                                IRow row = sheet.GetRow(rowCnt);
                                if (row != null && row.LastCellNum > rowORcolCnt)
                                {
                                    rowORcolCnt = row.LastCellNum;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }
    }
}
