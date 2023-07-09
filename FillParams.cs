using System;
using System.Collections.Generic;
using System.Linq;

namespace MySqlHelper
{
   using MySql.Data.MySqlClient;

   public partial class CMySqlHelper
   {
      public static readonly Func<MySqlCommand, Dictionary<string, string>, MySqlCommand> FillParams = (cmd, map) =>
      {
         map.ToList().ForEach(kvp => cmd.Parameters[kvp.Key].Value = DbEnsure(kvp.Value));
         return cmd;
      };
   }
}
