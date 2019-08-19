using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
          connection();
      }

          void connection()
    {

        try
        {
            con.ConnectionString = " Data source=.\\SQLEXPRESS;AttachDbFilename=" + Server.MapPath("~\\App_Data\\Database.mdf") + ";Integrated Security=True;User Instance=True";
            
        }
        catch (Exception cc)
        {
            lblerror.Text = cc.Message;
        }
    }

         
          protected void Button1_Click(object sender, EventArgs e)
          {
              try
              {
                  if (con.State == ConnectionState.Closed)
                  {
                      con.Open();
                  }
                  using (var cmd = new SqlCommand("select *from [registertbl] where email=@1 and password=@2", con))
                  {
                      cmd.Parameters.AddWithValue("@1", txtmail.Text);
                      cmd.Parameters.AddWithValue("@2", txtpass.Text);
                      SqlDataReader dr = cmd.ExecuteReader();
                      if (dr.HasRows)
                      {
                          while (dr.Read())
                          {
                              Session["email"] = dr["email"].ToString();
                              Session["firstname"] = dr["fn"].ToString();
                              Session["u_id"] = dr["regid"].ToString();
                              Response.Redirect("my_account.aspx");
                          }
                      }
                      else
                      {
                          lblerror.Text = "incorrect email or password";
                      }

                  }
              }


              catch (Exception cc)
              {
                  lblerror.Text = cc.Message;
              }
          }
}

