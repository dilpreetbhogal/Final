using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class admin_account : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["Aemail"] == null || Session["Afirstname"] == null)
        {
           Response.Redirect("admin_login.aspx");
       }
        else
        {
            Connection();

            if (!Page.IsPostBack)
            {
                viewprofile();
            }
        }
    }


    void Connection()
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
    void  viewprofile()
    {
         try
              {
                  if (con.State == ConnectionState.Closed)
                  {
                      con.Open();
                  }
                  using (var cmd = new SqlCommand("select *from [admin] where email=@a1", con))
                  {
                      cmd.Parameters.AddWithValue("@a1", Session["Aemail"]);
                      SqlDataReader dr = cmd.ExecuteReader();
                      if (dr.HasRows)
                      {
                          while (dr.Read())
                          {
                              lblfn.Text = dr["fn"].ToString();
                              lblcountry.Text = dr["country"].ToString();
                              lblstate.Text = dr["state"].ToString();
                              lblcity.Text = dr["city"].ToString();
                              lblpn.Text = dr["pn"].ToString();
                              lblemail.Text = dr["email"].ToString();
                              lblresume.Text = dr["resume"].ToString();
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
    void editprofile()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlCommand("select *from [registertbl] where email=@a1", con))
            {
                cmd.Parameters.AddWithValue("@1", Session["Aemail"]);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtfn.Text = dr["fn"].ToString();
                        txtpn.Text = dr["pn"].ToString();
                        txtmail.Text = dr["email"].ToString();
                        txtresume.Text = dr["resume"].ToString();
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



    protected void btnprofile_Click(object sender, EventArgs e)
    {
        panel1.Visible = true;
        panel2.Visible = false;
        panel3.Visible = false;
        panel4.Visible = false;
    }

protected void btnedit_Click(object sender, EventArgs e)
    {
       editprofile();
        panel1.Visible = false;
        panel2.Visible = true;
        panel3.Visible = false;
        panel4.Visible = false;
}


protected void btnpassword_Click(object sender, EventArgs e)
{
    panel1.Visible = false;
    panel2.Visible = false;
    panel3.Visible = true;
    panel4.Visible = false;
}



protected void btnimage_Click(object sender, EventArgs e)
{
    panel1.Visible = false;
    panel2.Visible = false;
    panel3.Visible = false;
    panel4.Visible = true;
}

    }
