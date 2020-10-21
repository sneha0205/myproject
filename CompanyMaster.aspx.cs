using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class CompanyMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       FileUpload1.Attributes["multiple"] = "multiple";
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=sample;Integrated Security=True");
        con.Open();
        string query2 = "Select @@Identity";
        int ID;
        SqlCommand cmd = new SqlCommand("INSERT INTO CompanyMaster VALUES(@Name,@Status)", con);
        cmd.Parameters.AddWithValue("Name", name.Text);
        cmd.Parameters.AddWithValue("Status", "null");
        cmd.ExecuteNonQuery();
        cmd.CommandText = query2;
        ID = Convert.ToInt32(cmd.ExecuteScalar());
          // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Updated Successfully!!!');", true);        
        for (int i = 0; i < Request.Files.Count; i++)
        {
            try
            {
                HttpPostedFile fu = Request.Files[i];
                if (fu.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fu.FileName);
                    fu.SaveAs(Server.MapPath("~/upload/") + fileName);
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO FileMaster VALUES(@FileName,@CompanyId)", con);
                    cmd1.Parameters.AddWithValue("FileName", fileName);
                    cmd1.Parameters.AddWithValue("CompanyId", ID);
                    cmd1.ExecuteNonQuery();
                    cmd1.Parameters.Clear();
                }

            }
            catch (Exception ex)
            {
              ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error!!!');", true);        
            }
        }
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Inserted!!!');", true);
        name.Text = "";
          
    }
}