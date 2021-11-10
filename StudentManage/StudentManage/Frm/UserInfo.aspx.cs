using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStudent.Frm
{
    public partial class UserInfo : System.Web.UI.Page
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
                    txtUserName.Enabled = false;
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
            Response.Redirect("UserManage.aspx");
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string id = Request.QueryString["id"];
            Code.UserManage db = new Code.UserManage();
            var model = db.GetModel(id);
            txtUserName.Text = model.UserName;
            //txtPassword.Text = model.Password;
            txtPassword.Attributes.Add("value",model.Password);
            txtName.Text = model.TrueName;
            txtPhone.Text = model.Phone;
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
                    Code.UserManage db = new Code.UserManage();
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
                Code.UserManage db = new Code.UserManage();
                db.Update(model);
                btnSave.Visible = false;
                Code.Common.ShowMessage(this, "修改成功");
            }
        }
        /// <summary>
        /// 获取数据模型
        /// </summary>
        /// <returns></returns>
        private Code.Users GetModel()
        {
            Code.Users model = new Code.Users();
            model.UserName = txtUserName.Text.Trim();
            model.Password = txtPassword.Text.Trim();
            model.TrueName = txtName.Text.Trim();
            model.Phone = txtPhone.Text.Trim();
            return model;
        }
        /// <summary>
        /// 验证录入
        /// </summary>
        /// <returns></returns>
        private bool VerifyData()
        {
            if (txtUserName.Text.Trim() == "")
            {
                Code.Common.ShowMessage(this, "请输入 用户名");
                return false;
            }
            if (txtPassword.Text.Trim() == "")
            {
                Code.Common.ShowMessage(this, "请输入 密码");
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
            string key = txtUserName.Text.Trim();
            Code.UserManage db = new Code.UserManage();
            if (db.Exist(key))
            {
                Code.Common.ShowMessage(this, "该用户名已存在");
                return false;
            }
            return true;
        }
    }
}