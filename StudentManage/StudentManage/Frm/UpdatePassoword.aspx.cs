using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// 下载于www.mycodes.net
namespace WebStudent.Frm
{
    public partial class UpdatePassoword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["UserName"];
                txtUserName.Text = cookie.Value;
                txtUserName.Enabled = false;
            }
        }
        //修改按钮
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                if (VerifyOldPwd())
                {
                    string strUserName = txtUserName.Text.Trim();
                    string strNewPwd = txtNewPwd.Text.Trim();

                    Code.UserManage db = new Code.UserManage();
                    db.UpdatePassword(strUserName, strNewPwd);
                    Code.Common.ShowMessage(this, "密码修改成功");
                }
            }
        }

        /// <summary>
        /// 验证信息
        /// </summary>
        /// <returns></returns>
        private bool VerifyData()
        {
            if (txtOldPwd.Text.Trim() == "")
            {
                Code.Common.ShowMessage(this, "原密码 不能为空");
                return false;
            }
            if (txtNewPwd.Text.Trim() == "")
            {
                Code.Common.ShowMessage(this, "新密码 不能为空");
                return false;
            }
            if (txtRepeat.Text.Trim() == "")
            {
                Code.Common.ShowMessage(this, "确认密码 不能为空");
                return false;
            }
            if (txtNewPwd.Text.Trim() != txtRepeat.Text.Trim())
            {
                Code.Common.ShowMessage(this, "新密码和确认密码不一致");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证原密码
        /// </summary>
        /// <returns></returns>
        private bool VerifyOldPwd()
        {
            string strUserName = txtUserName.Text.Trim();
            string strOldPwd = txtOldPwd.Text.Trim();
            Code.VerifyLogin db = new Code.VerifyLogin();
            if (db.Login(strUserName, strOldPwd))
            {
                return true;
            }
            else
            {
                Code.Common.ShowMessage(this, "原密码不正确");
                return false;
            }
        }
    }
}