<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebStudent.Frm.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title">首页</div>
    <div class="main">
        <div class="main-left">

        </div>
        <div class="main-right">
            欢迎使用本系统
            <br/>
            当前登录用户：<asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
