<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassAdd.aspx.cs" Inherits="admin_ClassAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>班级信息添加</title>
    <style type="text/css">
        .style2
        {
            height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        班级信息添加<br />
        <br />
        
    
        <br />
        <table align="center" class="style1">
            <tr>
                <td>
                    班级编码：</td>
                <td>
                    <asp:TextBox ID="ClassIDTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    班级名称：</td>
                <td>
                    <asp:TextBox ID="ClassNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    系部：</td>
                <td>
                    <asp:DropDownList ID="DeptDDList" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    班主任：</td>
                <td>
                    <asp:DropDownList ID="TeacherDDList" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    <asp:Button ID="InsertBtn" runat="server" onclick="InsertBtn_Click" Text="添 加" 
                        Width="80px" />
                </td>
            </tr>
        </table>
        
    
    </div>
    </form>
</body>
</html>
