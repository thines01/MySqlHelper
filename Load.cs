using System;
using System.Collections.Generic;
using System.Data;

namespace MySqlHelper
{
   using IDbMaster;
   using MySql.Data.MySqlClient;

   public partial class CMySqlHelper
   {
      public static bool Load<T>(List<T> master, string strConnection, string strSelectSQL, Action<List<T>, IDataReader> DoAdd, ref string strError)
      {
         bool blnRetVal = true;

         try
         {
            using (MySqlConnection conn = new MySqlConnection(strConnection))
            {
               conn.Open();

               using (MySqlDataReader rdr = (new MySqlCommand(strSelectSQL, conn)).ExecuteReader())
               {
                  while (rdr.Read())
                  {
                     DoAdd(master, rdr);
                  }
                  //
                  rdr.Close();
               }
               //
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