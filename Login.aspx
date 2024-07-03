<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学分制教学管理系统</title>
    <style type="text/css">
        h1 {
            margin-bottom: 20px;
            color: #0080ff; /* 主色 */
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .form-group input[type="text"],
        .form-group input[type="password"] {
            padding: 8px;
            border: 1px solid #ccc;
        }

        .btn-group {
            margin-top: 20px;
        }

        .btn-group button {
            padding: 10px 25px;
            border: none;
            background-color: #2ecc71; /* 辅助色1 */
            color: #fff;
            cursor: pointer;
            text-align: center; /* 文字居中 */
            font-size: 16px; /* 设置按钮字体大小 */
        }

        .btn-group button:hover {
            background-color: #27ae60; /* 辅助色1 加深 */
        }

        .panel {
            display: none;
            margin-top: 20px;
        }

        .panel.active {
            display: block;
        }

        .panel {
            height: auto;
            width: 300px; /* Or adjust according to your layout */
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #f9f9f9;
            margin-bottom: 20px;
        }

        .label {
            font-size: 18px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .links a {
            text-decoration: none;
            color: #0000ff;
            margin-bottom : 56px;
            padding: 8px 16px;
            border: 1px solid #0000ff;
        }

        .links a:hover {
            background-color: #0000ff;
            color: #fff;
        }
    </style>
</head>
<body style="text-align: center;">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <h1>学生学习情况登记系统</h1>
        <br />

        <asp:Panel ID="LoginPanel" runat="server" Height="206px">
            账号: <asp:TextBox ID="StuIDTextBox" runat="server" Width="150px" style="font-size:20px;  margin-bottom:10px"></asp:TextBox><br />
            密码: <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password" Width="150px" style="font-size:20px;"></asp:TextBox><br />
            <br />
            <div class="radio-group">
                <asp:RadioButtonList ID="UserRoleRadio" runat="server" RepeatLayout="Flow" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Text="管理员" Value="Admin"></asp:ListItem>
                    <asp:ListItem Text="教师" Value="Teacher"></asp:ListItem>
                    <asp:ListItem Text="学生" Value="Student" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <asp:Button ID="LoginSubmitBtn" runat="server" CssClass="btn btn-fancy" Text="提交" OnClick="LoginSubmit_Click" Width="70px" />
            &nbsp;
            <asp:Button ID="LoginResetBtn" runat="server" CssClass="btn btn-fancy" Text ="重置" Width="70px" OnClick="LoginReset_Click" />
        </asp:Panel>
        <br />

        <asp:Panel ID="LoginOkPanel" runat="server" Height="300px" 
            Visible="False" HorizontalAlign="Center">
            <asp:Label ID="LoginOKLabel" runat="server" Text="学生登录成功" CssClass="label" 
                Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <br />
            <div class="links">
                <a href="student/SelectCourse.aspx">课程选修</a> <br /><br />
                <a href="student/StuGradeQuery.aspx">成绩查询</a> <br /><br />
                <a href="student/ReturnCourse.aspx">课程退选</a> <br /><br />
                <a href="login.aspx?loginSuccess=false&LoginOkPanel=false&Panel1=false&Panel11=false">退出登录</a>
            </div>
            <br />
        </asp:Panel>

        <asp:Panel ID="Panel1" runat="server" Height="300px" Visible="False">
            <asp:Label ID="Label1" runat="server" Text="教师登录成功" CssClass="label" 
                Font-Size="X-Large" ></asp:Label>
            <br />
            <br />
            <br />
            <div class="links">
                <a href="teacher/GradeProcess.aspx">成绩录入</a> <br /> <br /> 
                <a href="teacher/TeacherGradeQuery.aspx">成绩查询</a> <br /><br /> 
                <a href="teacher/StuGradeQuery.aspx">平均成绩查询</a> <br /><br /> 
                <a href="login.aspx?loginSuccess=false&LoginOkPanel=false&Panel1=false&Panel11=false">退出登录</a> <br />
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel11" runat="server"  Height="300px" Visible="False">
            <asp:Label ID="Label11" runat="server" Text="管理员登录成功"   CssClass="label" 
                Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <br />
            <div class="links">
                <a href="admin/ClassAdd.aspx">新增班级</a> <br />  <br />
                <a href="admin/ClassManage.aspx">班级管理</a> <br /><br />
                <a href="admin/ClassStuGradeQuery.aspx">班级成绩查询</a> <br /><br />
                <a href="admin/TeacherGradeQuery.aspx">教师课程班成绩查询</a> <br /><br />
                <a href="admin/StuAdd.aspx">新增学生</a> <br /> <br />
                <a href="admin/StuManage.aspx">学生管理</a> <br /><br /> 
                <a href="login.aspx?loginSuccess=false&LoginOkPanel=false&Panel1=false&Panel11=false">退出登录</a>
            </div>                
            <br />
        </asp:Panel>
            <br />
    </div>
    </form>
</body>
</html>
