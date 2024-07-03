using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ClassStuGradeQuery : System.Web.UI.Page
{
    private void DropDownListBind()
    {
        //新建一个连接实例
        SqlConnection DDLConn = new SqlConnection();
        //从Web.config文件获取数据库连接字符串
        DDLConn.ConnectionString =
        ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        DDLConn.Open();

        SqlCommand TeacherCmd = new SqlCommand("SELECT ClassID, ClassName FROM TB_Class", DDLConn);
        SqlDataAdapter TeacherDataAdapter = new SqlDataAdapter(TeacherCmd);
        DataSet DDLDataSet = new DataSet();
        TeacherDataAdapter.Fill(DDLDataSet, "StuTable");
        //教师下拉框绑定
        this.cls.DataTextField = "ClassName";
        this.cls.DataValueField = "ClassID";
        this.cls.DataSource = DDLDataSet.Tables["StuTable"];
        this.cls.DataBind();
        this.cls.Items.Insert(0, new ListItem("===所有班级===", "全部"));
        //关闭数据库连接
        DDLConn.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownListBind();
        }
    }

    protected void cls_SelectedIndexChanged(object sender, EventArgs e)
    {
        //新建一个连接实例
        SqlConnection CourseClassConn = new SqlConnection();
        //从Web.config文件获取数据库连接字符串
        CourseClassConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        CourseClassConn.Open();
        // 调用存储过程“SP_StuQuery”
        SqlCommand CourseClassCmd = new SqlCommand("SP_StuQuery", CourseClassConn);
        //说明SqlCommand类型是个存储过程
        CourseClassCmd.CommandType = CommandType.StoredProcedure;
        //添加存储过程需要的参数
        CourseClassCmd.Parameters.Add("@ClassID", SqlDbType.Char, 8).Value = this.cls.SelectedValue.ToString();
        //新建DDLDataSet对象，并将课程班表中的数据填充到DDLDataSet对象的表“CourseClassTable”中
        SqlDataAdapter CourseClassDataAdapter = new SqlDataAdapter(CourseClassCmd);
        DataSet DDLDataSet = new DataSet();
        CourseClassDataAdapter.Fill(DDLDataSet, "StuTable");
        //课程班下拉框绑定
        this.student.DataTextField = "StuName";
        this.student.DataValueField = "CCName";
        this.student.DataSource = DDLDataSet.Tables["StuTable"];
        this.student.DataBind();
        //关闭数据库连接
        CourseClassConn.Close();
    }


     protected void btnQuery_Click(object sender, EventArgs e)
     {
         //新建一个连接实例
         SqlConnection CourseClassGradeConn = new SqlConnection();
         //从Web.config文件获取数据库连接字符串
         CourseClassGradeConn.ConnectionString =
         ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
         CourseClassGradeConn.Open();
         //调用存储过程“SP_CourseClassGradeQuery”（参考任务1自行创建）
         SqlCommand CourseClassCmd = new SqlCommand("SP_StuGradeQuery",
         CourseClassGradeConn);
         //说明SqlCommand类型是个存储过程
         CourseClassCmd.CommandType = CommandType.StoredProcedure;
         //添加存储过程需要的参数
         CourseClassCmd.Parameters.Add("@StuID", SqlDbType.Char, 12).Value =
         this.student.SelectedValue.ToString();
         //将成绩表中的数据填充到DDLDataSet对象的表“CCGradeTable”中
         SqlDataAdapter CourseClassDataAdapter = new SqlDataAdapter(CourseClassCmd);
         DataSet QueryDS = new DataSet();
         CourseClassDataAdapter.Fill(QueryDS, "CCTable");
         //GradeGView数据绑定
         this.GradeGView.DataSource = QueryDS.Tables["CCTable"];
         this.GradeGView.DataBind();
         //关闭数据库连接
         CourseClassGradeConn.Close();
     }

        
}