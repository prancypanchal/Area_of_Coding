using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AddSubCat : System.Web.UI.Page
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
        if(!IsPostBack)
        {
            BindMainCat();
            BindsubCatRepeater();
        }
    }

    private void BindsubCatRepeater()
    {
        mycon();
        cmd = new SqlCommand("select A.*,B.* from tblSubCategory A inner join tblCategory B on B.CatID=A.MainCatId", con);
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rptrSubCategory.DataSource = dt;
                rptrSubCategory.DataBind();
            }
        }

    }

    protected void btnAddSubCat_Click(object sender, EventArgs e)
    {
        mycon();

        cmd = new SqlCommand("INSERT INTO tblSubCategory values(@name,@mainCAtid)", con);
        {
            cmd.Parameters.AddWithValue("@name", txtSubCat.Text);
            cmd.Parameters.AddWithValue("@mainCAtid", ddlMainCatID.Text);


            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Sub Category Added Successfully')</script>");

            txtSubCat.Text = string.Empty;

            con.Close();
            //lblmsg.Text = "Signup Successfully done";
            //lblmsg.ForeColor = System.Drawing.Color.Green;
            ddlMainCatID.ClearSelection();
            ddlMainCatID.Items.FindByValue("0").Selected = true;


        }
        BindsubCatRepeater();

    }
    private void BindMainCat()
    {
        mycon();
            SqlCommand cmd = new SqlCommand("Select * from tblCategory", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlMainCatID.DataSource = dt;
                ddlMainCatID.DataTextField = "CatName";
                ddlMainCatID.DataValueField = "CatID";
                ddlMainCatID.DataBind();
                ddlMainCatID.Items.Insert(0, new ListItem("-Select-", "0"));

            }

        


    }
}