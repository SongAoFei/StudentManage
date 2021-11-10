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
    /// 学生数据操作
    /// </summary>
    public class StudentManage
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        public DataSet GetList(string condition)
        {
            string strConn = Config.ConnectionString;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StudentNo,StudentName,Sex,Class,Birthday");
            strSql.Append(" from Student");
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
        public Student GetModel(string StudentNo)
        {
            string strConn = Config.ConnectionString;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StudentNo,StudentName,Sex,Class,Birthday");
            strSql.Append(" from Student");
            strSql.Append(" where 1>0 and StudentNo='" + StudentNo + "'");
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Student model = new Student();
            if (dr.Read())
            {
                model.StudentNo = dr["StudentNo"].ToString();
                model.StudentName = dr["StudentName"].ToString();
                model.Sex = dr["Sex"].ToString();
                model.Class = dr["Class"].ToString();
                model.Birthday = dr["Birthday"].ToString();
            }
            conn.Close();
            return model;
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int Add(Student model)
        {
            string strConn = Config.ConnectionString;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Student(");
            strSql.Append("StudentNo,StudentName,Sex,Class,Birthday)");
            strSql.Append(" values (");
            strSql.Append("@StudentNo,@StudentName,@Sex,@Class,@Birthday)");
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), conn);
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@StudentNo", SqlDbType.VarChar);
            parameters[1] = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            parameters[2] = new SqlParameter("@Sex", SqlDbType.NVarChar);
            parameters[3] = new SqlParameter("@Class", SqlDbType.NVarChar);
            parameters[4] = new SqlParameter("@Birthday", SqlDbType.VarChar);
            parameters[0].Value = model.StudentNo;
            parameters[1].Value = model.StudentName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Class;
            parameters[4].Value = model.Birthday;
            cmd.Parameters.AddRange(parameters);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }

        /// <summary>
        /// 修改
        /// </summary>
        public int Update(Student model)
        {
            string strConn = Config.ConnectionString;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Student set ");
            strSql.Append(" StudentName=@StudentName,Sex=@Sex,Class=@Class,Birthday=@Birthday ");
            strSql.Append(" where StudentNo=@StudentNo");
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), conn);
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            parameters[1] = new SqlParameter("@Sex", SqlDbType.NVarChar);
            parameters[2] = new SqlParameter("@Class", SqlDbType.NVarChar);
            parameters[3] = new SqlParameter("@Birthday", SqlDbType.VarChar);
            parameters[4] = new SqlParameter("@StudentNo", SqlDbType.VarChar);
            parameters[0].Value = model.StudentName;
            parameters[1].Value = model.Sex;
            parameters[2].Value = model.Class;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.StudentNo;
            cmd.Parameters.AddRange(parameters);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }

        /// <summary>
        /// 删除
        /// </summary>
        public int Delete(string StudentNo)
        {
            string strConn = Config.ConnectionString;
            string strSql = "delete from Student where 1>0 and StudentNo='" + StudentNo + "'";
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
        public bool Exist(string StudentNo)
        {
            string condition = " and StudentNo='" + StudentNo + "'";
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


    }
}