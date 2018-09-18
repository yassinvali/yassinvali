using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attitude.Shared.Extensions
{
    public class ExcellMaker
    {
        protected string rout;

        public int MaxRowCountForExcellReport = 10000;

        public string Create(DataTable dataToExcell, string title)
        {
            StringBuilder myout = new StringBuilder();

            string strColumnsCount = dataToExcell.Columns.Count.ToString(CultureInfo.InvariantCulture);
            int ColumnsCount = dataToExcell.Columns.Count;
            int RowCount = dataToExcell.Rows.Count + 1; //بخاطر سطر عنوان، یکی اضافه شد


            myout.Append("<?xml version=\"1.0\"?>");
            myout.Append("<?mso-application progid=\"Excel.Sheet\"?>");
            myout.AppendLine();
            myout.Append("<Workbook");
            myout.AppendLine();
            myout.Append("xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            myout.AppendLine();
            myout.Append("xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            myout.AppendLine();
            myout.Append("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
            myout.AppendLine();
            myout.Append("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            myout.AppendLine();
            myout.Append("xmlns:html=\"http://www.w3.org/TR/REC-html40\">");
            myout.AppendLine();
            myout.Append("<Worksheet ss:Name=\"Sheet1\" ss:RightToLeft=\"1\">");
            myout.AppendLine();

            myout.Append(
                string.Format("<Table ss:ExpandedColumnCount=\"{0}\" ss:ExpandedRowCount=\"{1}\" x:FullColumns=\"1\" x:FullRows=\"1\">",
                ColumnsCount.ToString(CultureInfo.InvariantCulture),
                RowCount.ToString(CultureInfo.InvariantCulture))
                        );
            myout.AppendLine();


            //col width
            for (int i = 0; i < ColumnsCount; i++)
            {
                myout.Append("<Column ss:Width=\"150\"/>");
                myout.AppendLine();
            }

            //Add title          
            myout.Append("<Row ss:AutoFitHeight=\"0\" ss:Height=\"20\"><Cell ss:MergeAcross=\"" + (ColumnsCount - 1) + "\" ><Data ss:Type=\"String\">");
            myout.Append(title);
            myout.Append("</Data></Cell></Row>");
            myout.AppendLine();


            //data Rows
            for (int i = 0; i < RowCount - 1; i++)
            {
                myout.Append("<Row>");
                myout.AppendLine();


                for (int j = 0; j < ColumnsCount; j++)
                {
                    string typeName = string.Empty;
                    string rowContent = dataToExcell.Rows[i][j].ToString();

                    if (dataToExcell.Rows[i][j].GetType() == typeof(Double)
                        || dataToExcell.Rows[i][j].GetType() == typeof(float)
                        || dataToExcell.Rows[i][j].GetType() == typeof(Int16)
                        || dataToExcell.Rows[i][j].GetType() == typeof(Int32)
                        || dataToExcell.Rows[i][j].GetType() == typeof(Int64)
                        )
                        typeName = "Number";
                    else
                        typeName = "String";

                    myout.Append("<Cell ><Data ss:Type=\"" + typeName + "\">" +
                    dataToExcell.Rows[i][j] + "</Data></Cell>");
                }


                myout.Append("</Row>");
                myout.AppendLine();
            }

            myout.Append("</Table>");
            myout.AppendLine();
            myout.Append("<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\" >");
            myout.AppendLine();
            myout.Append("<Selected />");
            myout.AppendLine();
            myout.Append("<ProtectObjects>False</ProtectObjects>");
            myout.AppendLine();
            myout.Append("<ProtectScenarios>False</ProtectScenarios>");
            myout.AppendLine();
            myout.Append("</WorksheetOptions>");
            myout.AppendLine();
            myout.Append("</Worksheet>");
            myout.AppendLine();
            myout.Append("</Workbook>");
            myout.AppendLine();


            return myout.ToString();

        }
    }
}
