using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class companyviewpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSourceID = null;
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }
   
    protected void appstatus_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "app_statusclick")
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=sample;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE CompanyMaster SET Status=@status WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("status", Convert.ToInt32("1"));
            cmd.Parameters.AddWithValue("id", Convert.ToInt32(e.CommandArgument));
            cmd.ExecuteNonQuery();
            GridView1.DataSourceID = null;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

    }
    protected void disstatus_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "dis_statusclick")
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=sample;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE CompanyMaster SET Status=@status WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("status", Convert.ToInt32("0"));
            cmd.Parameters.AddWithValue("id", Convert.ToInt32(e.CommandArgument));
            cmd.ExecuteNonQuery();
            GridView1.DataSourceID = null;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

    }
    protected void link_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "link_click")
        {
            string filename = e.CommandArgument.ToString();
            string extension = System.IO.Path.GetExtension(filename);
            string result = filename.Substring(0, filename.Length - extension.Length);
            Response.Clear();
            Response.ContentType = "Application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename='"+result+"'");
            Response.TransmitFile(Server.MapPath("~/upload/" + filename));
            Response.End();
        }

    }
    
  
}