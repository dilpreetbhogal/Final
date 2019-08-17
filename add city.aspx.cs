using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class add_city : System.Web.UI.Page
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
                selectcityrep();
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
            using (var cmd = new SqlCommand("select * from [country] order by (Countryname) asc", con))
            {
                ddcountry.DataSource = cmd.ExecuteReader();
                ddcountry.DataBind();
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
                ddstate.Items.Insert(0, (new ListItem("Select A State", "-1")));
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

    void selectcityrep()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select c.Cityname,s.Statename,m.Countryname,c.Cityid from [city] as c INNER JOIN [state] as s ON c.Stateid=s.Stateid INNER JOIN[country] as m on c.Countryid=m.Countryid group by c.Cityid,s.Statename,m.Countryname,c.Cityname order by c.Cityid", con))
            {
                cityrep.DataSource = cmd.ExecuteReader();
                cityrep.DataBind();
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
            using (var cmd = new SqlCommand("insert into [city] (Countryid,Stateid,Cityname) values(@c1,@c2,@c3)",con))
            {
                cmd.Parameters.AddWithValue("@c1", ddcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@c2", ddstate.SelectedValue);
                cmd.Parameters.AddWithValue("@c3", txtanc.Text);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    lblerror.Text = txtanc.Text + " is added successfully";
                    Response.Redirect(Request.RawUrl);
                }

                else
                    lblerror.Text = "error is in  insert command";
            }
        }
        catch (SqlException cc)
        {
            if (cc.Number == 2627)
            {
                lblerror.Text = txtanc.Text + " is already exist in our database";

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



    protected void Button2_Click(object sender, EventArgs e)
    {

        if (ddcountry.SelectedValue == "-1")
        { lblerror.Text = "Please Select A Country"; }
        else
            if (ddstate.SelectedValue == "-1")
            { lblerror.Text = "Please Select A State"; }
            else
            {
                insert();
            }
    }



    protected void ddcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectstate();
}

    protected void cityrep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "edit")
        {
            ((Label)e.Item.FindControl("lblcityname")).Visible = false;

            ((TextBox)e.Item.FindControl("txtcityname")).Visible = true;

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
                using (var cmd = new SqlCommand("Delete from [city] where Cityid=@c1 ",con))
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
                var cityname=((TextBox)e.Item.FindControl("txtcityname"));
                using (var cmd = new SqlCommand("Update [city] SET Cityname=@cn where Cityid=@c1 ", con))
                {
                    cmd.Parameters.AddWithValue("@c1", e.CommandArgument);
                    cmd.Parameters.AddWithValue("@cn", cityname.Text);
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

            ((Label)e.Item.FindControl("lblcityname")).Visible = true;

            ((TextBox)e.Item.FindControl("txtcityname")).Visible = false;

            ((LinkButton)e.Item.FindControl("linkedit")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkdelete")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkupdate")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkcancel")).Visible = false;
        }
    }
}


