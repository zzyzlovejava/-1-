<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuManage.aspx.cs" Inherits="admin_StuManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生信息维护</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        学生信息维护<br />
        <br />
      
        <asp:DropDownList ID="ClassDDList" runat="server" Width="150px">
        </asp:DropDownList>
               
        &nbsp;
               
        <asp:Button ID="QueryBtn" runat="server" Text="查询" Width="80px" 
            onclick="QueryBtn_Click" />
         
        <br />  <br />
        <asp:GridView ID="StuGView" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" HorizontalAlign="Center" 
            DataKeyNames="StuID" Font-Size="Small" 
            onrowdeleting="StuGView_RowDeleting">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:BoundField DataField="StuID" HeaderText="学生学号" />
                <asp:BoundField DataField="StuName" HeaderText="学生姓名" />
                <asp:BoundField DataField="EnrollYear" HeaderText="入学年份" />
                <asp:BoundField DataField="GradYear" HeaderText="毕业年份" />
                <asp:BoundField DataField="DeptID" HeaderText="系部" />
                <asp:BoundField DataField="ClassID" HeaderText="所属班级" />
                <asp:BoundField DataField="Sex" HeaderText="性别" />
                <asp:BoundField DataField="Birthday" HeaderText="生日" />
                <asp:BoundField DataField="SPassword" HeaderText="登录密码" />
                <asp:BoundField DataField="StuAddress" HeaderText="家庭地址" />
                <asp:BoundField DataField="ZipCode" HeaderText="邮政编码" />
                <asp:BoundField DataField="TotalCredit" HeaderText="总学分" />
                <asp:BoundField DataField="TotalGrade" HeaderText="总成绩" />
                <asp:HyperLinkField DataNavigateUrlFields="StuID" 
                    DataNavigateUrlFormatString="StuEdit.aspx?StuID={0}" HeaderText="编辑" 
                    Text="编辑" />
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="删除" OnClientClick="javascript:return confirm('真的要删除吗？');"></asp:LinkButton>
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

        <a href="StuAdd.aspx">学生信息添加</a>&nbsp;&nbsp;&nbsp;
        <a href="../Login.aspx?loginSuccess=true">返回首页</a>    
    
    </div>
    </form>
</body>
</html>
