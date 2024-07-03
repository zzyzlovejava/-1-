using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class admin_StuAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //如果是第一次加载网页，则绑定页面上各个下拉框的数据 
        if (!Page.IsPostBack)
        {
            DropDownListBind();
        }
    }


    //系部、班级下拉框数据绑定
    private void DropDownListBind()
    {
        //新建一个连接实例
        SqlConnection DDLConn = new SqlConnection();

        //从Web.config文件获取数据库连接字符串
        DDLConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        DDLConn.Open();

        //将两表中数据填充到DDLDataSet对象的表“DeptTable”和“ClassTable”中
        SqlCommand DeptCmd = new SqlCommand("SELECT DeptID,DeptName FROM TB_Dept", DDLConn);
        SqlDataAdapter DeptDataAdapter = new SqlDataAdapter(DeptCmd);
        SqlCommand ClassCmd = new SqlCommand("SELECT ClassID,ClassName FROM TB_Class", DDLConn);
        SqlDataAdapter ClassDataAdapter = new SqlDataAdapter(ClassCmd);
        DataSet DDLDataSet = new DataSet();
        DeptDataAdapter.Fill(DDLDataSet, "DeptTable");
        ClassDataAdapter.Fill(DDLDataSet, "ClassTable");

        //系部下拉框绑定 
        this.DeptIDDropDownList.DataTextField = "DeptName";
        this.DeptIDDropDownList.DataValueField = "DeptID";
        this.DeptIDDropDownList.DataSource = DDLDataSet.Tables["DeptTable"];
        this.DeptIDDropDownList.DataBind();

        //班级下拉框绑定
        this.ClassIDDropDownList.DataTextField = "ClassName";
        this.ClassIDDropDownList.DataValueField = "ClassID";
        this.ClassIDDropDownList.DataSource = DDLDataSet.Tables["ClassTable"];
        this.ClassIDDropDownList.DataBind();
        //关闭数据库连接
        DDLConn.Close();
    }


    protected void InsertBtn_Click(object sender, EventArgs e)
    {
        //构建添加学生记录的INSERT INTO语句 
        string StuInsertSQL = "INSERT INTO TB_Student(StuID, StuName, EnrollYear, GradYear, DeptID, ClassID, Sex, Birthday, SPassword, StuAddress, ZipCode, TotalCredit, TotalGrade) VALUES(";
        StuInsertSQL = StuInsertSQL + "'" + this.StuIDTextBox.Text.Trim() + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.StuNameTextBox.Text.Trim() + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.EnrollYearTextBox.Text.Trim() + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.GradYearTextBox.Text.Trim() + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.DeptIDDropDownList.SelectedValue + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.ClassIDDropDownList.SelectedValue + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.SexTextBox.Text.Trim() + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.BirthdayTextBox.Text.Trim() + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.PasswordTextBox.Text.Trim() + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.AddressTextBox.Text.Trim() + "',";
        StuInsertSQL = StuInsertSQL + "'" + this.ZipCodeTextBox.Text.Trim() + "',";
        StuInsertSQL = StuInsertSQL + "'0',";
        StuInsertSQL = StuInsertSQL + "'0')";

        //建立一个数据库连接，并从Web.config文件中获取连接字符串，并打开连接
        SqlConnection StuInsertConn = new SqlConnection();
        StuInsertConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        StuInsertConn.Open();

        //执行添加班级记录的SQL语句命令
        SqlCommand StuInsertCmd = new SqlCommand(StuInsertSQL, StuInsertConn);
        StuInsertCmd.ExecuteNonQuery();

        //关闭数据库连接
        StuInsertConn.Close();

        //班级记录添加成功后弹出成功对话框，并链接到新网页
        Response.Write("<script language='javascript'>alert('新增学生记录成功');location.href='StuManage.aspx';</script>");
    }



}