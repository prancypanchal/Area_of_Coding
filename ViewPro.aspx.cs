﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Threading;
public partial class ViewPro : System.Web.UI.Page
{

    public static String CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\wearingarea1.mdf;Integrated Security=True";
    readonly Int32 myQty = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["PID"] != null)
        {
            if (!IsPostBack)
            {
                BindProductImage();
                BindProductImage2();
                BindProductDetails();
                BindCartNumber();
            }
        }
        else
        {
            Response.Redirect("~/ProductsView.aspx");
        }
    }

    private void BindProductDetails()
    {
        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SP_BindProductDetails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@PID", PID);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rptrProductDetalis.DataSource = dt;
                rptrProductDetalis.DataBind();
                Session["CartPID"] = Convert.ToInt32(dt.Rows[0]["PID"].ToString());
                Session["myPName"] = dt.Rows[0]["PName"].ToString();
                Session["myPPrice"] = dt.Rows[0]["PPrice"].ToString();
                Session["myPSelPrice"] = dt.Rows[0]["PSelPrice"].ToString();
            }
        }
    }
    private void BindProductImage()
    {
        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from tblProductImages where PID='" + PID + "'", con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrImage.DataSource = dt;
                    rptrImage.DataBind();
                }
            }
        }
    }
    private void BindProductImage2()
    {
        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SP_BindProductImages", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@PID", PID);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rptrImage.DataSource = dt;
                rptrImage.DataBind();
            }
        }
    }
    protected string GetActiveImgClass(int ItemIndex)
    {
        if (ItemIndex == 0)
        {
            return "active";
        }
        else
        {
            return "";
        }
    }
    protected void rptrProductDetalis_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string BrandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
            string CatID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
            string SubCatID = (e.Item.FindControl("hfSubCatID") as HiddenField).Value;

            RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;


            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from tblSizes where BrandID='" + BrandID + "' and CategoryID=" + CatID + " and SubCategoryID=" + SubCatID + "", con);
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rblSize.DataSource = dt;
                        rblSize.DataTextField = "SizeName";
                        rblSize.DataValueField = "SizeID";
                        rblSize.DataBind();
                    }
                }
            }
        }
    }
    protected void btnAddtoCart_Click(object sender, EventArgs e)
    {
        string SelectedSize = string.Empty;
        foreach (RepeaterItem item in rptrProductDetalis.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                var rbList = item.FindControl("rblSize") as RadioButtonList;
                SelectedSize = rbList.SelectedValue;
                var lblError = item.FindControl("lblError") as Label;
                lblError.Text = "";
            }
        }

        if (SelectedSize != "")
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            //if (Request.Cookies["CartPID"] != null)
            //{
            //    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
            //    CookiePID = CookiePID + "," + PID + "-" + SelectedSize;
            //    HttpCookie CartProducts = new HttpCookie("CartPID");
            //    CartProducts.Values["CartPID"] = CookiePID;
            //    CartProducts.Expires = DateTime.Now.AddDays(30);
            //    Response.Cookies.Add(CartProducts);
            //}
            //else
            //{
            //    HttpCookie CartProducts = new HttpCookie("CartPID");
            //    CartProducts.Values["CartPID"] = PID.ToString() + "-" + SelectedSize;
            //    CartProducts.Expires = DateTime.Now.AddDays(30);
            //    Response.Cookies.Add(CartProducts);
            //}
            AddToCartProduction();
            Response.Redirect("ViewPro.aspx?PID=" + PID);


        }
        else
        {
            foreach (RepeaterItem item in rptrProductDetalis.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "Please select a size";
                }
            }

        }
    }
    protected override void InitializeCulture()
    {
        CultureInfo ci = new CultureInfo("en-IN");
        ci.NumberFormat.CurrencySymbol = "₹";
        Thread.CurrentThread.CurrentCulture = ci;

        base.InitializeCulture();
    }

    private void BindCartNumber()
    {
        if (Session["USERID"] != null)
        {
            string UserIDD = Session["USERID"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SP_BindCartNumberz", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", UserIDD);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                        CartBadge.InnerText = CartQuantity;

                    }
                    else
                    {
                        CartBadge.InnerText = 0.ToString();
                    }
                }
            }
        }
    }

   
    
  
   
    //protected void btnAddtoCart_Click(object sender, EventArgs e)
    //{
    //    string SelectedSize = string.Empty;
    //    foreach (RepeaterItem item in rptrProductDetalis.Items)
    //    {
    //        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
    //        {
    //            var rbList = item.FindControl("rblSize") as RadioButtonList;
    //            SelectedSize = rbList.SelectedValue;
    //            var lblError = item.FindControl("lblError") as Label;
    //            lblError.Text = "";
    //        }
    //    }

    //    if (SelectedSize != "")
    //    {
    //        Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
    //        if (Request.Cookies["CartPID"] != null)
    //        {
    //            string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
    //            CookiePID = CookiePID + "," + PID + "-" + SelectedSize;
    //            HttpCookie CartProducts = new HttpCookie("CartPID");
    //            CartProducts.Values["CartPID"] = CookiePID;
    //            CartProducts.Expires = DateTime.Now.AddDays(30);
    //            Response.Cookies.Add(CartProducts);
    //        }
    //        else
    //        {
    //            HttpCookie CartProducts = new HttpCookie("CartPID");
    //            CartProducts.Values["CartPID"] = PID.ToString() + "-" + SelectedSize;
    //            CartProducts.Expires = DateTime.Now.AddDays(30);
    //            Response.Cookies.Add(CartProducts);
    //        }
    //        Response.Redirect("ViewPro.aspx?PID=" + PID);


    //    }
    //    else
    //    {
    //        foreach(RepeaterItem item in rptrProductDetalis.Items)
    //        {
    //            if(item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
    //            {
    //                var lblerror = item.FindControl("lblerror") as Label;
    //                lblerror.Text = "Please Select a Size";
    //            }
    //        }    
    //    }
    //}

   

    private void AddToCartProduction()
    {
        if (Session["Username"] != null)
        {
            Int32 UserID = Convert.ToInt32(Session["USERID"].ToString());
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_IsProductExistInCart", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PID", PID);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Int32 updateQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                        SqlCommand myCmd = new SqlCommand("SP_UpdateCart", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        myCmd.Parameters.AddWithValue("@Quantity", updateQty + 1);
                        myCmd.Parameters.AddWithValue("@CartPID", PID);
                        myCmd.Parameters.AddWithValue("@UserID", UserID);
                        Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                        BindCartNumber();
                        divSuccess.Visible = true;
                    }
                    else
                    {
                        SqlCommand myCmd = new SqlCommand("SP_InsertCart", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        myCmd.Parameters.AddWithValue("@UID", UserID);
                        myCmd.Parameters.AddWithValue("@PID", Session["CartPID"].ToString());
                        myCmd.Parameters.AddWithValue("@PName", Session["myPName"].ToString());
                        myCmd.Parameters.AddWithValue("@PPrice", Session["myPPrice"].ToString());
                        myCmd.Parameters.AddWithValue("@PSelPrice", Session["myPSelPrice"].ToString());
                        myCmd.Parameters.AddWithValue("@Qty", myQty);
                        Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                        con.Close();
                        BindCartNumber();
                        divSuccess.Visible = true;
                    }
                }
            }
        }
        else
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            Response.Redirect("signin.aspx?rurl=" + PID);
        }
    }

    protected void btnCart2_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }

}