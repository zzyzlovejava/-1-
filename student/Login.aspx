<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            width: 1422px;
            height: 657px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
    
    学生模块登录<br />
    <asp:Panel ID="LoginPanel" runat="server" Height="115px">
        <asp:Label ID="Label1" runat="server" Text="学号："></asp:Label>
        <asp:TextBox ID="StuIDTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label>
        <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="LoginSubmitBtn" runat="server" Text="提交" 
            onclick="LoginSubmitBtn_Click" />
        &nbsp;
        <asp:Button ID="LoginResetBtn" runat="server" onclick="Button2_Click" 
            Text="重置" />
    </asp:Panel>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Panel ID="LoginOkPanel" runat="server" Height="266px" Visible="False">
            <asp:Label ID="LoginOkLabel" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <a href="SelectCourse.aspx">课程选修</a><br /> <a href="StuGradeQuery.aspx">成绩查询</a>
        </asp:Panel>
    
    
    </form>
</body>
</html>
