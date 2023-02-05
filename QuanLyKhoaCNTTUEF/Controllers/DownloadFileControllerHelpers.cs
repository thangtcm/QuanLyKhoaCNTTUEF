using System.Data;
using System.Reflection;

internal static class DownloadFileControllerHelpers
{
    public static DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new(typeof(T).Name);
        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name);
        }
        if (Props != null)
        {
            foreach (T item in items)
            {
                if (item != null)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        var value = Props[i].GetValue(item, null);
                        if (value != null)
                        {
                            //inserting property values to datatable rows
                            values[i] = value;
                        }
                    }
                    dataTable.Rows.Add(values);
                }
            }
        }
        //put a breakpoint here and check datatable
        return dataTable;
    }
}