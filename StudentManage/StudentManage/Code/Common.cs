using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStudent.Code
{
    /// <summary>
    /// 公用方法类
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 弹出对话框（不影响css样式）
        /// </summary>
        /// <param name="page">页面指针，一般为this</param>
        /// <param name="scriptKey">脚本键，唯一</param>
        /// <param name="message">提示信息</param>
        public static void ShowMessage(System.Web.UI.Page page, string scriptKey, string message)
        {
            System.Web.UI.ClientScriptManager csm = page.ClientScript;
            if (!csm.IsStartupScriptRegistered(scriptKey))
            {
                string strScript = string.Format("alert('{0}');", message);
                csm.RegisterStartupScript(page.GetType(), scriptKey, strScript, true);
            }
        }

        /// <summary>
        /// 弹出对话框（不影响css样式）
        /// </summary>
        /// <param name="page">页面指针，一般为this</param>
        /// <param name="message">提示信息</param>
        public static void ShowMessage(System.Web.UI.Page page, string message)
        {
            string scriptKey = "msg";
            ShowMessage(page, scriptKey, message);
        }
    }
}