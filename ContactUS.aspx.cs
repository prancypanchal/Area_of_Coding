using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class ContactUS : System.Web.UI.Page
{
    public static String CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|datadirectory|\wearingarea1.mdf;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string email = txtEmail.Text;
        string message = txtMessage.Text;

   
        using (SqlConnection con = new SqlConnection(CS))
        {
            string query = "INSERT INTO ContactMessages (Name, Email, Message, DateSent) VALUES (@Name, @Email, @Message, GETDATE())";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Message", message);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Message sent successfully!');</script>");
            ClearFields();
        }
    }

    private void ClearFields()
    {
        txtName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtMessage.Text = string.Empty;
    }
}

    
