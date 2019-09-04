using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//引入如下三个命名空间
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.IO;

namespace MVCDemo01
{
    public class SQLHelper
    {
        //封装数据库连接字符串
        private static string connString = ConfigurationManager.ConnectionStrings["connstr"].ToString();
        #region 封装格式化SQL语句执行的各种方法
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql,conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorMeg = "调用public static int Update(string sql)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                conn.Close();
            }
        }

        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorMeg = "调用public static object GetSingleResult(string sql)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                conn.Close();
            }
        }

        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                //将异常信息写入日志
                string errorMeg = "调用public static SqlDataReader GetReader(string sql)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
        }

        public static DataSet GetDataSet(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);//创建数据适配器对象
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds);//使用数据适配器填充数据集
                return ds;

            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorMeg = "调用public static DataSet GetDataSet(string sql)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
        #region 封装带参数SQL语句执行的各种方法
        public static int Update(string sql,SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorMeg = "调用public static int Update(string sql,SqlParameter[] param)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                conn.Close();
            }
        }

        public static object GetSingleResult(string sql,SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorMeg = "调用public static object GetSingleResult(string sql,SqlParameter[] param)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                conn.Close();
            }
        }

        public static SqlDataReader GetReader(string sql,SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                //将异常信息写入日志
                string errorMeg = "调用public static SqlDataReader GetReader(string sql,SqlParameter[] param)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
        }

        public static DataSet GetDataSet(string sql,SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);//创建数据适配器对象
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                da.Fill(ds);//使用数据适配器填充数据集
                return ds;

            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorMeg = "调用public static DataSet GetDataSet(string sql,SqlParameter[] param)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 启用事务提交多条带参数的sql语句
        /// </summary>
        /// <param name="mainSql">修改主表sql语句</param>
        /// <param name="mainParam">修改主表sql语句的参数</param>
        /// <param name="detailSql">修改明细表的sql语句（必填）</param>
        /// <param name="detailParam">修改明细表的sql语句参数（必填）</param>
        /// <returns></returns>
        public static bool UpdateByTransaction(string mainSql,SqlParameter[] mainParam,string detailSql,List<SqlParameter[]> detailParam)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//开启事务
                if (mainSql!=null)
                {
                    cmd.CommandText = mainSql;
                    cmd.Parameters.AddRange(mainParam);
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = detailSql;
                foreach (SqlParameter[] parameters in detailParam)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                return true;

            }
            catch (Exception ex)
            {
                if (cmd.Transaction!=null)
                {
                    cmd.Transaction.Rollback();
                }
                //将异常信息写入日志
                string errorMeg = "调用public static bool UpdateByTransaction(string mainSql,SqlParameter[] mainParam,string detailSql,List<SqlParameter[]> detailParam)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                if (cmd.Transaction!=null)
                {
                    cmd.Transaction = null;
                }
                conn.Close();
            }
        }

        /// <summary>
        /// 启用事务调用带参数存储过程
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="paramArray">存储过程参数集合</param>
        /// <returns></returns>
        public static bool UpdateByTransaction(string procedureName,List<SqlParameter[]> paramArray)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedureName;
                cmd.Transaction = conn.BeginTransaction();//开启事务
                foreach (SqlParameter[] parameters in paramArray)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                return true;

            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();
                }
                //将异常信息写入日志
                string errorMeg = "调用public static bool UpdateByTransaction(string procedureName,List<SqlParameter[]> paramArray)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;
                }
                conn.Close();
            }
        }
        #endregion
        #region 封装调用存储过程执行的各种方法
        public static int UpdateByProcedure(string spName, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(spName, conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorMeg = "调用public static int UpdateByProcedure(string spName, SqlParameter[] param)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                conn.Close();
            }
        }

        public static object GetSingleResultByProcedure(string spName, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(spName, conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //将异常信息写入日志
                string errorMeg = "调用public static object GetSingleResultByProcedure(string spName, SqlParameter[] param)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
            finally
            {
                conn.Close();
            }
        }

        public static SqlDataReader GetReaderByProcedure(string spName, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(spName, conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                //将异常信息写入日志
                string errorMeg = "调用public static SqlDataReader GetReaderByProcedure(string spName, SqlParameter[] param)方法时发生错误。错误信息：" + ex.Message;
                WriteLog(errorMeg);
                throw new Exception(errorMeg);
            }
        }
        #endregion
        #region 其他方法
        private static void WriteLog(string log)
        {
            FileStream fs = new FileStream("SQLHelper.log",FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToShortDateString()+" "+ log);
            sw.Close();
            fs.Close();
        }
        #endregion
    }
}
