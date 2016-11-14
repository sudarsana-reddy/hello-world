    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DataTableBuilder
    {
        public static class DataTableUtilities
        {
            public static DataTable GenerateDataTable()
            {
                List<string> columns = new List<string> { "AccountType", "B", "C", "Balance" };
                List<string> data = new List<string> { 
                "AccountType","B","CRD","DDL","SAL","4","5","6","C","Balance","7","8","9","10","11","12"
                };

                DataTable dt = new DataTable();
                columns.ForEach(x =>
                {
                    dt.Columns.Add(x);
                    data.Remove(x);
                });

                int rowCount = data.Count / columns.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dt.NewRow();
                    for (int colIndex = 0; colIndex < columns.Count; colIndex++)
                    {
                        row[colIndex] = data[i + colIndex * rowCount];
                    }

                    dt.Rows.Add(row);
                }

                return dt;
            }

            public static int GetRowIndexByColumnValue(this DataTable dt, string columnName, string value, bool isFirst=true)
            {
                int rowNum = -1;
                var dataRows = dt.GetRowByColumnValue(columnName, value);
                if (isFirst)
                    rowNum = dt.Rows.IndexOf(dataRows.First());
                else
                    rowNum = dt.Rows.IndexOf(dataRows.Last());

                return rowNum;
            }

            public static List<string> GetValuesByColumn(this DataTable dt, string columnName)
            {
                var columnValues = dt.AsEnumerable()
                                  .Select(row => row.Field<string>(columnName))
                                  .ToList();

                return columnValues;
            }

            public static DataRow[] GetRowByColumnValue(this DataTable dt, string columnName, string value)
            {
                string filterExpression = string.Format("{0} = '{1}'", columnName, value);
                DataRow[] dataRows = dt.Select(filterExpression);

                return dataRows;
            }
        }
    }
