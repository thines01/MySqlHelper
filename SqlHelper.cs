using System;
using System.Collections.Generic;
using System.Linq;

namespace MySqlHelper
{
   public partial class CMySqlHelper
   {
      private static readonly Func<List<string>, string> _colsWithoutParams = (lst) => string.Join(",", lst.Select(s => s.Replace("?p", "")).ToArray());
      private static readonly Func<List<string>, string> _colsWithParams = (lst) => string.Join(",", lst.ToArray());

      public static readonly Func<string, string> GetDeleteSql = (strTable) =>
         string.Format("DELETE FROM {0}", strTable);

      public static readonly Func<string, List<string>, string> GetSelectSql = (strTable, lst_strCols) =>
         string.Format("SELECT {0} FROM {1}", _colsWithoutParams(lst_strCols), strTable);

      public static readonly Func<string, List<string>, string> GetInsertSql = (strTable, lst_strCols) =>
         string.Format("INSERT INTO {0} ({1}) VALUES({2})", strTable,
         _colsWithoutParams(lst_strCols),
         _colsWithParams(lst_strCols));

      protected string _strTableName { get; set; }
      protected string _strDeleteSQL { get; set; }
      protected string _strSelectSQL { get; set; }
      protected string _strInsertSQL { get; set; }

      public CMySqlHelper(string strTableName, List<string> lst_strColumns)
      {
         _strTableName = strTableName;
         _strDeleteSQL = GetDeleteSql(strTableName);
         _strSelectSQL = GetSelectSql(strTableName, lst_strColumns);
         _strInsertSQL = GetInsertSql(strTableName, lst_strColumns);
      }
   }
}