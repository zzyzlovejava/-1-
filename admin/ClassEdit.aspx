<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassEdit.aspx.cs" Inherits="admin_ClassEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>班级信息更新</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
    
        班级信息更新<br />
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
                    <asp:Button ID="UpdateBtn" runat="server" onclick="InsertBtn_Click" Text="更 新" 
                        Width="80px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
