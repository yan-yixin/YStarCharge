using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using Aspose.Cells;

namespace YStarCharge.Common
{
    internal static class Util
    {
        public static void NoticeMessageBox(string content)
        {
            MessageBox.Show(content, "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static bool Export(DataTable dt)
        {
            //选择路径，输入文件名
            string filePath = ExportFile();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                return false;
            }

            //创建一个工作簿
            Workbook workbook = new Workbook();

            //创建一个 sheet 表
            Worksheet worksheet = workbook.Worksheets[0];

            //设置 sheet 表名称
            worksheet.Name = dt.TableName;

            Cell cell;

            Aspose.Cells.Style style = workbook.CreateStyle();
            style.HorizontalAlignment = TextAlignmentType.Center; //单元格内容的水平对齐方式文字居中
            style.Font.Name = "Arial"; //字体
            style.Font.IsBold = true; //设置粗体
            style.Font.Size = 11; //设置字体大小

            //设置列名
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                //获取第一行的每个单元格
                cell = worksheet.Cells[0, i -1];
                //设置列名
                cell.PutValue(dt.Columns[i].ColumnName);
                cell.SetStyle(style);
            }

            //跳过第一行，第一行写入了列名
            //写入数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j < dt.Columns.Count ; j++)
                {
                    cell = worksheet.Cells[i + 1, j - 1];

                    cell.PutValue(dt.Rows[i][j]);
                }
            }

            //自动列宽
            worksheet.AutoFitColumns();

            //保存至指定路径
            workbook.Save(filePath);

            return true;
        }

        public static string ExportFile()
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Title = "导出",
                Filter = "Excel File|*.xls|Excel File|*.xlsx",
            };
            if(sfd.ShowDialog() == true)
            {
                return sfd.FileName;
            }
            return "";
        }
    }
}
