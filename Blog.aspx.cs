using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Blog : System.Web.UI.Page
{
    public static String CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\wearingarea1.mdf;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBlogPosts();
        }
    }
    private void BindBlogPosts()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            string query = "SELECT Title, Content, DatePosted FROM BlogPosts ORDER BY DatePosted DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            rptBlogPosts.DataSource = cmd.ExecuteReader();
            rptBlogPosts.DataBind();
        }
    }
}

