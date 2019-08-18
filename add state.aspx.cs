using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class add_state : System.Web.UI.Page
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
            connection();
            if (!Page.IsPostBack)
            {

                selectcountry();
                selectstaterep();
                ddcountry.Items.Insert(0, (new ListItem("Select A Country", "-1")));
            }
        }
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
        finally {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

    }


    void selectstaterep()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select s.Statename,m.Countryname,s.Stateid from[state] as s INNER JOIN [country] as m ON s.Countryid=m.Countryid group by s.Stateid,s.Statename,m.Countryname order by s.Stateid", con))
            {
                staterep.DataSource = cmd.ExecuteReader();
                staterep.DataBind();
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


 void insert()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("insert into [state] (Countryid,Statename) values(@c1,@c2)", con))
            {
                cmd.Parameters.AddWithValue("@c1", ddcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@c2", txtans.Text);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    lblerror.Text = txtans.Text + " is added successfully";
                }
                else
                    lblerror.Text = "error in insert command";
            }
        }

        catch (SqlException cc)
        {
            if (cc.Number == 2627)
            {
                lblerror.Text = txtans.Text + " is already exist in our database";

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
 protected void Button_Click(object sender, EventArgs e)
 {
     if (ddcountry.SelectedValue == "-1")
     { lblerror.Text = "Please Select A Country"; }
     else
          {
             insert();
         }
 }

    protected void staterep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            ((Label)e.Item.FindControl("lblstatename")).Visible = false;

            ((TextBox)e.Item.FindControl("txtstatename")).Visible = true;

            ((LinkButton)e.Item.FindControl("linkedit")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkdelete")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkupdate")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkcancel")).Visible = true;
        }
        if (e.CommandName == "delete")
        {
             try {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                using (var cmd = new SqlCommand("Delete from [state] where Stateid=@c1 ",con))
                {
                    cmd.Parameters.AddWithValue("@c1", e.CommandArgument);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                        Response.Redirect(Request.RawUrl);
                    else
                        lblerror.Text = "error in delete command";
                }
            
            }
            catch (Exception cc)
            { lblerror.Text = cc.Message; }
        }
      
        if (e.CommandName == "update")
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                var statename = ((TextBox)e.Item.FindControl("txtstatename"));
                using (var cmd = new SqlCommand("Update [state] SET Statename=@cn where Stateid=@c1 ", con))
                {
                    cmd.Parameters.AddWithValue("@c1", e.CommandArgument);
                    cmd.Parameters.AddWithValue("@cn", statename.Text);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                        Response.Redirect(Request.RawUrl);
                    else
                        lblerror.Text = "error in Update command";
                }

            }
            catch (Exception cc)
            { lblerror.Text = cc.Message; }

     }
        if (e.CommandName == "cancel")
        {

            ((Label)e.Item.FindControl("lblstatename")).Visible = true;

            ((TextBox)e.Item.FindControl("txtstatename")).Visible = false;

            ((LinkButton)e.Item.FindControl("linkedit")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkdelete")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkupdate")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkcancel")).Visible = false;
        }
       }
    }
