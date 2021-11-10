using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStudent
{
    public partial class userInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string uName = Request["uName"];
        string conStr = @"server=DESKTOP-CMQ2HP7; database = SS; trusted_Connection = true; ";
        SqlConnection con = new SqlConnection(conStr);
        con.Open();
        string sqlStr = "select * from tbUser where userName='" + uName + "'";
        SqlCommand cmd = new SqlCommand(sqlStr, con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            lbAge.Text = dr["userAge"].ToString();
            lbEmail.Text = dr["userEmail"].ToString();
            lbName.Text = uName;
            if((int)dr["userRole"]==0)
            {
                lbRole.Text = "管理员";
            }
            else
            {
                lbRole.Text = "会员";

            }
            imgPhoto.ImageUrl = "~/images/" + dr["userPhoto"].ToString();
        }
    }
}
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //登录按钮
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserName = txtUserName.Text.Trim();
            string strPassword = txtPassword.Text.Trim();

            Code.VerifyLogin db = new Code.VerifyLogin();
            if (db.Login(strUserName, strPassword))
            {
                //FormsAuthentication.SetAuthCookie(strUserName, createPersistentCookie: false);
                HttpCookie cookie = new HttpCookie("UserName",strUserName);
                //cookie.Value = strUserName;
                Response.Cookies.Add(cookie);
                Response.Redirect("~/Frm/Main.aspx");
            }
            else
            {
                Code.Common.ShowMessage(this, "用户名或密码错误");
            }
        }
    }
}