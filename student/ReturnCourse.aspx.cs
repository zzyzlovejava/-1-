using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ReturnCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //如果是第一次加载网页，则绑定页面上各个下拉框的数据 
        if (!Page.IsPostBack)
        {
            GridViewDataBind();
        }
    }
    private void GridViewDataBind()
    {
        //建立数据库连接，从Web.config文件获取数据库连接字符串
        SqlConnection StuCourseConn = new SqlConnection();
        StuCourseConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        StuCourseConn.Open();
        //调用存储过程
        SqlCommand StuCourseCmd = new SqlCommand("SP_StuSelectedCourse", StuCourseConn);
        //说明SqlCommand类型是个存储过程
        StuCourseCmd.CommandType = CommandType.StoredProcedure;
        //添加存储过程的参数,从全局Session变量获取学号值
        StuCourseCmd.Parameters.Add("@StuID", SqlDbType.Char, 8).Value = Session["StuID"].ToString();
        SqlDataAdapter StuGradeAdapter = new SqlDataAdapter(StuCourseCmd);
        //将SqlDataAdapter对象中的数据填充到DataSet对象的表"StuCourseTable"中
        DataSet StuCourseDS = new DataSet();
        StuGradeAdapter.Fill(StuCourseDS, "StuCourseTable");
        //关闭数据库连接
        StuCourseConn.Close();
        //绑定数据到GridView显示
        this.StuCourseGView.DataSource = StuCourseDS.Tables["StuCourseTable"];
        this.StuCourseGView.DataBind();
    }
    protected void StuCourseGView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //定义字符串变量“StuID、CourseClassID”，并获取对应的值
        string StuID = Session["StuID"].ToString();
        string CourseClassID = this.StuCourseGView.Rows[e.RowIndex].Cells[0].Text.ToString();
        //Response.Write(CourseClassID);
        SqlConnection DeleteConn = new SqlConnection();
        DeleteConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        DeleteConn.Open();
        SqlCommand DeleteCmd = new SqlCommand("DELETE FROM TB_SelectCourse WHERE StuID='" + StuID + "'" + " AND CourseClassID='" + CourseClassID + "'", DeleteConn);
        DeleteCmd.ExecuteNonQuery();
        DeleteConn.Close();
        Response.Write("<script language='javascript'>alert('课程退选成功');</script>");
        GridViewDataBind();
    }
    protected void StuCourseGView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}