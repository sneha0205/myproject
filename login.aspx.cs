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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void But_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = DummyDB; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("select * from tbl_VendorMaster where Id=@id and VendorName=@name", con);
            cmd.Parameters.AddWithValue("id", Text_id.Text);
            cmd.Parameters.AddWithValue("name", Text_vendername.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                Session["id"] = Text_id.Text;
                Response.Redirect("VenderBranch.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(),"alert", "alert('Incorrect Id or VenderName');", true);
                Text_id.Text = "";
                Text_vendername.Text = "";
            }
        }
    }
}