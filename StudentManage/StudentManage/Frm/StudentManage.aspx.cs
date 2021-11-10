using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebStudent.Frm
{
    public partial class StudentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        //添加按钮
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentInfo.aspx?sign=add");
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
            string url = "StudentInfo.aspx?sign=update&id=" + no;
            Response.Redirect(url);
        }
        //删除按钮
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string no = btn.CommandArgument;
            Code.StudentManage db = new Code.StudentManage();
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
            string studentNo = txtStudentNo.Text.Trim();
            string studentName = txtStuentName.Text.Trim();
            string condition = "";
            if (string.IsNullOrEmpty(studentNo) == false)
            {
                condition += " and StudentNo like '%" + studentNo + "%'";
            }
            if (string.IsNullOrEmpty(studentName) == false)
            {
                condition += " and StudentName like '%" + studentName + "%'";
            }

            Code.StudentManage db = new Code.StudentManage();
            DataSet ds = db.GetList(condition);
            return ds;
        }
    }
}