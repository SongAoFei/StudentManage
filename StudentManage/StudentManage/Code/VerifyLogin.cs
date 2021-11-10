using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebStudent.Code
{
    /// <summary>
    /// 验证用户登录
    /// </summary>
    public class VerifyLogin
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            string condition = " and UserName='" + userName + "' and Password='" + password + "'";
            UserManage db = new UserManage();
            DataSet ds = db.GetList(condition);
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