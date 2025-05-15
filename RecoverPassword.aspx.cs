using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class RecoverPassword : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlCommand cmd2;

    /*MySqlDataAdapter da;
    DataSet ds;*/
    int Uid;
    DataTable dt = new DataTable();
    string GUIDvalue;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\wearingarea1.mdf;Integrated Security=True"))
        {
            GUIDvalue = Request.QueryString["id"];
            if (GUIDvalue != null)
            {
                con.Open();
                cmd = new SqlCommand("Select * from ForgotPass where Id=@Id ", con);
                cmd.Parameters.AddWithValue("@Id", GUIDvalue);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
                if(dt.Rows.Count !=0)
                {
                    Uid = Convert.ToInt32(dt.Rows[0][1]);
                }
                else
                {
                    lblmsg.Text = "Your Password Reset Link Is Expired Or Invalid...try again";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                Response.Redirect("~/shop1.aspx");
            }
        }

        if (!IsPostBack)
        {
            if(dt.Rows.Count!=0)
            {
                txtConfirmpassword.Visible = true;
                txtNewPass.Visible = true;
                lblnewpassword.Visible = true;
                lblconfirmpass.Visible = true;
                btnResetPass.Visible = true;
            }
            else
            {
                lblmsg.Text = "Your Password Reset Link Is Expired Or Invalid...try again";
                lblmsg.ForeColor = System.Drawing.Color.Red;

            }
        }
    }

    protected void btnResetPass_Click(object sender, EventArgs e)
    {
        if(txtNewPass.Text!="" && txtConfirmpassword.Text !="" && txtNewPass.Text== txtConfirmpassword.Text)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\wearingarea.mdf;Integrated Security=True"))
            {
                con.Open();
                cmd = new SqlCommand("Update Signup set Password=@p where Uid=@Uid", con);
                cmd.Parameters.AddWithValue("@p", txtNewPass.Text);
                cmd.Parameters.AddWithValue("@Uid", Uid);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert('Password Reset Successfully done');  </script>");


                cmd2 = new SqlCommand("delete from ForgotPass where Uid='" + Uid + "'", con);
                cmd2.ExecuteNonQuery();
                Response.Write("<script> alert('Password Reset Successfully done');  </script>");
                Response.Redirect("~/signin.aspx");

            }
        }
    }
}