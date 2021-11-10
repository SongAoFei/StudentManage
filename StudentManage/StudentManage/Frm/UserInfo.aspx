<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="WebStudent.Frm.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title">首页 > 用户管理 > 详细</div>
    <div class="page-info">
        <div class="page-module">
            <div class="page-row">
                <span class="span">用户名<i>*</i></span>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="text text2"></asp:TextBox>
            </div>
            <div class="page-row">
                <span class="span">密码<i>*</i></span>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="text text2" TextMode="Password"></asp:TextBox>
            </div>
            <div class="page-row">
                <span class="span">姓名<i></i></span>
                <asp:TextBox ID="txtName" runat="server" CssClass="text text2"></asp:TextBox>
            </div>
            <div class="page-row">
                <span class="span">电话<i></i></span>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="text text2"></asp:TextBox>
            </div>
        </div>
        <div class="page-line2"></div>
        <div class="page-submit">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click" OnClientClick="return confirm('是否保存')" />
            <asp:Button ID="btnCancle" runat="server" Text="返回" CssClass="btn" OnClick="btnCancle_Click" />
        </div>
    </div>
</asp:Content>
