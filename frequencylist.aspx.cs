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
    public partial class frequencylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            int frequency;
            DateTime start_date, current_date;
            current_date = DateTime.Now.Date;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DummyDb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_SubactMaster WHERE pk = @pk ", con);
            cmd.Parameters.AddWithValue("pk", Request.QueryString["pk"]);
            SqlDataReader s1 = cmd.ExecuteReader();
            s1.Read();
            frequency = Convert.ToInt32(s1["Frequency"]);
            start_date = Convert.ToDateTime(s1["StartDate"]).Date;
            s1.Close();
            DataTable t = new DataTable("fre");
            t.Columns.Add("pk");
            t.Columns.Add("Vendorid");
            t.Columns.Add("Branchid");
            t.Columns.Add("PurposeofAct");
            t.Columns.Add("Frequency");
            t.Columns.Add("StartDate");
            t.Columns.Add("Valid");
            do
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM tbl_SubactMaster WHERE pk = @pk AND @c NOT IN ( SELECT AuditDate FROM tbl_AuditFileMaster WHERE SubactMasterId = @pk)", con);
                cmd1.Parameters.AddWithValue("pk", Request.QueryString["pk"]);
                cmd1.Parameters.AddWithValue("c", start_date);
                s1 = cmd1.ExecuteReader();
                s1.Read();
                if (s1.HasRows)
                {
                   // Response.Write(start_date);
                    t.Rows.Add(s1["pk"], s1["Vendorid"], s1["Branchid"], s1["PurposeOfAct"], s1["Frequency"], start_date, s1["Valid"]);
                }
                s1.Close();
                //Response.Write(start_date);
                start_date = start_date.AddMonths(frequency).Date;
                cmd1.Parameters.Clear();
            } while (start_date < current_date);
            DataSet ds = new DataSet();
            ds.Tables.Add(t);
            GridView1.DataSource = ds;
            int total = ds.Tables[0].Rows.Count;
            if (total < 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('No Data Present');", true);
            }
            GridView1.DataBind();
            

        }
    }
}