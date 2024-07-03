using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string loginSuccess = Request.QueryString["loginSuccess"];
            if (loginSuccess != null && loginSuccess.Equals("true"))
            {
                string code = Session["code"].ToString();
                this.LoginPanel.Visible = false;   //隐藏登录区域
                if (code.Equals("1"))
                {
                    // 如果LoginOkPanel的可见性的标识存在且为true，则将Panel1的Visible属性设置为true
                    this.LoginOkPanel.Visible = true;
                    LoginOKLabel.Text = Session["name"].ToString();
                }
                if (code.Equals("2"))
                {
                    // 如果Panel1的可见性的标识存在且为true，则将Panel1的Visible属性设置为true
                    this.Panel1.Visible = true;
                    Label1.Text = Session["name"].ToString();
                }
                if (code.Equals("3"))
                {
                    // 如果Panel11的可见性的标识存在且为true，则将Panel1的Visible属性设置为true
                    this.Panel11.Visible = true;
                    Label11.Text = Session["name"].ToString();
                }
            }
        }
    }

    // 处理重置按钮点击事件的代码
    protected void LoginReset_Click(object sender, EventArgs e)
    {
        StuIDTextBox.Text = "";
        PassTextBox.Text = "";
    }

    // 处理登录按钮点击事件的代码
    protected void LoginSubmit_Click(object sender, EventArgs e)
    {
        Session["code"] = 0;
        string selectedRole = UserRoleRadio.SelectedValue;
        if (string.IsNullOrEmpty(StuIDTextBox.Text) || string.IsNullOrEmpty(PassTextBox.Text))
        {
            Response.Write("<script language='javascript'>alert('账号或密码不能为空！！！');</script>");
        }
        else
        {
            // 执行管理员登录逻辑
            if (selectedRole == "Admin")
            {
                string TeacherID = this.StuIDTextBox.Text;        //用户名 
                string TeacherPassword = this.PassTextBox.Text;   //密码框
                string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection TeachingWebConn = new SqlConnection(connectionString);
                TeachingWebConn.Open();         //数据库连接打开
                SqlCommand LoginCmd = new SqlCommand("SELECT * FROM TB_Teacher WHERE TeacherID='" + TeacherID + "' AND TPassword='" + TeacherPassword + "'", TeachingWebConn);
                SqlDataReader RsLogin = LoginCmd.ExecuteReader();
                RsLogin.Read();
                if (RsLogin.HasRows)
                {
                    // 登录成功后将教师ID存储到 Session 中
                    Session["TeacherID"] = TeacherID; // 替换为实际的教师ID
                    Label11.Text = RsLogin["TeacherName"].ToString() + ",欢迎您！";
                    Session["name"] = Label11.Text;
                    Session["code"] = 3;
                    this.LoginPanel.Visible = false;   //隐藏登录区域
                    this.Panel11.Visible = true;    //显示登录成功区域
                }
                else
                {
                    //学号或密码错误处理代码；
                    Response.Write("<SCRIPT language='javascript'>alert('账号或密码错误！！！'); </SCRIPT>");
                }
                RsLogin.Close();                         //登录记录集关闭
                TeachingWebConn.Close();       //数据库连接关闭
            }
            // 执行教师登录逻辑
            else if (selectedRole == "Teacher")
            {
                string TeacherID = this.StuIDTextBox.Text;        //用户名 
                string TeacherPassword = this.PassTextBox.Text;   //密码框
                string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection TeachingWebConn = new SqlConnection(connectionString);
                TeachingWebConn.Open();         //数据库连接打开
                SqlCommand LoginCmd = new SqlCommand("SELECT * FROM TB_Teacher WHERE TeacherID='" + TeacherID + "' AND TPassword='" + TeacherPassword + "'", TeachingWebConn);
                SqlDataReader RsLogin = LoginCmd.ExecuteReader();
                RsLogin.Read();
                if (RsLogin.HasRows)
                {
                    // 登录成功后将教师ID存储到 Session 中
                    Session["TeacherID"] = TeacherID; // 替换为实际的教师ID
                    Label1.Text = RsLogin["TeacherName"].ToString() + ",欢迎您！";
                    Session["name"] = Label1.Text;
                    Session["TeacherName"] = RsLogin["TeacherName"];
                    Session["code"] = 2;
                    this.LoginPanel.Visible = false;   //隐藏登录区域
                    this.Panel1.Visible = true;    //显示登录成功区域
                }
                else
                {
                    //学号或密码错误处理代码；
                    Response.Write("<SCRIPT language='javascript'>alert('账号或密码错误！！！'); </SCRIPT>");
                }
                RsLogin.Close();                         //登录记录集关闭
                TeachingWebConn.Close();       //数据库连接关闭
            }
            // 执行学生登录逻辑
            else if (selectedRole == "Student")
            {
                string StuID = StuIDTextBox.Text;
                string StuPassword = PassTextBox.Text;
                SqlConnection TeachingWebConn = new SqlConnection("server=127.0.0.1;uid=sa;pwd=123456;database=DB_TeachingMS");
                TeachingWebConn.Open();
                SqlCommand LoginCmd = new SqlCommand("SELECT * FROM TB_Student WHERE StuID=@StuID AND SPassword=@StuPassword", TeachingWebConn);
                LoginCmd.Parameters.AddWithValue("@StuID", StuID);
                LoginCmd.Parameters.AddWithValue("@StuPassword", StuPassword);
                SqlDataReader RsLogin = LoginCmd.ExecuteReader();
                if (RsLogin.Read())
                {
                    // 登录成功，将学生学号存储到 Session 中
                    Session["StuID"] = StuID;
                    LoginOKLabel.Text = RsLogin["StuName"].ToString() + ",欢迎您！";
                    Session["name"] = LoginOKLabel.Text;
                    Session["StuName"] = RsLogin["StuName"];
                    Session["code"] = 1;
                    LoginPanel.Visible = false;
                    LoginOkPanel.Visible = true;
                }
                else
                {
                    Response.Write("<SCRIPT language='javascript'>alert('学号或密码错误！！！'); </SCRIPT>");
                }
                RsLogin.Close();
                TeachingWebConn.Close();
            }
            else
            {
                // 默认情况下的处理逻辑

            }
        }
    }

}