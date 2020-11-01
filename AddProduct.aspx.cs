using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    Notifyuser obj = new Notifyuser();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        obj.notify();
    }
    protected void But_creatauction_Click(object sender, EventArgs e)
    {
       
        if (FileUpload1.HasFile)
        {
            string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (ext == ".jpg" || ext == ".png")
            {
                string path = Server.MapPath("documents//");
                FileUpload1.SaveAs(path + FileUpload1.FileName);
            }
            else
            {
                Response.Write("<h3>You can uplode only jpg or png files</h3>");
            }
        }
        else
        {
            Response.Write("<h3>Please select an file</h3>");
        }
        try
        {
            DateTime current = DateTime.Now;
            DateTime dat = Convert.ToDateTime(t1.Text);

            if (current.Date <= dat.Date)
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-PO2I391O;Initial Catalog=online_auction;Integrated Security=True");
                string name = "documents/" + FileUpload1.FileName;
                // DateTime dat = Convert.ToDateTime(t1.Text);
                DateTime ti = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector1.Hour, TimeSelector1.Minute, TimeSelector1.Second, TimeSelector1.AmPm));
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Table_products VALUES(@username,@category,@product_name,@product_des,@initial_price,@auc_date,@auc_time,@pro_image)", con);
                cmd.Parameters.AddWithValue("username", Session["id"].ToString());
                cmd.Parameters.AddWithValue("category", DropDownList_add_category.SelectedItem.Text);
                cmd.Parameters.AddWithValue("product_name", add_productname.Text);
                cmd.Parameters.AddWithValue("product_des", add_productdescription.Text);
                cmd.Parameters.AddWithValue("initial_price", Convert.ToInt32(add_initialprice.Text));
                cmd.Parameters.AddWithValue("auc_date", dat);
                cmd.Parameters.AddWithValue("auc_time", ti);
                cmd.Parameters.AddWithValue("pro_image", name);
                cmd.ExecuteNonQuery();
                con.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your auction created successfully!!!');", true);
                add_productname.Text = "";
                add_productdescription.Text = "";
                add_initialprice.Text = "";
            }
            else {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Choose valid Date!!!');", true);

            }

           
        }
        catch (Exception ae)
        {
           Response.Write("Exception:'" + ae.Message + "'");
        }
    }
  
}