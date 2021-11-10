<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePassoword.aspx.cs" Inherits="WebStudent.Frm.UpdatePassoword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title">首页 > 修改密码</div>
    <div class="page-info">
        <div class="page-module">
            <div class="page-row">
                <span class="span">用户名<i></i></span>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="text text2"></asp:TextBox>
            </div>
            <div class="page-row">
                <span class="span">原密码<i>*</i></span>
                <asp:TextBox ID="txtOldPwd" runat="server" CssClass="text text2" TextMode="Password"></asp:TextBox>
            </div>
            <div class="page-row">
                <span class="span">新密码<i>*</i></span>
                <asp:TextBox ID="txtNewPwd" runat="server" CssClass="text text2" TextMode="Password"></asp:TextBox>
            </div>
            <div class="page-row">
                <span class="span">确认密码<i>*</i></span>
                <asp:TextBox ID="txtRepeat" runat="server" CssClass="text text2" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="page-line2"></div>
        <div class="page-submit">
            <asp:Button ID="btnUpdate" runat="server" Text="修改" CssClass="btn" OnClick="btnUpdate_Click" OnClientClick="return confirm('是否保存')" />
        </div>
    </div>
</asp:Content>
