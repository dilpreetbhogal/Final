using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class add_country : System.Web.UI.Page
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

                selectcountryrep();
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

    void selectcountryrep()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select * from [country] order by countryname asc", con))
            {
                countryrep.DataSource = cmd.ExecuteReader();
                countryrep.DataBind();
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

            using (var cmd = new SqlCommand("insert into [country] (CountryName) values(@c1)", con))
            {
                cmd.Parameters.AddWithValue("@c1", txtcountry.Text);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    lblerror.Text = txtcountry.Text + " is added successfully";
                }
                else
                    lblerror.Text = "error in insert command";
            }
        }

        catch (SqlException cc)
        {
            if (cc.Number == 2627)
            {
                lblerror.Text = txtcountry.Text + " is already exist in our database";

            }
        }


        catch (Exception cc)
        {


            lblerror.Text = cc.Message;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        insert();
    }
    protected void countryrep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            ((Label)e.Item.FindControl("lblcountryname")).Visible = false;

            ((TextBox)e.Item.FindControl("txtcountryname")).Visible = true;

            ((LinkButton)e.Item.FindControl("linkedit")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkdelete")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkupdate")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkcancel")).Visible = true;
        }
        if (e.CommandName == "delete")
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                using (var cmd = new SqlCommand("Delete from [country] where Countryid=@c1 ", con))
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
                var countryname = ((TextBox)e.Item.FindControl("txtcountryname"));
                using (var cmd = new SqlCommand("Update [country] SET Countryname=@cn where Countryid=@c1 ", con))
                {
                    cmd.Parameters.AddWithValue("@c1", e.CommandArgument);
                    cmd.Parameters.AddWithValue("@cn", countryname.Text);
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

            ((Label)e.Item.FindControl("lblcountryname")).Visible = true;

            ((TextBox)e.Item.FindControl("txtcountryname")).Visible = false;

            ((LinkButton)e.Item.FindControl("linkedit")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkdelete")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkupdate")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkcancel")).Visible = false;
        }

    }
}
           
















