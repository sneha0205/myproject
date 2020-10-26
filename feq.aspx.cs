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
            int frequency;
            DateTime new_date, start_date;
            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = DummyDB; Integrated Security = True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_SubactMaster WHERE pk = @pk ", con);
            cmd.Parameters.AddWithValue("pk", Request.QueryString["pk"]);
            SqlDataReader s1 = cmd.ExecuteReader();
            s1.Read();
            frequency = Convert.ToInt32(s1["Frequency"]);
            start_date = Convert.ToDateTime(s1["StartDate"]).Date;
            new_date = start_date.AddMonths(frequency).Date;
            s1.Close();
            DataTable t = new DataTable("fre");
            t.Columns.Add("pk");
            t.Columns.Add("vendorid");
            t.Columns.Add("Branchid");
            t.Columns.Add("purposeofAct");
            t.Columns.Add("Frequency");
            t.Columns.Add("StartDate");
            t.Columns.Add("Valid");
            string branchid = Session["branchid"].ToString();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM tbl_SubactMaster WHERE Branchid = @Branchid AND @c != ( SELECT AuditDate FROM tbl_AuditFileMaster WHERE SubactMasterId = @pk)", con);
            cmd1.Parameters.AddWithValue("pk", Request.QueryString["pk"]);
            cmd1.Parameters.AddWithValue("Branchid", branchid);
            cmd1.Parameters.AddWithValue("c", new_date);
            s1 = cmd1.ExecuteReader();
            s1.Read();
            if(s1.HasRows)
            {
                t.Rows.Add(s1["pk"], s1["Vendorid"], s1["Branchid"], s1["PurposeOfAct"], s1["Frequency"], new_date, s1["Valid"]);
            }
            s1.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM tbl_SubactMaster WHERE pk = @pk AND @c != ( SELECT AuditDate FROM tbl_AuditFileMaster WHERE SubactMasterId = @pk)", con);
            cmd2.Parameters.AddWithValue("pk", Request.QueryString["pk"]);
            cmd2.Parameters.AddWithValue("c", start_date);
            s1 = cmd2.ExecuteReader();
            s1.Read();
            if(s1.HasRows)
            {
                t.Rows.Add(s1["pk"], s1["Vendorid"], s1["Branchid"], s1["PurposeOfAct"], s1["Frequency"], s1["StartDate"], s1["Valid"]);
            }
            s1.Close();
            DataSet ds = new DataSet();
            ds.Tables.Add(t);
            GridView1.DataSource = ds;
            int total = ds.Tables[0].Rows.Count;
            if(total < 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('No Data Present');", true);
            }
            GridView1.DataBind();

        }
    }
}