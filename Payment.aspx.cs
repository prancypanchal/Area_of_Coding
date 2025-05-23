﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Payment : System.Web.UI.Page
{
    SqlConnection con;
    public static String CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\wearingarea1.mdf;Integrated Security=True";
    public static Int32 OrderNumber = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["USERNAME"] != null)
        {
            if(!IsPostBack)
            {
                BindPriceData();
                BindPriceData2();
                genAutoNum();
                BindCartNumber();
                BindOrderProducts();
            }
        }
        else
        {
            Response.Redirect("~/signin.aspx");
        }
    }

    private void BindPriceData()
    {
        if (Request.Cookies["CartPID"] != null)
        {
            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');
            if (CookieDataArray.Length > 0)
            {
                DataTable dtBrands = new DataTable();
                Int64 CartTotal = 0;
                Int64 Total = 0;
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string PID = CookieDataArray[i].ToString().Split('-')[0];
                    string SizeID = CookieDataArray[i].ToString().Split('-')[0];

                    if (hdPidSizeID.Value != null && hdPidSizeID.Value != "")
                    {
                        hdPidSizeID.Value += "," + PID + "-" + SizeID;
                    }
                    else
                    {
                        hdPidSizeID.Value = PID + "-" + SizeID;
                    }


                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        using (SqlCommand cmd = new SqlCommand("select A.*,dbo.getSizeName(" + SizeID + ") as SizeNamee,"
                            + SizeID + " as SizeIDD,SizeData.Name,SizeData.Extention from tblProducts A cross apply( select top 1 B.Name,Extention from tblProductImages B where B.PID=A.PID ) SizeData where A.PID="
                            + PID + "", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                sda.Fill(dtBrands);
                            }

                        }
                    }
                    CartTotal += Convert.ToInt64(dtBrands.Rows[i]["PPrice"]);
                    Total += Convert.ToInt64(dtBrands.Rows[i]["PSelPrice"]);
                }
                divPriceDetails.Visible = true;

                spanCartTotal.InnerText = CartTotal.ToString();
                spanTotal.InnerText = "Rs. " + Total.ToString();
                spanDiscount.InnerText = "- " + (CartTotal - Total).ToString();

                hdCartAmount.Value = CartTotal.ToString();
                hdCartDiscount.Value = (CartTotal - Total).ToString();
                hdTotalPayed.Value = Total.ToString();
            }
            else
            {
                //TODO Show Empty Cart
                Response.Redirect("~/ProductsView.aspx");
            }
        }
        else
        {
            //TODO Show Empty Cart
          //  Response.Redirect("~/Payment.aspx");
        }

    }

    protected void btnPaytm_Click(object sender, EventArgs e)
    {
        if(Session["USERNAME"]!=null)
        {
            string USERID = Session["USERID"].ToString();
            string PaymentType = "Paytm";
            string PaymentStatus = "NotPaid";
            string EMAILID = Session["USEREMAIL"].ToString();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("insert into tblPurchase values('" + USERID + "','"
                    + hdPidSizeID.Value + "','" + hdCartAmount.Value + "','" + hdCartDiscount.Value + "','"
                    + hdTotalPayed.Value + "','" + PaymentType + "','" + PaymentStatus + "',getdate(),'"
                    + txtName.Text + "','" + txtAddress.Text + "','" + txtPinCode.Text + "','" + txtMobileNumber.Text + "') select SCOPE_IDENTITY()", con);


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                Int64 PurchaseID = Convert.ToInt64(cmd.ExecuteScalar());
            }
        }
        else
        {
            Response.Redirect("~/signin.aspx");
        }
    }
    private void BindPriceData2()
    {
        string UserIDD = Session["USERID"].ToString();
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SP_BindPriceData", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("UserID", UserIDD);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string Total = dt.Compute("Sum(SubSAmount)", "").ToString();
                    string CartTotal = dt.Compute("Sum(SubPAmount)", "").ToString();
                    string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                    int Total1 = Convert.ToInt32(dt.Compute("Sum(SubSAmount)", ""));
                    int CartTotal1 = Convert.ToInt32(dt.Compute("Sum(SubPAmount)", ""));
                    spanTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(Total)) + ".00";
                    Session["myCartAmount"] = string.Format("{0:####}", double.Parse(Total));
                    spanCartTotal.InnerText = "Rs. " + string.Format("{0:#,###.##}", double.Parse(CartTotal)) + ".00";
                    spanDiscount.InnerText = "- Rs. " + (CartTotal1 - Total1).ToString();
                    Session["TotalAmount"] = spanTotal.InnerText;
                    hdCartAmount.Value = CartTotal.ToString();
                    hdCartDiscount.Value = (CartTotal1 - Total1).ToString() + ".00";
                    hdTotalPayed.Value = Total.ToString();
                }
                else
                {
                    Response.Redirect("ProductsView.aspx");
                }
            }
        }
    }

    public void BindCartNumber()
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
                        //_ = CartBadge.InnerText == 0.ToString();
                    }
                }
            }
        }
    }
    private void genAutoNum()
    {
        Random r = new Random();
        int num = r.Next(Convert.ToInt32("231965"),
       Convert.ToInt32("987654"));
        string ChkOrderNum = num.ToString();
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SP_FindOrderNumber", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FindOrderNumber", ChkOrderNum);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    genAutoNum();
                }
                else
                {
                    OrderNumber = Convert.ToInt32(num.ToString());
                }
            }
        }
    }
    private void BindOrderProducts()
    {
        string UserIDD = Session["USERID"].ToString();
        DataTable dt = new DataTable();
        using (SqlConnection con0 = new SqlConnection(CS))
        {
            SqlCommand cmd0 = new SqlCommand("SP_BindCartProducts", con0)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd0.Parameters.AddWithValue("@UID", UserIDD);
            using (SqlDataAdapter sda0 = new SqlDataAdapter(cmd0))
            {
                sda0.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataColumn PID in dt.Columns)
                    {
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCart C WHERE C.PID=" + PID + " AND UID ='" + UserIDD + "'", con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    DataTable dtProducts = new DataTable();
                                    sda.Fill(dtProducts);
                                    gvProducts.DataSource = dtProducts;
                                    gvProducts.DataBind();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    protected void btnCart2_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }

    protected void BtnPlaceNPay_Click(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            Session["Address"] = txtAddress.Text;
            Session["Mobile"] = txtMobileNumber.Text;
            Session["OrderNumber"] = OrderNumber.ToString();
            Session["PayMethod"] = "Place n Pay";

            string USERID = Session["USERID"].ToString();
            string PaymentType = "PnP";
            string PaymentStatus = "NotPaid";
            string EMAILID = Session["USEREMAIL"].ToString();
            string OrderStatus = "Pending";
            string FullName = Session["getFullName"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand("SP_InsertOrder", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UserID", USERID);
                cmd1.Parameters.AddWithValue("@Email", EMAILID);
                cmd1.Parameters.AddWithValue("@CartAmount", hdCartAmount.Value);
                cmd1.Parameters.AddWithValue("@CartDiscount", hdCartDiscount.Value);
                cmd1.Parameters.AddWithValue("@TotalPaid", hdTotalPayed.Value);
                cmd1.Parameters.AddWithValue("@PaymentType", PaymentType);
                cmd1.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                cmd1.Parameters.AddWithValue("@DateOfPurchase", DateTime.Now);
                cmd1.Parameters.AddWithValue("@Name", FullName);
                cmd1.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd1.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text);
                cmd1.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                cmd1.Parameters.AddWithValue("@OrderNumber", OrderNumber.ToString());
                if (con.State == ConnectionState.Closed) { con.Open(); }
                Int64 OrderID = Convert.ToInt64(cmd1.ExecuteScalar());
                InsertOrderProducts();
            }
        }
        else
        {
            Response.Redirect("signin.aspx?RtPP=yes");
        }
    }
    private void InsertOrderProducts()
    {
        string USERID = Session["USERID"].ToString();
        using (SqlConnection con = new SqlConnection(CS))
        {
            foreach (GridViewRow gvr in gvProducts.Rows)
            {
                SqlCommand myCmd = new SqlCommand("SP_InsertOrderProducts", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                myCmd.Parameters.AddWithValue("@OrderID", OrderNumber.ToString());
                myCmd.Parameters.AddWithValue("@UserID", USERID);
                myCmd.Parameters.AddWithValue("@PID", gvr.Cells[0].Text);
                myCmd.Parameters.AddWithValue("@Products", gvr.Cells[1].Text);
                myCmd.Parameters.AddWithValue("@Quantity", gvr.Cells[2].Text);
                myCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString("yyyy-MM-dd"));
                myCmd.Parameters.AddWithValue("@Status", "Pending");
                if (con.State == ConnectionState.Closed) { con.Open(); }
                Int64 OrderProID = Convert.ToInt64(myCmd.ExecuteScalar());
                con.Close();
                EmptyCart();
                Response.Redirect("Success.aspx");
            }
        }
    }
    private void EmptyCart()
    {
        Int32 CartUIDD = Convert.ToInt32(Session["USERID"].ToString());
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmdU = new SqlCommand("SP_EmptyCart", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmdU.Parameters.AddWithValue("@UserID", CartUIDD);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            cmdU.ExecuteNonQuery();
            con.Close();
        }
    }
}