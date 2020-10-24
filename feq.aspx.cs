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
    public partial class feq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int a;
            DateTime d,c;
            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = DummyDB; Integrated Security = True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Frequency FROM tbl_SubactMaster WHERE pk = @pk ", con);
            cmd.Parameters.AddWithValue("pk", Request.QueryString["pk"]);
            a = Convert.ToInt32(cmd.ExecuteScalar());
            SqlCommand cmd1 = new SqlCommand("SELECT StartDate FROM tbl_SubactMaster WHERE pk = @pk ", con);
            cmd1.Parameters.AddWithValue("pk", Request.QueryString["pk"]);
            d = Convert.ToDateTime(cmd1.ExecuteScalar()).Date;
            c = d.AddMonths(a).Date;
            string submasterid = Session["branchid"].ToString();
            SqlCommand cmd3 = new SqlCommand("SELECT * FROM tbl_SubactMaster WHERE Branchid = @Branchid AND @c != ( SELECT AuditDate FROM tbl_AuditFileMaster WHERE SubactMasterId = @pk)", con);
            cmd3.Parameters.AddWithValue("pk", Request.QueryString["pk"]);
            cmd3.Parameters.AddWithValue("Branchid", submasterid);
            cmd3.Parameters.AddWithValue("c", c);
            SqlDataAdapter sda = new SqlDataAdapter(cmd3);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
    }
}