using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class job_repeater : System.Web.UI.Page
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

                selectjobrep();
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

    void selectjobrep()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select distinct(r.jobid), c1.maincategoryname,c2.subcategoryname,c3.childcategoryname,r.jobtitle,r.description,r.qualification,r.salary,r.designation,r.companyid,r.numberofposts,r.keyskills,m.countryname,s.statename,c.cityname,r.lastdate from [add_job] as r INNER JOIN [country] as m ON r.countryid=m.countryid INNER JOIN [state] as s ON r. stateid=s.stateid INNER JOIN [city] as c ON r. cityid=c.cityid  INNER JOIN [maincategory1] as c1 ON r.maincategoryid=c1.maincategoryid   INNER JOIN [subcategory] as c2 ON r. subcategoryid=c2.subcategoryid  INNER JOIN [childcategory] as c3 ON r. childcategoryid=c3.childcategoryid Group By c1.maincategoryname,c2.subcategoryname,c3.childcategoryname,r.jobtitle,r.description,r.qualification,r.salary,r.designation,r.companyid,r.numberofposts,r.keyskills,m.countryname,s.statename,c.cityname,r.lastdate,r.jobid order by r.jobid Desc", con))
            {
                jobrep.DataSource = cmd.ExecuteReader();
                jobrep.DataBind();
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
    protected void jobrep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            ((Label)e.Item.FindControl("lbljobtitle")).Visible = false;

            ((TextBox)e.Item.FindControl("txtjobtitle")).Visible = true;

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
                using (var cmd = new SqlCommand("Delete from [add_job] where jobid=@c1 ", con))
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
                var jobtitle = ((TextBox)e.Item.FindControl("txtjobtitle"));
                using (var cmd = new SqlCommand("Update [add_job] SET jobtitle=@cn where jobid=@c1 ", con))
                {
                    cmd.Parameters.AddWithValue("@c1", e.CommandArgument);
                    cmd.Parameters.AddWithValue("@cn", jobtitle.Text);
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

            ((Label)e.Item.FindControl("lbljobtitle")).Visible = true;

            ((TextBox)e.Item.FindControl("txtjobtitle")).Visible = false;

            ((LinkButton)e.Item.FindControl("linkedit")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkdelete")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkupdate")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkcancel")).Visible = false;
        }


    }
}
