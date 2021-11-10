using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStudent
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        // 下载于www.mycodes.net
        private void LoadData()
        {
            HttpCookie cookie = Request.Cookies["UserName"];
            if (cookie != null)
            {
                btnUserName.Text = cookie.Value;
            }

        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            //注销
            if (TreeView1.SelectedValue == "注销")
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}