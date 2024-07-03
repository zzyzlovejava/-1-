using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        StuIDTextBox.Text = "";
        PassTextBox.Text = "";

    }
    protected void LoginSubmitBtn_Click(object sender, EventArgs e)
    {
        if ((StuIDTextBox.Text == "") || (PassTextBox.Text == ""))
        {
            Response.Write("<SCRIPT language='javascript'>alert('学号或密码不能为空！！！'); </SCRIPT>");
        }
        else
        {
            //学号密码框不为空处理代码；
            string StuID = this.StuIDTextBox.Text;               //用户名 
            string StuPassword = this.PassTextBox.Text;   //密码框
            SqlConnection TeachingWebConn = new SqlConnection("server=LAPTOP-US3K8HUU;uid=sa;pwd=123456;database=DB_TeachingMS");
            TeachingWebConn.Open();         //数据库连接打开
            SqlCommand LoginCmd = new SqlCommand("SELECT * FROM TB_Teacher WHERE TeacherID='" + StuID + "' AND TPassword='" + StuPassword + "'", TeachingWebConn);
            SqlDataReader RsLogin = LoginCmd.ExecuteReader();
            RsLogin.Read();
            if (RsLogin.HasRows)
            {
                LoginOkLabel.Text = RsLogin["TeacherName"].ToString() + ",欢迎您登录成功！";
                this.LoginPanel.Visible = false;   //隐藏登录区域
                this.LoginOkPanel.Visible = true;    //显示登录成功区域
                Session["TeacherID"] = RsLogin["TeacherID"].ToString();
                Session["TeacherName"] = RsLogin["TeacherName"].ToString();
            }
            else
            {
                //学号或密码错误处理代码；
                Response.Write("<SCRIPT language='javascript'>alert('学号或密码错误！！！'); </SCRIPT>");

            }
            RsLogin.Close();                         //登录记录集关闭
            TeachingWebConn.Close();       //数据库连接关闭

        }

    }
}