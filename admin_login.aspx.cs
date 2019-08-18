using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class admin_login : System.Web.UI.Page
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

          protected void btnlogin_Click(object sender, EventArgs e)
          {
              try
              {
                  if (con.State == ConnectionState.Closed)
                  {
                      con.Open();
                  }
                  using (var cmd = new SqlCommand("select * from [admin] where email=@a1 and passsword=@a2", con))
                  {
                      cmd.Parameters.AddWithValue("@a1", txtmail.Text);
                      cmd.Parameters.AddWithValue("@a2", txtpass.Text);
                      SqlDataReader dr = cmd.ExecuteReader();
                      if (dr.HasRows)
                      {
                          while (dr.Read())
                          {
                              Session["Aemail"] = dr["email"].ToString();
                              Session["Afirstname"] = dr["fn"].ToString();
                              Response.Redirect("admin_account.aspx");
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
