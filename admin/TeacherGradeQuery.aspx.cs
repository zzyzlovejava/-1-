using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class TeacherGradeQuery : System.Web.UI.Page
{
    private void DropDownListBind()
    {
       //新建一个连接实例
       SqlConnection DDLConn = new SqlConnection();
       //从Web.config文件获取数据库连接字符串
       DDLConn.ConnectionString =  
       ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
       DDLConn.Open();
       //将教师表中的数据填充到DDLDataSet对象的表“TeacherTable”中 
       SqlCommand TeacherCmd = new SqlCommand("SELECT TeacherID,TeacherName FROM TB_Teacher", DDLConn);
       SqlDataAdapter TeacherDataAdapter = new SqlDataAdapter(TeacherCmd);
       DataSet DDLDataSet = new DataSet();
       TeacherDataAdapter.Fill(DDLDataSet,"TeacherTable");
       //教师下拉框绑定
       this.TeacherDDList.DataTextField = "TeacherName";
       this.TeacherDDList.DataValueField = "TeacherID";
       this.TeacherDDList.DataSource = DDLDataSet.Tables["TeacherTable"];
       this.TeacherDDList.DataBind();
       this.TeacherDDList.Items.Insert(0, new ListItem("===所有教师===", "全部"));
       //关闭数据库连接
       DDLConn.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //如果是第一次加载网页，则绑定页面上各个下拉框的数据 
        if (!Page.IsPostBack)
        {
            DropDownListBind();
        }
    }

    protected void TeacherDDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //新建一个连接实例
        SqlConnection CourseClassConn = new SqlConnection();
        //从Web.config文件获取数据库连接字符串
        CourseClassConn.ConnectionString =
        ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        CourseClassConn.Open();
        //调用存储过程“SP_CourseClassQuery”
        SqlCommand CourseClassCmd =
        new SqlCommand("SP_CourseClassQuery", CourseClassConn);
        //说明SqlCommand类型是个存储过程
        CourseClassCmd.CommandType = CommandType.StoredProcedure;
        //添加存储过程需要的参数
        CourseClassCmd.Parameters.Add("@TeacherID", SqlDbType.Char, 6).Value =
        this.TeacherDDList.SelectedValue.ToString();
        //新建DDLDataSet对象，并将课程班表中的数据填充到DDLDataSet对象的表“CourseClassTable”中
        SqlDataAdapter CourseClassDataAdapter = new
        SqlDataAdapter(CourseClassCmd);
        DataSet DDLDataSet = new DataSet();
        CourseClassDataAdapter.Fill(DDLDataSet, "CourseClassTable");
        //课程班下拉框绑定
        this.CourseClassDDList.DataTextField = "CCName";
        this.CourseClassDDList.DataValueField = "CourseClassID";
        this.CourseClassDDList.DataSource = DDLDataSet.Tables["CourseClassTable"];
        this.CourseClassDDList.DataBind();
        //关闭数据库连接
        CourseClassConn.Close();
    }

    protected void QueryBtn_Click(object sender, EventArgs e)
    {
        //新建一个连接实例
        SqlConnection CourseClassGradeConn = new SqlConnection();
        //从Web.config文件获取数据库连接字符串
        CourseClassGradeConn.ConnectionString =
        ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        CourseClassGradeConn.Open();
        //调用存储过程“SP_CourseClassGradeQuery”（参考任务1自行创建）
        SqlCommand CourseClassCmd = new SqlCommand("SP_CourseClassGradeQuery",
        CourseClassGradeConn);
        //说明SqlCommand类型是个存储过程
        CourseClassCmd.CommandType = CommandType.StoredProcedure;
        //添加存储过程需要的参数
        CourseClassCmd.Parameters.Add("@CourseClassID", SqlDbType.Char, 10).Value =
        this.CourseClassDDList.SelectedValue.ToString();
        //将成绩表中的数据填充到DDLDataSet对象的表“CCGradeTable”中
        SqlDataAdapter CourseClassDataAdapter = new SqlDataAdapter(CourseClassCmd);
        DataSet QueryDS = new DataSet();
        CourseClassDataAdapter.Fill(QueryDS, "CCGradeTable");
        //GradeGView数据绑定
        this.GradeGView.DataSource = QueryDS.Tables["CCGradeTable"];
        this.GradeGView.DataBind();
        //关闭数据库连接
        CourseClassGradeConn.Close();
    }
}