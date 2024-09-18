using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Messaging;
using static Dapper.SqlMapper;
namespace MassAutoGarage.DBContext
{
    public class DBHelperDapper
    {
        private static string connectionString = string.Empty;
        public static string connection()
        {
            try
            {
                return connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*getting details fro datatbase list*/
        public static List<TClass> DAGetDetailsInList<TClass>(string _qry)
        {
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    IList<TClass> myList = SqlMapper.Query<TClass>(con, _qry).ToList();
                    return myList.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static TClass DAGetDetails<TClass>(string _qry)
        {
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    TClass myList = SqlMapper.Query<TClass>(con, _qry).FirstOrDefault();
                    return myList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static int DAAdd<T>(string Procname, T param)
        {
            int _iresult = 0;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    _iresult = con.Execute(Procname, param, commandType: System.Data.CommandType.StoredProcedure);
                    return _iresult;
                }
                catch (Exception)
                {
                    return _iresult;
                }
            }
        }

        public static int DAAdd(string Procname, DynamicParameters param)
        {
            int _iresult = 0;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    _iresult = con.Execute(Procname, param, commandType: System.Data.CommandType.StoredProcedure);
                    return _iresult;
                }
                catch (Exception)
                {
                    return _iresult;
                }
            }
        }

        public static TClass DAAddAndReturnModel<TClass>(string _procame, DynamicParameters param)
        {
            TClass _objMOdel;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    using (SqlConnection objConnection = new SqlConnection(connection()))
                    {
                        _objMOdel = SqlMapper.Query<TClass>(objConnection, _procame, param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    }
                    return _objMOdel;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static List<T> DAAddAndReturnModelList<T>(string spName, DynamicParameters p)
        {
            List<T> recordList = new List<T>();
            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                recordList = SqlMapper.Query<T>(objConnection, spName, p, commandType: System.Data.CommandType.StoredProcedure).ToList();
                objConnection.Close();
            }
            return recordList;
        }

        public static DataSet ExecuteQuery(string commandText, params SqlParameter[] parameters)
        {
            using (SqlConnection connection1 = new SqlConnection(connection()))
            using (var command = new SqlCommand(commandText, connection1))
            {
                DataSet ds = new DataSet();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection1.Close();
                return ds;
            }
        }

        public static DataTable GraphDataForOrderAmount(string commandText, params SqlParameter[] parameters)
        {
            DataTable ds = new DataTable();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    connection.Close();
                }
            }
            catch (Exception)
            {
            }
            return ds;
        }

        public static DataTable GraphDataForConsultation(string commandText, params SqlParameter[] parameters)
        {
            DataTable ds = new DataTable();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    connection.Close();
                }
            }
            catch (Exception)
            {
            }
            return ds;
        }

        //public static GridReader ReturnMultipleList(string spName, DynamicParameters p)
        //{
        //    try
        //    {
        //        GridReader reader;
        //        using (SqlConnection objConnection = new SqlConnection(connection()))
        //        {
        //            objConnection.Open();
        //            reader = SqlMapper.QueryMultiple(objConnection, spName, p, commandType: CommandType.StoredProcedure);
        //        }
        //        return reader;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}