using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class addproduct : System.Web.UI.Page
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
            //when page first time run theen this code will execute
            BindBrand();
            BindCategory();
           
            ddlSubCategory.Enabled = false;

            BindGridview1();

        }

    }

    private void BindCategory()
    {
        mycon();
        SqlCommand cmd = new SqlCommand("Select * from tblCategory", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count != 0)
        {
            Category.DataSource = dt;
            Category.DataTextField = "CatName";
            Category.DataValueField = "CatID";
            Category.DataBind();
            Category.Items.Insert(0, new ListItem("-Select-", "0"));

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
   

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        mycon();
        SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PName",txtProductname.Text);
        cmd.Parameters.AddWithValue("@PPrice",txtPrice.Text);
        cmd.Parameters.AddWithValue("@PSelPrice", txtSellPrice.Text);
        cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@PCategoryID", Category.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
        cmd.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text);
        cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
        if(chFD.Checked==true)
        {
            cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
        }
        if (ch30Ret.Checked == true)
        {
            cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@30DayRet", 0.ToString());
        }
        if (chCOD.Checked == true)
        {
            cmd.Parameters.AddWithValue("@COD", 1.ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@COD", 0.ToString());
        }
        Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());
        cmd.ExecuteNonQuery();
        
        
        // insert size quantity

        for(int i=0; i<cbSize.Items .Count; i++)
        {
            if (cbSize.Items[i].Selected == true)
            {
                Int64 SizeID = Convert.ToInt64(cbSize.Items[i].Value);
                int Quantity = Convert.ToInt32(txtQuantity.Text);
                SqlCommand cmd1 = new SqlCommand("insert into tblProductsSizeQuantity values('" + PID + "','" + SizeID + "','" + Quantity + "')", con);
                cmd1.ExecuteNonQuery();
            }
        }
        // insert and Upload Images
        if(fuImg01.HasFile)
        {
            string SavePath = Server.MapPath("~/imagess/ProductsImages/")+PID;
            if(!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
            fuImg01.SaveAs(SavePath + "\\" + txtProductname.Text.ToString().Trim() + "01" + Extention);

            SqlCommand cmd2 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductname.Text.ToString().Trim() + "01" + "','" + Extention + "')", con);
            cmd2.ExecuteNonQuery();
        }
        //2nd upload img
        if (fuImg02.HasFile)
        {
            string SavePath = Server.MapPath("~/imagess/ProductsImages/") + PID;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg02.PostedFile.FileName);
            fuImg02.SaveAs(SavePath + "\\" + txtProductname.Text.ToString().Trim() + "02" + Extention);

            SqlCommand cmd3 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductname.Text.ToString().Trim() + "02" + "','" + Extention + "')", con);
            cmd3.ExecuteNonQuery();
        }
        //3rd upload img
        if (fuImg03.HasFile)
        {
            string SavePath = Server.MapPath("~/imagess/ProductsImages/") + PID;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg03.PostedFile.FileName);
            fuImg03.SaveAs(SavePath + "\\" + txtProductname.Text.ToString().Trim() + "03" + Extention);

            SqlCommand cmd4 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductname.Text.ToString().Trim() + "03" + "','" + Extention + "')", con);
            cmd4.ExecuteNonQuery();
        }
        //4th upload img
        if (fuImg04.HasFile)
        {
            string SavePath = Server.MapPath("~/imagess/ProductsImages/") + PID;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg04.PostedFile.FileName);
            fuImg04.SaveAs(SavePath + "\\" + txtProductname.Text.ToString().Trim() + "04" + Extention);

            SqlCommand cmd5 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductname.Text.ToString().Trim() + "04" + "','" + Extention + "')", con);
            cmd5.ExecuteNonQuery();
        }
        //5th upload img
        if (fuImg05.HasFile)
        {
            string SavePath = Server.MapPath("~/imagess/ProductsImages/") + PID;
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extention = Path.GetExtension(fuImg05.PostedFile.FileName);
            fuImg05.SaveAs(SavePath + "\\" + txtProductname.Text.ToString().Trim() + "05" + Extention);

           // SqlCommand cmd6 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductname.Text.ToString().Trim() + "05" + "','" + Extention + "')", con);
            //cmd6.ExecuteNonQuery();

            SqlCommand cmd7 = new SqlCommand("insert into tblProductImages(PID,Name,Extention) values(@PID,@Name,@Extention)", con);
            cmd7.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
            cmd7.Parameters.AddWithValue("@Name", txtProductname.Text.ToString().Trim() + "05");
            cmd7.Parameters.AddWithValue("@Extention", Extention);
            cmd7.ExecuteNonQuery();
            Response.Write("<script>alert('Brand Added Successfully')</script>");

            BindGridview1();

            Response.Redirect("AddProduct.aspx");
        }
    }

    protected void Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Category.SelectedIndex != 0)
        {
            ddlSubCategory.Enabled = true;
        }
        else
        {
            ddlSubCategory.Enabled = false;
        }
        int MainCategoryID = Convert.ToInt32(Category.SelectedItem.Value);
        {
            mycon();
            SqlCommand cmd = new SqlCommand("Select * from tblSubCategory Where MainCatId='" + Category.SelectedItem.Value + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "SubCatName";
                ddlSubCategory.DataValueField = "SubCatID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));

            } 
        }
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        mycon();
        SqlCommand cmd = new SqlCommand("Select * from tblSizes Where BrandID='" + ddlBrand.SelectedItem.Value + "' and CategoryID='" + Category.SelectedItem.Value + "' and SubCategoryID='" + ddlSubCategory.SelectedItem.Value + "'", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count != 0)
        {
            cbSize.DataSource = dt;
            cbSize.DataTextField = "SizeName";
            cbSize.DataValueField = "SizeID";
            cbSize.DataBind();

        }
    }
    private void BindGridview1()
    {
        mycon();
        SqlCommand cmd = new SqlCommand("select distinct t1.PID,t1.PName,t1.PPrice,t1.PselPrice,t2.Name as Brand,t3.CatName,t4.SubCatName,t6.SizeName,t8.Quantity from tblProducts as t1 inner join tblBrands as t2 on t2.BrandID=t1.PBrandID inner join tblCategory as t3 on t3.CatID=t1.PCategoryID inner join  tblSubCategory as t4 on t4.SubCatID=t1.PSubCatID inner join tblSizes as t6 on t6.SubCategoryID=t1.PSubCatID inner join tblProductsSizeQuantity as t8 on t8.PID=t1.PID order by t1.PName", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }


    }
}