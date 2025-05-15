using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdminlogout_Click2(object sender, EventArgs e)
    {
        Response.Redirect("~/signin.aspx");
        Session["Username"] = null;
    }
}
