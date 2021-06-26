using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
public static class IEnumerableExtensions
{
    public static DataTable CopyAnonymusToDataTable<T>(this IEnumerable<T> info)
    {
        var type = typeof(T);
        if (type.Equals(typeof(DataRow)))
            return (info as IEnumerable<DataRow>).CopyToDataTable();
        DataTable dt = new DataTable();
        DataRow r;
        type.GetProperties().ToList().ForEach(a => dt.Columns.Add(a.Name));
        try
        {


            foreach (var c in info)
            {
                r = dt.NewRow();
                c.GetType().GetProperties().ToList().ForEach(a => r[a.Name] = a.GetValue(c, null));
                dt.Rows.Add(r);
            }
        }
        catch (Exception) { }
        return dt;
    }
}
