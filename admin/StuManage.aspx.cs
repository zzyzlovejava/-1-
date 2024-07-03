using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class admin_StuManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //如果是第一次加载网页，则绑定页面上各个下拉框的数据 
        if (!Page.IsPostBack)
        {
            DropDownListBind();
            GridViewDataBind();
        }
    }


    //班级下拉框数据绑定
    private void DropDownListBind()
    {
        //新建一个连接实例
        SqlConnection DDLConn = new SqlConnection();

        //从Web.config文件获取数据库连接字符串
        DDLConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        DDLConn.Open();

        //并将班级表中的数据填充到DDLDataSet对象的表“ClassTable”中
        SqlCommand ClassCmd = new SqlCommand("SELECT ClassID,ClassName FROM TB_Class", DDLConn);
        SqlDataAdapter DeptDataAdapter = new SqlDataAdapter(ClassCmd);
        DataSet DDLDataSet = new DataSet();
        DeptDataAdapter.Fill(DDLDataSet, "ClassTable");

        //班级下拉框绑定
        this.ClassDDList.DataTextField = "ClassName";
        this.ClassDDList.DataValueField = "ClassID";
        this.ClassDDList.DataSource = DDLDataSet.Tables["ClassTable"];
        this.ClassDDList.DataBind();
        this.ClassDDList.Items.Insert(0, new ListItem("===所有班级===", "全部"));

        //关闭数据库连接
        DDLConn.Close();
    }


    //学生信息数据绑定到GridView
    private void GridViewDataBind()
    {
        SqlConnection StuConn = new SqlConnection();
        StuConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        StuConn.Open();
        SqlCommand StuSelectCmd = new SqlCommand("SELECT * FROM TB_Student", StuConn);
        SqlDataAdapter StuAdapter = new SqlDataAdapter(StuSelectCmd);
        DataSet StuDS = new DataSet();
        StuAdapter.Fill(StuDS, "StuTable");
        StuConn.Close();
        this.StuGView.DataSource = StuDS.Tables["StuTable"];
        this.StuGView.DataBind();
    }


    //学生信息按班级查询并绑定
    protected void QueryBtn_Click(object sender, EventArgs e)
    {
        string QuerySQL = "SELECT * FROM TB_Student";
        if (this.ClassDDList.SelectedValue != "全部")
        {
            QuerySQL += " WHERE ClassID='" + this.ClassDDList.SelectedValue + "'";
        }
        SqlConnection QueryConn = new SqlConnection();
        QueryConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        QueryConn.Open();
        SqlCommand QueryCmd = new SqlCommand(QuerySQL, QueryConn);
        SqlDataAdapter QueryAdapter = new SqlDataAdapter(QueryCmd);
        DataSet QueryDS = new DataSet();
        QueryAdapter.Fill(QueryDS);
        QueryConn.Close();
        this.StuGView.DataSource = QueryDS.Tables[0].DefaultView;
        this.StuGView.DataBind();
    }


    //学生信息记录删除功能实现 
    protected void StuGView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string StuID = this.StuGView.DataKeys[e.RowIndex].Value.ToString();
        SqlConnection DeleteConn = new SqlConnection();
        DeleteConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        DeleteConn.Open();
        SqlCommand DeleteCmd = new SqlCommand("DELETE FROM TB_Student WHERE StuID='" + StuID + "'", DeleteConn);
        DeleteCmd.ExecuteNonQuery();
        DeleteConn.Close();
        Response.Write("<script language='javascript'>alert('删除学生记录成功');</script>");
        GridViewDataBind();
    }


}