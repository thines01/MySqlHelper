using System;
namespace MySqlHelper
{
   public partial class CMySqlHelper
   {
      private static object DbEnsure(string strData)
      {
         if (string.IsNullOrEmpty(strData))
         {
            return DBNull.Value;
         }

         return strData;
      }
   }
}