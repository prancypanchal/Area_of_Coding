using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AddSize : System.Web.UI.Page
{
    SqlConnection con;
    SqlConnection cmd;
    void mycon()
    {
        con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\wearingarea1.mdf;Integrated Security=True");
        con.Open();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBrand();
            BindMainCategory();
            BindSizeRepeater();
        }
    }

    private void BindSizeRepeater()
    {
        mycon();
       SqlCommand cmd = new SqlCommand("select A.*,B.*,C.*,D.*  from tblSizes A inner join tblCategory B on B.CatID = A.CategoryID inner join tblBrands C on C.BrandID=A.BrandID inner join tblSubCategory D on D.SubCatID=A.SubCategoryID", con);
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rptrSize.DataSource = dt;
                rptrSize.DataBind();
            }
        }

    }
    private void BindMainCategory()
    {
        mycon();
        SqlCommand cmd = new SqlCommand("Select * from tblCategory", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count != 0)
        {
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "CatName";
            ddlCategory.DataValueField = "CatID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));

        }
    }
    private void BindBrand()
    {

        mycon();
        SqlCommand cmd = new SqlCommand("Select * from tblBrands", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count != 0)
        {
            ddlBrand.DataSource = dt;
            ddlBrand.DataTextField = "Name";
            ddlBrand.DataValueField = "BrandID";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));

        }
    }
    protected void btnAddSize_Click(object sender, EventArgs e)
    {
        mycon();
       SqlCommand cmd = new SqlCommand("insert into tblSizes values(@Sname,@Bid,@Cid,@SCid)", con);
        {
            
            cmd.Parameters.AddWithValue("@Sname", txtSize.Text);
            cmd.Parameters.AddWithValue("@Bid", ddlBrand.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Cid",ddlCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@SCid", ddlSubCat.SelectedItem.Value);

            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Size Added Successfully')</script>");

            txtSize.Text = string.Empty;

            con.Close();
            ddlBrand.ClearSelection();
            ddlBrand.Items.FindByValue("0").Selected = true;

            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue("0").Selected = true;
            
            ddlSubCat.ClearSelection();
            ddlSubCat.Items.FindByValue("0").Selected = true;


        }
        BindSizeRepeater();


    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MainCategoryID=Convert.ToInt32(ddlCategory.SelectedItem.Value);
        {
            mycon();
            SqlCommand cmd = new SqlCommand("Select * from tblSubCategory Where MainCatId='" + ddlCategory.SelectedItem.Value + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlSubCat.DataSource = dt;
                ddlSubCat.DataTextField = "SubCatName";
                ddlSubCat.DataValueField = "SubCatID";
                ddlSubCat.DataBind();
                ddlSubCat.Items.Insert(0, new ListItem("-Select-", "0"));

            }



        }

    }
}