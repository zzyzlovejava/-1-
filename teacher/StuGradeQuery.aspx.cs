using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class StuGradeQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //从全局Session变量获取教师的编号和姓名
        TeaIDNameLabel.Text = "<教师编号：" + Session["TeacherID"].ToString() + " &nbsp;&nbsp;&nbsp;   姓名：" + Session["TeacherName"].ToString() + ">";
        //建立数据库连接，从Web.config文件获取数据库连接字符串
        SqlConnection StuGradeConn = new SqlConnection();
        StuGradeConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        StuGradeConn.Open();
        //创建查询SQL语句，并用SqlDataAdapter对象获取数据 
        SqlCommand StuGradeCmd = new SqlCommand("SElECT TB_CourseClass.CourseClassID 课程班编号, TB_Course.CourseName 课程名, AVG (TB_Grade.TotalScore) AS 平均成绩 FROM TB_CourseClass JOIN TB_Course ON TB_CourseClass.CourseID = TB_Course.CourseID AND TeacherID = '" + Session["TeacherID"].ToString() + "'" + "JOIN TB_Grade ON TB_CourseClass.CourseClassID = TB_Grade.CourseClassID GROUP BY TB_CourseClass.CourseClassID, TB_Course.CourseName", StuGradeConn);
        SqlDataAdapter StuGradeAdapter = new SqlDataAdapter(StuGradeCmd);
        //将SqlDataAdapter对象中的数据填充到DataSet对象的表"StuGradeTable"中
        DataSet StuGradeDS = new DataSet();
        StuGradeAdapter.Fill(StuGradeDS, "StuGradeTable");
        //关闭数据库连接
        StuGradeConn.Close();
        //绑定数据到GridView显示
        this.StuGradeGView.DataSource = StuGradeDS.Tables["StuGradeTable"];
        this.StuGradeGView.DataBind();
    }
}