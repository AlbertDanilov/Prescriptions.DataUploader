using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfarm.Prescriptions.DataUploader.DAL.Helpers
{
    class DataHelper
    {
        private static string ConnectionSting = "Data Source=192.168.37.3;Initial Catalog=sfarm;User ID=sa;Password=*********";

        public static string GetData(string spName, string oidLpu)
        {
            string rez = string.Empty;

            try
            {
                using (var con = new SqlConnection(ConnectionSting))
                {
                    using (var cmd = new SqlCommand("", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = spName;
                        cmd.CommandTimeout = 60000;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@NsiLpuCode", oidLpu);
                        rez = (string)cmd.ExecuteScalar();
                        con.Close();
                    }
                }
            }
            catch 
            { 
                rez = string.Empty;
            }

            return rez;
        }

        public static List<PrescriptionsOwnersGetResult> LpuOidsGet() 
        {
            try 
            {
                using (var dbc = new DataClasses1DataContext())
                {
                 return dbc.PrescriptionsOwnersGet().ToList();
                }
            }
            catch 
            {
                return new List<PrescriptionsOwnersGetResult>();
            }            
        }
    }
}
