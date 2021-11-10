<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentManage.aspx.cs" Inherits="WebStudent.Frm.StudentManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-title">首页 > 用户管理</div>
    <div class="page-filter">
        <span>学号：</span><asp:TextBox ID="txtStudentNo" runat="server" CssClass="text"></asp:TextBox>
        <span>姓名：</span><asp:TextBox ID="txtStuentName" runat="server" CssClass="text"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn" OnClick="btnSearch_Click" />
    </div>
    <div class="page-tool">
        <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" CssClass="btn" />
    </div>
    <div class="page-table">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="StudentNo" HeaderText="学号">
                    <HeaderStyle Width="100px"/>
                </asp:BoundField>
                <asp:BoundField DataField="StudentName" HeaderText="姓名">
                    <HeaderStyle Width="100px"/>
                </asp:BoundField>
                <asp:BoundField DataField="Sex" HeaderText="性别">
                    <HeaderStyle Width="100px"/>
                </asp:BoundField>
                <asp:BoundField DataField="Birthday" HeaderText="出生日期">
                    <HeaderStyle Width="100px"/>
                </asp:BoundField>
                <asp:BoundField DataField="Class" HeaderText="班级">
                    <HeaderStyle Width="100px"/>
                </asp:BoundField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CommandArgument='<%#Eval("StudentNo") %>'>修改</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%#Eval("StudentNo") %>' OnClientClick="return confirm('确定删除该数据？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="80px"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle CssClass="td-end" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
