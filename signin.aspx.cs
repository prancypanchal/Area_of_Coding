using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class signin : System.Web.UI.Page
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
            if(Request.Cookies["UNAME"] != null && Request.Cookies["UPWD"] != null)
            {
                Txtusername.Text= Request.Cookies["UNAME"].Value;
                Txtpass.Text= Request.Cookies["UPWD"].Value;
                CheckBox1.Checked = true;
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        mycon();

        cmd = new SqlCommand("Select * from Signup where Username=@uname and password=@pwd ", con);
        {
            cmd.Parameters.AddWithValue("@uname", Txtusername.Text);
            cmd.Parameters.AddWithValue("@pwd", Txtpass.Text);
            cmd.Parameters.AddWithValue("@modifydate", System.DateTime.Now.ToString());

            //  Response.Write("<script>alert('login Successfully')</script>");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count !=0)
            {
                Session["USERID"] = dt.Rows[0]["Uid"].ToString();
                Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();

                if(CheckBox1.Checked)
                {
                    Response.Cookies["UNAME"].Value = Txtusername.Text;
                    Response.Cookies["UPWD"].Value = Txtpass.Text;
                    
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);

                }
                else
                {
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);

                }
               
                string Utype;

                Utype = dt.Rows[0][7].ToString().Trim();
               
                    if (Utype == "user")
                    {
                        Session["Username"] = Txtusername.Text;
                        Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();
                        Session["getFullName"] = dt.Rows[0]["FullName"].ToString();
                        Session["LoginType"] = "User";
                        if (Request.QueryString["rurl"] != null)
                            {
                                if(Request.QueryString["rurl"]=="cart")
                                {
                                    Response.Redirect("~/Cart.aspx");
                                }
                                if(Request.QueryString["rull"]=="PID")
                                {
                                    string myPID = Session["ReturnPID"].ToString();
                                    Response.Redirect("ViewPro.aspx?PID=" + myPID + "");
                                }
                    }
                        else
                        {
                            Response.Redirect("~/userhome.aspx?UserLogin=YES");
                        }
                    }

                    if (Utype == "Admin")
                    {
                        Session["Username"] = Txtusername.Text;
                        Session["LoginType"] = "Admin";
                        Response.Redirect("~/adminhomepage.aspx");
                    }
            }
            else
            {
                lblerror.Text = "Invalid username and password";
            }
            clr();
            con.Close();
            //lblmsg.Text = "Signup Successfully done";
            //lblmsg.ForeColor = System.Drawing.Color.Green;

        }
    }
 
private void clr()
    {
        Txtpass.Text = string.Empty;
        Txtusername.Text = string.Empty;
        Txtusername.Focus();

    }


}
