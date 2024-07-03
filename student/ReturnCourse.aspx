<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnCourse.aspx.cs" Inherits="ReturnCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网上课程退选</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; height: 700px; width: 1414px;">
    
        网上课程退选<br />
        <br />
        <asp:GridView ID="StuCourseGView" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" HorizontalAlign="Center" 
            onrowdeleting="StuCourseGView_RowDeleting" 
            onselectedindexchanged="StuCourseGView_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="CourseClassID" HeaderText="课程班编码" />
                <asp:BoundField DataField="CourseName" HeaderText="课程名称" />
                <asp:BoundField DataField="TeacherName" HeaderText="任课教师" />
                <asp:BoundField DataField="TeachingPlace" HeaderText="教学地点" />
                <asp:BoundField DataField="TeachingTime" HeaderText="教学时间" />
                <asp:TemplateField HeaderText="退选" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="退选" OnClientClick="javascript:return confirm('真的要退选吗？');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
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
        <br/>
          <div>
            <a href="SelectCourse.aspx">课程选修</a>
            <a href="StuGradeQuery.aspx">成绩查询</a>
            <a href="../Login.aspx?loginSuccess=true">返回首页</a>
        </div>

    </div>
    </form>
</body>
</html>
