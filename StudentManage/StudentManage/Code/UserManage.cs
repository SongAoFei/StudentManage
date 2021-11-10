using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WebStudent.Code
{
    /// <summary>
    /// 用户数据操作
    /// </summary>
    public class UserManage
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        public DataSet GetList(string condition)
        {
            string strConn = Config.ConnectionString;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName,Password,TrueName,Phone");
            strSql.Append(" from Users");
            strSql.Append(" where 1>0 " + condition);
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter(strSql.ToString(), conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 获取模型
        /// </summary>
        public Users GetModel(string UserName)
        {
            string strConn = Config.ConnectionString;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName,Password,TrueName,Phone");
            strSql.Append(" from Users");
            strSql.Append(" where 1>0 and UserName='" + UserName + "'");
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Users model = new Users();
            if (dr.Read())
            {
                model.UserName = dr["UserName"].ToString();
                model.Password = dr["Password"].ToString();
                model.TrueName = dr["TrueName"].ToString();
                model.Phone = dr["Phone"].ToString();
            }
            conn.Close();
            return model;
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int Add(Users model)
        {
            string strConn = Config.ConnectionString;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("UserName,Password,TrueName,Phone)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@TrueName,@Phone)");
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), conn);
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
            parameters[1] = new SqlParameter("@Password", SqlDbType.VarChar);
            parameters[2] = new SqlParameter("@TrueName", SqlDbType.NVarChar);
            parameters[3] = new SqlParameter("@Phone", SqlDbType.VarChar);
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Phone;
            cmd.Parameters.AddRange(parameters);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }

        /// <summary>
        /// 修改
        /// </summary>
        public int Update(Users model)
        {
            string strConn = Config.ConnectionString;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append(" Password=@Password,TrueName=@TrueName,Phone=@Phone ");
            strSql.Append(" where UserName=@UserName");
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), conn);
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Password", SqlDbType.VarChar);
            parameters[1] = new SqlParameter("@TrueName", SqlDbType.NVarChar);
            parameters[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            parameters[3] = new SqlParameter("@UserName", SqlDbType.VarChar);
            parameters[0].Value = model.Password;
            parameters[1].Value = model.TrueName;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.UserName;
            cmd.Parameters.AddRange(parameters);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }

        /// <summary>
        /// 删除
        /// </summary>
        public int Delete(string UserName)
        {
            string strConn = Config.ConnectionString;
            string strSql = "delete from Users where 1>0 and UserName='" + UserName + "'";
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return 1;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        public bool Exist(string UserName)
        {
            string condition = " and UserName='" + UserName + "'";
            DataSet ds = GetList(condition);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public int UpdatePassword(string userName,string password)
        {
            string strConn = Config.ConnectionString;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append(" Password=@Password ");
            strSql.Append(" where UserName=@UserName");
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), conn);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Password", SqlDbType.VarChar);
            parameters[1] = new SqlParameter("@UserName", SqlDbType.VarChar);
            parameters[0].Value = password;
            parameters[1].Value = userName;
            cmd.Parameters.AddRange(parameters);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }
    }
}