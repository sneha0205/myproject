using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace vdbsdemo
{
    public partial class SubactMasterList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DummyDb;Integrated Security=True");
            con.Open();
            string submasterid = Session["pk"].ToString();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_SubactMaster WHERE Branchid = @Branchid AND Vendorid = @vendorid AND StartDate NOT IN ( SELECT AuditDate FROM tbl_AuditFileMaster WHERE SubactMasterId = @pk )", con);
            cmd.Parameters.AddWithValue("pk", submasterid);
            cmd.Parameters.AddWithValue("Branchid", Request.QueryString["branchid"]);
            cmd.Parameters.AddWithValue("vendorid", Request.QueryString["vendorid"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void GridView1_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "fre_list")
            {
                Response.Redirect("frequencylist.aspx?pk=" +e.CommandArgument);
            }
        }
    }
}