<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebStudent.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录--学生信息管理系统</title>
    <link href="Css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <div class="login-title">学生信息管理系统</div>
            <div class="login-content">
                <div class="login-row">
                    <span class="span">用户名：</span>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="text"></asp:TextBox>
                </div>
                <div class="login-row">
                    <span class="span">密码：</span>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
                </div>
                <div class="login-row">
                    <span class="span">&nbsp;</span>
                    <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="btn" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
