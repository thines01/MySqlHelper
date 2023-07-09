using System;
using System.Collections.Generic;
using System.Linq;

namespace MySqlHelper
{
   using MySql.Data.MySqlClient;

   public partial class CMySqlHelper
   {
      public static readonly Func<MySqlCommand, IEnumerable<string>, MySqlCommand> InitParams = (cmd, lstParams) =>
      {
         lstParams.ToList().ForEach(strParam => cmd.Parameters.Add(new MySqlParameter(strParam, MySqlDbType.VarChar)));
         return cmd;
      };
   }
}