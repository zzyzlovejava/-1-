﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class admin_StuEdit : System.Web.UI.Page
{
    //更新学生记录数据显示
    protected void Page_Load(object sender, EventArgs e)
    {
        //如果是第一次加载网页，则绑定页面上各个下拉框的数据
        if (!Page.IsPostBack)
        {
            //绑定下拉列表框中的数据
            DropDownListBind();

            //获取网页传递过来的要更新学生记录的学生学号的值
            string StuID = Request.QueryString["StuID"];

            //新建一个连接实例
            SqlConnection StuConn = new SqlConnection();

            //从Web.config文件获取数据库连接字符串
            StuConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            StuConn.Open();

            //新建StuDataSet对象，并将学生表中的数据填充到StuDataSet对象的表“StuTable”中
            SqlCommand StuCmd = new SqlCommand("SELECT * FROM TB_Student WHERE StuID=" + "'" + StuID + "'", StuConn);
            SqlDataAdapter StuDataAdapter = new SqlDataAdapter(StuCmd);
            DataSet StuDataSet = new DataSet();
            StuDataAdapter.Fill(StuDataSet, "StuTable");
            StuConn.Close();

            //将StuDataSet中"StuTable"表的Rows[i][j]，即第i行j列的值分别赋给相应的组件
            this.StuIDTextBox.Text = StuDataSet.Tables["StuTable"].Rows[0][0].ToString();
            this.StuNameTextBox.Text = StuDataSet.Tables["StuTable"].Rows[0][1].ToString();
            this.EnrollYearTextBox.Text = StuDataSet.Tables["StuTable"].Rows[0][2].ToString();
            this.GradYearTextBox.Text = StuDataSet.Tables["StuTable"].Rows[0][3].ToString();
            this.DeptIDDropDownList.SelectedValue = StuDataSet.Tables["StuTable"].Rows[0][4].ToString();
            this.ClassIDDropDownList.SelectedValue = StuDataSet.Tables["StuTable"].Rows[0][5].ToString();
            this.SexTextBox.Text = StuDataSet.Tables["StuTable"].Rows[0][6].ToString();
            this.BirthdayTextBox.Text = StuDataSet.Tables["StuTable"].Rows[0][7].ToString();
            this.PasswordTextBox.Text = StuDataSet.Tables["StuTable"].Rows[0][8].ToString();
            this.AddressTextBox.Text = StuDataSet.Tables["StuTable"].Rows[0][9].ToString();
            this.ZipCodeTextBox.Text = StuDataSet.Tables["StuTable"].Rows[0][10].ToString();
          
        }
    }


    //系部和班级下拉框数据绑定 
    private void DropDownListBind()
    {
        //新建一个连接实例
        SqlConnection DDLConn = new SqlConnection();

        //从Web.config文件获取数据库连接字符串
        DDLConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        DDLConn.Open();

        //将系部和班级两表中的数据填充到DDLDataSet对象的表“DeptTable”和“ClassTable”中
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


    //更新学生记录功能实现
    protected void InsertBtn_Click(object sender, EventArgs e)
    {
        //构建添加学生记录的UPDATE语句
        string StuUpdateSQL = "UPDATE TB_Student SET StuID=";
        StuUpdateSQL = StuUpdateSQL + "'" + this.StuIDTextBox.Text.Trim() + "',";
        StuUpdateSQL = StuUpdateSQL + "StuName='" + this.StuNameTextBox.Text.Trim() + "',";
        StuUpdateSQL = StuUpdateSQL + "EnrollYear='" + this.EnrollYearTextBox.Text.Trim() + "',";
        StuUpdateSQL = StuUpdateSQL + "GradYear='" + this.GradYearTextBox.Text.Trim() + "',";
        StuUpdateSQL = StuUpdateSQL + "DeptID='" + this.DeptIDDropDownList.SelectedValue + "',";
        StuUpdateSQL = StuUpdateSQL + "ClassID='" + this.ClassIDDropDownList.SelectedValue + "',";
        StuUpdateSQL = StuUpdateSQL + "Sex='" + this.SexTextBox.Text.Trim() + "',";
        StuUpdateSQL = StuUpdateSQL + "Birthday='" + this.BirthdayTextBox.Text.Trim() + "',";
        StuUpdateSQL = StuUpdateSQL + "SPassword='" + this.PasswordTextBox.Text.Trim() + "',";
        StuUpdateSQL = StuUpdateSQL + "StuAddress='" + this.AddressTextBox.Text.Trim() + "',";
        StuUpdateSQL = StuUpdateSQL + "ZipCode='" + this.ZipCodeTextBox.Text.Trim() + "' ";
        StuUpdateSQL = StuUpdateSQL + "WHERE StuID=" + "'" + Request.QueryString["StuID"] + "'";

        //创建并打开数据库连接，从Web.config从获取连接字符串
        SqlConnection StuUpdateConn = new SqlConnection();
        StuUpdateConn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        StuUpdateConn.Open();

        //执行UPDATE语句
        SqlCommand StuUpdateCmd = new SqlCommand(StuUpdateSQL, StuUpdateConn);
        StuUpdateCmd.ExecuteNonQuery();

        //关闭数据库连接
        StuUpdateConn.Close();

        //显示更新成功对话框，并链接到StuManage.aspx网页
        Response.Write("<script language='javascript'>alert('更新学生记录成功');location.href='StuManage.aspx';</script>");
    }

}