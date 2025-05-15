using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class signup : System.Web.UI.Page
{
    SqlConnection con;
   SqlCommand cmd;
    /*MySqlDataAdapter da;
    DataSet ds;*/

    void mycon()
    {
        con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\wearingarea1.mdf;Integrated Security=True");
         con.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtsignup_Click(object sender, EventArgs e)
    {

        if (isformvalid())
        {

            mycon();

            cmd = new SqlCommand("INSERT INTO Signup values(@username, @FullName, @Email, @Password, @ConfirmPassword, @modifydate, @usertype)", con);
            {
             cmd.Parameters.AddWithValue("@username", txtuname.Text);
            cmd.Parameters.AddWithValue("@FullName", TxtName.Text);
            cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", txtpass.Text); 
            cmd.Parameters.AddWithValue("@ConfirmPassword", txtcpass.Text);
            cmd.Parameters.AddWithValue("@modifydate", System.DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@usertype", "user");


               cmd.ExecuteNonQuery();
          Response.Write("<script>alert('SignUp Successfully')</script>");
            /*   using (MySqlConnection con = new MySqlConnection("server = localhost; user id = root; database = wearingarea"))
              
                   con.Open();
                   MySqlCommand cmd = new MySqlCommand("Insert into signup(Username,Email,Password,ConfirmPassword) Values('" + txtuname.Text + "','" + TxtName.Text + "','" + TxtEmail.Text + "','" + txtpass.Text + "','" + txtcpass  + "')", con);
                   cmd.ExecuteNonQuery();

                   Response.Write("<script> alert('Registration Successfully done');  </script>");*/
            clr();
                con.Close();
                lblmsg.Text = "Signup Successfully done";
                lblmsg.ForeColor = System.Drawing.Color.Green;

            }
            Response.Redirect("~/signin.aspx");
        }
        else
        {
            Response.Write("<script> alert('Signup failed');  </script>");
            lblmsg.Text = "all fields are mandatory";
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }

    }

    private bool isformvalid()
    {
        if (txtuname.Text == "")
        {
            Response.Write("<script> alert('username not valid');  </script>");
            txtuname.Focus();

            return false;
        }
        else if (TxtName.Text == "")
        {
            Response.Write("<script> alert('Name not valid');  </script>");
            TxtName.Focus();
            return false;
        }
        else if (TxtEmail.Text == "")
        {
            Response.Write("<script> alert('Email not valid');  </script>");
            TxtEmail.Focus();
            return false;
        }
        else if (txtpass.Text == "")
        {
            Response.Write("<script> alert('Password not valid');  </script>");
            txtpass.Focus();
            return false;
        }
        else if (txtpass.Text != txtcpass.Text)
        {
            Response.Write("<script> alert('confirm Password not valid');  </script>");
            txtcpass.Focus();
            return false;
        }
     
       

        return true;
    }

    private void clr()
    {
        txtuname.Text = string.Empty;
        TxtName.Text = string.Empty;
        TxtEmail.Text = string.Empty;
        txtpass.Text = string.Empty;
        txtcpass.Text = string.Empty;
    }
}
/*mycon();

cmd = new MySqlCommand("INSERT INTO signup values(@username, @FullName, @Email, @Password, @ConfirmPassword, @modifydate)", con);

cmd.Parameters.AddWithValue("@username", txtuname.Text);
cmd.Parameters.AddWithValue("@FullName", TxtName.Text);
cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
cmd.Parameters.AddWithValue("@Password", txtpass.Text);
cmd.Parameters.AddWithValue("@ConfirmPassword", txtcpass.Text);
cmd.Parameters.AddWithValue("@modifydate", System.DateTime.Now.ToString());

cmd.ExecuteNonQuery();
 Response.Write("<script>alert('SignUp Successfully')</script>");*/

    /* cmd = new MySqlCommand("select * from signup", con);
     da = new MySqlDataAdapter(cmd);
     ds = new DataSet();
     da.Fill(ds);

     GridView1.DataSource = ds;
     GridView1.DataBind();
    con.Close();


    }





}*/