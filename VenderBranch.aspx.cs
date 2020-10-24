using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
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
                Session["pk"] = uid;
                Response.Redirect("subactMasterList.aspx?branchid=" + vbranchid); 

            }
        }
        protected void GridView_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sub_list")
            {

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string vbranchid = commandArgs[0];
                string uid = commandArgs[1];
                Session["branchid"] = vbranchid;
                Response.Redirect("feq.aspx?pk=" + uid) ;

            }
        }
    }
}