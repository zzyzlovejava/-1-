<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuEdit.aspx.cs" Inherits="admin_StuEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生信息更新</title>
    <script type="text/javascript">
        function validateForm() {

            // 获取学号输入框的值
            var stuIDValue = document.getElementById('<%= StuIDTextBox.ClientID %>').value;
            // 获取姓名输入框的值
            var stuNameValue = document.getElementById('<%= StuNameTextBox.ClientID %>').value;
            // 获取密码输入框的值
            var passwordValue = document.getElementById('<%= PasswordTextBox.ClientID %>').value;

            // 使用正则表达式验证学号是否为空
            if (stuIDValue.trim() === "") {
                // 如果学号为空，显示错误消息
                alert("学号不能为空。");
                return false; // 阻止表单提交
            }

            // 使用正则表达式验证姓名是否为空
            if (stuNameValue.trim() === "") {
                // 如果姓名为空，显示错误消息
                alert("姓名不能为空。");
                return false; // 阻止表单提交
            }

            // 使用正则表达式验证密码是否为6位数字
            var passwordRegex = /^\d{6}$/;
            if (!passwordRegex.test(passwordValue)) {
                // 如果密码格式不正确，显示错误消息
                alert("密码必须为6位数字。");
                return false; // 阻止表单提交
            }

            // 获取性别输入框的值
            var sexValue = document.getElementById('<%= SexTextBox.ClientID %>').value;

            // 使用正则表达式验证性别是否正确
            var sexRegex = /^[MFmf]$/;
            if (!sexRegex.test(sexValue)) {
                // 如果性别填写错误，显示错误消息
                alert("性别只能填写 'M' 或 'F'。");
                return false; // 阻止表单提交
            }

            // 获取入学年份输入框的值
            var enrollYearValue = document.getElementById('<%= EnrollYearTextBox.ClientID %>').value;
            // 获取毕业年份输入框的值
            var gradYearValue = document.getElementById('<%= GradYearTextBox.ClientID %>').value;

            // 使用正则表达式验证入学年份和毕业年份是否符合要求
            var yearRegex = /^\d{4}$/;
            if (!yearRegex.test(enrollYearValue) || !yearRegex.test(gradYearValue)) {
                // 如果年份格式不正确，显示错误消息
                alert("请输入正确的年份格式（四位数字）。");
                return false; // 阻止表单提交
            }
            // 如果性别填写正确，可以继续提交表单
            document.getElementById('<%= UpdateBtn.ClientID %>').click();
            return true;
        }
    </script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server" onsubmit="return validateForm();">
    <div>
        学生信息更新<br />
        <br />

        <table align="center" class="style1">
            <tr>
                <td>
                    学生学号：</td>
                <td>
                    <asp:TextBox ID="StuIDTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    学生姓名：</td>
                <td class="style1">
                    <asp:TextBox ID="StuNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>入学年份：</td>

                <td>
                    <asp:TextBox ID="EnrollYearTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>毕业年份：</td>

                <td>
                    <asp:TextBox ID="GradYearTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    系部：</td>
                <td>
                    <asp:DropDownList ID="DeptIDDropDownList" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    所属班级：</td>
                <td>
                    <asp:DropDownList ID="ClassIDDropDownList" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    性别：</td>
                <td>
                    <asp:TextBox ID="SexTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    生日：</td>
                <td>
                    <asp:TextBox ID="BirthdayTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    登录密码：</td>
                <td>
                    <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    家庭地址：</td>
                <td>
                    <asp:TextBox ID="AddressTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    邮政编码：</td>
                <td>
                    <asp:TextBox ID="ZipCodeTextBox" runat="server"></asp:TextBox>
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
