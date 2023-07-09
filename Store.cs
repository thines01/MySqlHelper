using System;
using System.Collections.Generic;

namespace MySqlHelper
{
   using IDbMaster;
   using MySql.Data.MySqlClient;

   public partial class CMySqlHelper
   {
      public static bool Store<T>(List<T> master, string strInsertSQL, string strDeleteSQL, List<string> lst_strParams, string strConnection, ref string strError)
      {
         bool blnRetVal = true;
         string strSQL = strInsertSQL;
         try
         {
            using (MySqlConnection conn = new MySqlConnection(strConnection))
            {
               conn.Open();
               MySqlTransaction trans = conn.BeginTransaction();
               new MySqlCommand(strDeleteSQL, conn, trans).ExecuteNonQuery();
               MySqlCommand cmd = CMySqlHelper.InitParams(new MySqlCommand(strSQL, conn, trans), lst_strParams);
               master.ForEach(obj => CMySqlHelper.FillParams(cmd, CMySqlHelper.GetObjToMap(obj, lst_strParams, "\t")).ExecuteNonQuery());
               trans.Commit();
               conn.Close();
            }
         }
         catch (Exception exc)
         {
            blnRetVal = false;
            strError = exc.Message;
         }

         return blnRetVal;
      }
   }
}