<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCourse.aspx.cs" Inherits="SelectCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网上课程选修</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; height: 745px; width: 1421px;">
    
        网上课程选修<br />
        <br />
        <asp:GridView ID="CourseClassGView" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" HorizontalAlign="Center" AutoGenerateColumns="False" 
            DataKeyNames="CourseClassID">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="勾选">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CBoxCourseClass" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CBoxCourseClass" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CourseClassID" HeaderText="课程班编码" Visible="False" />
                <asp:BoundField DataField="CourseName" HeaderText="课程名称" />
                <asp:BoundField DataField="TeacherName" HeaderText="任课教师" />
                <asp:BoundField DataField="TeachingPlace" HeaderText="教学地点" />
                <asp:BoundField DataField="TeachingTime" HeaderText="教学时间" />
                <asp:BoundField DataField="MaxNumber" HeaderText="允许选修数" />
                <asp:BoundField DataField="SelectedNumber" HeaderText="已选数" />
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
        <br />
        <asp:Button ID="StuSelectBtn" runat="server" onclick="StuSelectBtn_Click" 
            Text="确定" />

        &nbsp;&nbsp;&nbsp;

        <a href="../Login.aspx?loginSuccess=true">返回首页</a>
    
    </div>
    </form>
</body>
</html>
