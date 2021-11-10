using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStudent.Frm
{
    public partial class StudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sign = Request.QueryString["sign"];
                if (sign == "add")
                { }
                else if (sign == "update")
                {
                    txtStudentNo.Enabled = false;
                    LoadData();
                }
            }
        }
        //保存按钮
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sign = Request.QueryString["sign"];
            if (sign == "add")
            {
                Add();
            }
            else if (sign == "update")
            {
                Update();
            }
        }
        //返回按钮
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentManage.aspx");
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string id = Request.QueryString["id"];
            Code.StudentManage db = new Code.StudentManage();
            var model = db.GetModel(id);
            txtStudentNo.Text = model.StudentNo;
            txtStudentName.Text = model.StudentName;
            txtSex.Text = model.Sex;
            txtClass.Text = model.Class;
            txtBirthday.Text = model.Birthday;
        }
        /// <summary>
        /// 添加
        /// </summary>
        private void Add()
        {
            if (VerifyData())//验证数据
            {
                if (VerifyKey())//验证主键唯一
                {
                    var model = GetModel();
                    Code.StudentManage db = new Code.StudentManage();
                    db.Add(model);
                    btnSave.Visible = false;
                    Code.Common.ShowMessage(this, "添加成功");
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void Update()
        {
            if (VerifyData())//验证数据
            {
                var model = GetModel();
                Code.StudentManage db = new Code.StudentManage();
                db.Update(model);
                btnSave.Visible = false;
                Code.Common.ShowMessage(this, "修改成功");
            }
        }
        /// <summary>
        /// 获取数据模型
        /// </summary>
        /// <returns></returns>
        private Code.Student GetModel()
        {
            Code.Student model = new Code.Student();
            model.StudentNo = txtStudentNo.Text.Trim();
            model.StudentName = txtStudentName.Text.Trim();
            model.Sex = txtSex.Text.Trim();
            model.Class = txtClass.Text.Trim();
            model.Birthday = txtBirthday.Text.Trim();
            return model;
        }
        /// <summary>
        /// 验证录入
        /// </summary>
        /// <returns></returns>
        private bool VerifyData()
        {
            if (txtStudentNo.Text.Trim() == "")
            {
                Code.Common.ShowMessage(this, "请输入 学号");
                return false;
            }
            if (txtStudentName.Text.Trim() == "")
            {
                Code.Common.ShowMessage(this, "请输入 姓名");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 验证主键唯一
        /// </summary>
        /// <returns></returns>
        private bool VerifyKey()
        {
            string key = txtStudentNo.Text.Trim();
            Code.StudentManage db = new Code.StudentManage();
            if (db.Exist(key))
            {
                Code.Common.ShowMessage(this, "该学号已存在");
                return false;
            }
            return true;
        }
    }
}