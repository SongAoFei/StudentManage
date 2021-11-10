using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebStudent.Code
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
    }
}