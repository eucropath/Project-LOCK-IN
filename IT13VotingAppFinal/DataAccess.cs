using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IT13VotingAppFinal
{
    public static class DataAccess
    {
        private static string ConnString => ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        public static DataTable ExecuteProcedureToDataTable(string procName, params MySqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(procName, conn))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                da.Fill(dt);
            }
            return dt;
        }
        public static int ExecuteProcedureNonQuery(string procName, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static object ExecuteProcedureScalar(string procName, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(ConnString))
            using (var cmd = new MySqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
