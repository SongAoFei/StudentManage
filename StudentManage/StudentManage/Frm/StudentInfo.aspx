<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="WebStudent.Frm.StudentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title">首页 > 用户管理 > 详细</div>
    <div class="page-info">
            <div class="page-module">
                <div class="page-row">
                    <span class="span">学号<i>*</i></span>
                    <asp:TextBox ID="txtStudentNo" runat="server" CssClass="text text2"></asp:TextBox>
                </div>
                <div class="page-row">
                    <span class="span">姓名<i>*</i></span>
                    <asp:TextBox ID="txtStudentName" runat="server" CssClass="text text2"></asp:TextBox>
                </div>
                <div class="page-row">
                    <span class="span">性别<i></i></span>
                    <asp:TextBox ID="txtSex" runat="server" CssClass="text text2"></asp:TextBox>
                </div>
                <div class="page-row">
                    <span class="span">班级<i></i></span>
                    <asp:TextBox ID="txtClass" runat="server" CssClass="text text2"></asp:TextBox>
                </div>
                <div class="page-row">
                    <span class="span">出生日期<i></i></span>
                    <asp:TextBox ID="txtBirthday" runat="server" CssClass="text text2"></asp:TextBox>
                </div>
            </div>
            <div class="page-line2"></div>
            <div class="page-submit">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click" OnClientClick="return confirm('是否保存')" />
                <asp:Button ID="btnCancle" runat="server" Text="返回" CssClass="btn" OnClick="btnCancle_Click" />
            </div>
        </div>
</asp:Content>
