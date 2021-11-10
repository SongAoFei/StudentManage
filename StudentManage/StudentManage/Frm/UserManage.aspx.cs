using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebStudent.Frm
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        // 下载于www.mycodes.net
        //添加按钮
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfo.aspx?sign=add");
        }
        //查询按钮
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
        
        //修改按钮
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string no = btn.CommandArgument;
            string url = "UserInfo.aspx?sign=update&id=" + no;
            Response.Redirect(url);
        }
        //删除按钮
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string no = btn.CommandArgument;
            Code.UserManage db = new Code.UserManage();
            db.Delete(no);
            Bind();
            Code.Common.ShowMessage(this, "删除成功");
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void Bind()
        {
            DataSet ds = GetData();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        private DataSet GetData()
        {
            string userName = txtUserName.Text.Trim();
            string trueName = txtTrueName.Text.Trim();
            string condition = "";
            if (string.IsNullOrEmpty(userName) == false)
            {
                condition += " and UserName like '%" + userName + "%'";
            }
            if (string.IsNullOrEmpty(trueName) == false)
            {
                condition += " and TrueName like '%" + trueName + "%'";
            }

            Code.UserManage db = new Code.UserManage();
            DataSet ds = db.GetList(condition);
            return ds;
        }
    }
}