using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class sub_category : System.Web.UI.Page
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
                selectmaincategory();
                selectsubrep();
                ddmain.Items.Insert(0, (new ListItem("Select A maincategory", "-1")));
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
    void selectmaincategory()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlCommand("select * from [maincategory1] order by (maincategoryname) asc", con))
            {
                ddmain.DataSource = cmd.ExecuteReader();
                ddmain.DataBind();
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
    void selectsubrep()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select s.subcategoryname,m.maincategoryname,s.subcategoryid from[subcategory] as s INNER JOIN [maincategory1] as m ON s.maincategoryid=m.maincategoryid group by s.subcategoryid,s.subcategoryname,m.maincategoryname order by s.subcategoryid", con))
            {
                subrep.DataSource = cmd.ExecuteReader();
                subrep.DataBind();
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

            using (var cmd = new SqlCommand("insert into [subcategory] (maincategoryid,subcategoryname) values(@c1,@c2)", con))
            {
                cmd.Parameters.AddWithValue("@c1", ddmain.SelectedValue);
                cmd.Parameters.AddWithValue("@c2", txtsub.Text);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    lblerror.Text = txtsub.Text + " is added successfully";
                }
                else
                    lblerror.Text = " error in insert command";
            }
        }

        catch (SqlException cc)
        {
            if (cc.Number == 2627)
            {
                lblerror.Text = txtsub.Text + " is already exist in our database";

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

    protected void btnsub1_Click(object sender, EventArgs e)
    {
        if (ddmain.SelectedValue == "-1")
        { lblerror.Text = "Please Select A maincategory"; }
        else
        {
            insert();
        }
    }
    protected void subrep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "edit")
        {
            ((Label)e.Item.FindControl("lblsubname")).Visible = false;

            ((TextBox)e.Item.FindControl("txtsubname")).Visible = true;

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
                using (var cmd = new SqlCommand("Delete from [subcategory] where subcategoryid=@c1 ", con))
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
                var subcategoryname = ((TextBox)e.Item.FindControl("txtsubname"));
                using (var cmd = new SqlCommand("Update [subcategory] SET subcategoryname=@cn where subcategoryid=@c1 ", con))
                {
                    cmd.Parameters.AddWithValue("@c1", e.CommandArgument);
                    cmd.Parameters.AddWithValue("@cn", subcategoryname.Text);
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

            ((Label)e.Item.FindControl("lblsubname")).Visible = true;

            ((TextBox)e.Item.FindControl("txtsubname")).Visible = false;

            ((LinkButton)e.Item.FindControl("linkedit")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkdelete")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkupdate")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkcancel")).Visible = false;
        }

    }

}





   