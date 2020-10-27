using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vdbsdemo
{
    public partial class VenderBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "subtact_list")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string vbranchid = commandArgs[0];
                string uid = commandArgs[1];
                string vendorid = commandArgs[2];
                Session["pk"] = uid;
                Response.Redirect("subactMasterList.aspx?branchid=" + vbranchid + "&vendorid=" + vendorid);

            }
        }
    }
}