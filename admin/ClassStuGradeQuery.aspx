<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassStuGradeQuery.aspx.cs" Inherits="ClassStuGradeQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>班级学生成绩查询</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 521px; width: 1484px; text-align: center;">

        班级学生成绩查询<br />
        <br />
        <asp:DropDownList ID="cls" runat="server" OnSelectedIndexChanged="cls_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
&nbsp;
        <asp:DropDownList ID="student" runat="server" Height="35px" Width="154px">
        </asp:DropDownList>
&nbsp;
        <asp:Button ID="QueryBtn" runat="server" Text="查询" OnClick="btnQuery_Click"/>
        <br />
        <br />
        <asp:GridView ID="GradeGView" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="CourseName" HeaderText="课程名" />
                <asp:BoundField DataField="CommonScore" HeaderText="平时成绩" />
                <asp:BoundField DataField="MiddleScore" HeaderText="期中成绩" />
                <asp:BoundField DataField="LastScore" HeaderText="期末成绩" />
                <asp:BoundField DataField="TotalScore" HeaderText="总评成绩" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>

        <br />
        <a href="../Login.aspx?loginSuccess=true">返回首页</a>
    </div>
    </form>
</body>
</html>
