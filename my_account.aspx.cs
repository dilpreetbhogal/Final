using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class my_account : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null || Session["firstname"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            Connection();
            if (!Page.IsPostBack)
            {
                selectcountry();
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
                  using (var cmd = new SqlCommand("select * from [registertbl] where email=@a1", con))
                  {
                      cmd.Parameters.AddWithValue("@a1", Session["email"]);
                      SqlDataReader dr = cmd.ExecuteReader();
                      if (dr.HasRows)
                      {
                          while (dr.Read())
                          {
                              lblfn.Text = dr["fn"].ToString();
                              lblcountry.Text = dr["countryid"].ToString();
                              lblstate.Text = dr["stateid"].ToString();
                              lblcity.Text = dr["cityid"].ToString();
                              lblpn.Text = dr["pn"].ToString();
                              lblemail.Text = dr["email"].ToString();
                              lblresume.Text = dr["resume"].ToString();
                        image.ImageUrl=     image1.ImageUrl = dr["image"].ToString();
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
                cmd.Parameters.AddWithValue("@a1", Session["email"]);
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
                    
               

            }
        }


        catch (Exception cc)
        {
            lblerror.Text = cc.Message;
        }
    
      finally
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
}
 void selectcountry()
{
    try
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        using (var cmd = new SqlCommand("Select * from [country] order by Countryname asc", con))
        {
            ddcountry.DataSource = cmd.ExecuteReader();
            ddcountry.DataBind();
        }
    }
    catch (Exception cc)
    { lblerror.Text = cc.Message; }
    finally
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }

}
void selectstate()
{
    try
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        using (var cmd = new SqlCommand("Select * from [state] where Countryid=@a1 order by (Statename) asc", con))
        {
            cmd.Parameters.AddWithValue("@a1", ddcountry.SelectedValue);
            ddstate.DataSource = cmd.ExecuteReader();
            ddstate.DataBind();
        }
    }
    catch (Exception cc)
    {
        lblerror.Text = cc.Message;
    }
    finally
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
}
void selectcity()
{
    try
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        using (var cmd = new SqlCommand("Select * from [city] where stateid='" + ddstate.SelectedValue + "' order by cityname asc", con))
        {

            ddcity.DataSource = cmd.ExecuteReader();
            ddcity.DataBind();
        }
    }
    catch (Exception cc)
    {
        lblerror.Text = cc.Message;
    }
    finally
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
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
protected void btnupdate_Click(object sender, EventArgs e)
{
    updateprofile();
}
void updateprofile()
{
    try
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        using (var cmd = new SqlCommand("Update [registertbl] Set fn=@a1,countryid=@a2,stateid=@a3,cityid=@a4,pn=@a5 where email=@email1", con))
        {
            cmd.Parameters.AddWithValue("@email1", Session["email"]);
            cmd.Parameters.AddWithValue("@a1", txtfn.Text);
            cmd.Parameters.AddWithValue("@a2", ddcountry.SelectedValue);
            cmd.Parameters.AddWithValue("@a3", ddstate.SelectedValue);
            cmd.Parameters.AddWithValue("@a4", ddcity.SelectedValue);
            cmd.Parameters.AddWithValue("@a5", txtpn.Text);


            int x = cmd.ExecuteNonQuery();
            if (x > 0)
                Response.Redirect(Request.RawUrl);
            else
                lblerror.Text = "error";

        } 
    }

    catch (Exception cc)
    {
        lblerror.Text = cc.Message;
    }

}



void updatepass()
{
    try
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        using (var cmd = new SqlCommand("Update [registertbl] Set password=@newpass where email=@email and password=@oldpass", con))
        {
            cmd.Parameters.AddWithValue("@email", Session["email"]);
            cmd.Parameters.AddWithValue("@oldpass",txtoldpass.Text );
            cmd.Parameters.AddWithValue("@newpass",txtnewpass.Text );
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
                lblerror.Text = "Password changed successfully";

            else
                lblerror.Text = "error";

        }
    }

    catch (Exception cc)
    {
        lblerror.Text = cc.Message;
    }

}

protected void btnpass_Click(object sender, EventArgs e)
{
    updatepass();
}
void changeimage()
{
    string folderpath = Server.MapPath("userimage/");
    string filename = "";
    try
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (FileUpload1.HasFile)
        {
            if (CheckFileExtension(Path.GetExtension(FileUpload1.FileName)))
            {
                filename = Guid.NewGuid() + Path.GetExtension(FileUpload1.FileName);
                string img = "~/userimage/" + filename;
                using (var command = new SqlCommand("update [registertbl] set image=@image where email=@email", con))
                {
                    command.Parameters.AddWithValue("@image", img);
                    command.Parameters.AddWithValue("@email", Session["email"].ToString());
                    int x = command.ExecuteNonQuery();
                    if (x > 0)
                    {
                        FileUpload1.SaveAs(folderpath + filename);
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        lblerror.Text = "Please select.jpg,.bmp,.ttf, image format file only";
                    }
                }
            }
            else
            {
                lblerror.Text = "Please select image file";
            }
        }
    }
    catch (Exception cc)
    {
        lblerror.Text = "error" + cc.Message;
    }
}
 private bool CheckFileExtension(string ext)
   {
       if(ext.ToLower() == ".jpg" || ext.ToLower() ==".bmp" || ext.ToLower() ==".jpeg" || ext.ToLower() ==".ttf" || ext.ToLower() ==".gif")
       {
           return true;
       }
       else
       {
           return false;
       }
   }

protected void  buttonupdates_Click(object sender, EventArgs e)
{
    changeimage();
}

protected void ddcountry_SelectedIndexChanged1(object sender, EventArgs e)
{
    selectstate();
}
protected void ddstate_SelectedIndexChanged1(object sender, EventArgs e)
{
    selectcity();
}
}
