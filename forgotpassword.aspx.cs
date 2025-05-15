using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

public partial class forgotpassword : System.Web.UI.Page
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

    }

    protected void btnResetPass_Click(object sender, EventArgs e)
    {
        mycon();

        cmd = new SqlCommand("Select * from Signup where Email=@Email ", con); 
           cmd.Parameters.AddWithValue("@Email", txtEmailID.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                String myGUID = Guid.NewGuid().ToString();
                int Uid =Convert.ToInt32(dt.Rows[0][0]);
               
                cmd = new SqlCommand("Insert into ForgotPass(Id,Uid,RequestDateTime) values('" +myGUID +"','"+Uid+"',GETDATE())", con);
                cmd.ExecuteNonQuery();


            //send reset link via email

                string Toemailaddress = dt.Rows[0][3].ToString();
                string Username = dt.Rows[0][1].ToString();
                string Emailbody = "Hi  "+Username + ",<br/><br/>Click the link below to reset your password<br/><br/>http://localhost:51883/RecoverPassword.aspx?id=" + myGUID;


                MailMessage PassRecMail = new MailMessage("prancy.panchal@gmail.com", Toemailaddress); //self email

                PassRecMail.Body = Emailbody;
                PassRecMail.IsBodyHtml = true;
                PassRecMail.Subject = "Reset Password";


            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("prancy.panchal@gmail.com", "nmasocyyafiqpwkk");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(PassRecMail);


            }
            //SmtpClient SMTP = new SmtpClient("smtp.gmail.com",587);
            //SMTP.Credentials = new NetworkCredential()
            //{
            //    UserName = "prancy.panchal@gmail.com",
            //    Password = "szisfezdhafavwxi"

            //};
            //SMTP.EnableSsl = true;
            //SMTP.Send(PassRecMail);




            lblresetpassmsg.Text = "Reset Link send ! Check Your email for reset password";
                lblresetpassmsg.ForeColor = System.Drawing.Color.Green;
                txtEmailID.Text = string.Empty;
            }
            else
            {
                lblresetpassmsg.Text = "OOps ! This Email Does not Exist....Try again";
                lblresetpassmsg.ForeColor = System.Drawing.Color.Red;
                txtEmailID.Text = string.Empty;
                txtEmailID.Focus();
            }
    }
}