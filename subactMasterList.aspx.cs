using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class subactMasterList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = DummyDB; Integrated Security = True");
            con.Open();
            string submasterid = Session["pk"].ToString();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_SubactMaster WHERE Branchid = @Branchid AND StartDate != ( SELECT AuditDate FROM tbl_AuditFileMaster WHERE SubactMasterId = @pk )", con);
            cmd.Parameters.AddWithValue("pk", submasterid);
            cmd.Parameters.AddWithValue("Branchid", Request.QueryString["branchid"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        
    }
}