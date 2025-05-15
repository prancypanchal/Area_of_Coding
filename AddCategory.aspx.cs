using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AddCategory : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;



    void mycon()
    {
        con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\wearingarea1.mdf;Integrated Security=True");
        con.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategoryRepeater();
        }
    }

    private void BindCategoryRepeater()
    {
        mycon();
        cmd = new SqlCommand("select * from tblCategory", con);
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rptrCategory.DataSource = dt;
                rptrCategory.DataBind();
            }
        }
    }



    protected void btnAddCat_Click(object sender, EventArgs e)
    {
        mycon();

        cmd = new SqlCommand("INSERT INTO tblCategory values(@name)", con);
        {
            cmd.Parameters.AddWithValue("@name", txtCat.Text);


            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Category Added Successfully')</script>");

            txtCat.Text = string.Empty;

            con.Close();
            //lblmsg.Text = "Signup Successfully done";
            //lblmsg.ForeColor = System.Drawing.Color.Green;

            txtCat.Focus();

        }
        BindCategoryRepeater();

    }
}