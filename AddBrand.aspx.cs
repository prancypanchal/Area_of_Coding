using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class AddBrand : System.Web.UI.Page
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
            BindBrandRepeater();
        }
    }

    private void BindBrandRepeater()
    {
        mycon();
        cmd = new SqlCommand("select * from tblBrands", con);
        {
            using(SqlDataAdapter sda=new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rptrBrands.DataSource = dt;
                rptrBrands.DataBind();
            }
        }
    }

    protected void btnAddBrand_Click(object sender, EventArgs e)
    {


        mycon();

        cmd = new SqlCommand("INSERT INTO tblBrands values(@name)", con);
        {
            cmd.Parameters.AddWithValue("@name", TxtBrand.Text);


            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Brand Added Successfully')</script>");

            TxtBrand.Text = string.Empty;

            con.Close();
            //lblmsg.Text = "Signup Successfully done";
            //lblmsg.ForeColor = System.Drawing.Color.Green;

            TxtBrand.Focus(); 

        }
        BindBrandRepeater();

    }
}