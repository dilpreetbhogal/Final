using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class company_name : System.Web.UI.Page
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

                selectcompanyrep();
                selectmaincategory();
                
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
    void selectsubcategory()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlCommand("Select * from [subcategory] where maincategoryid =@a1 order by (subcategoryname) asc", con))
            {
                cmd.Parameters.AddWithValue("@a1", ddmain.SelectedValue);
                ddsub.DataSource = cmd.ExecuteReader();
                ddsub.DataBind();
                ddsub.Items.Insert(0, (new ListItem("Select A subcategory", "-1")));
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

    void selectchildcategory()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlCommand("Select * from [childcategory] where subcategoryid =@a1 order by (childcategoryname) asc", con))
            {
                cmd.Parameters.AddWithValue("@a1", ddsub.SelectedValue);
                ddchild.DataSource = cmd.ExecuteReader();
                ddchild.DataBind();
                ddchild.Items.Insert(0, (new ListItem("Select A childcategory", "-1")));
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
void selectcompanyrep()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select * from [company_name] order by companyname asc", con))
            {
                companyrep.DataSource = cmd.ExecuteReader();
                companyrep.DataBind();
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
        using (var cmd = new SqlCommand("insert into [company_name] (maincategoryid,subcategoryid,childcategoryid,companyname) values(@c1,@c2,@c3,@c4)", con))
        {
            cmd.Parameters.AddWithValue("@c1", ddmain.SelectedValue);
            cmd.Parameters.AddWithValue("@c2", ddsub.SelectedValue);
            cmd.Parameters.AddWithValue("@c3", ddchild.SelectedValue);
            cmd.Parameters.AddWithValue("@c4", txtcompanyname.Text);
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                lblerror.Text = txtcompanyname.Text + " is added successfully";
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
            lblerror.Text = txtcompanyname.Text + " is already exist in our database";

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
    

    
protected void companyrep_ItemCommand(object source, RepeaterCommandEventArgs e)
 {
    
        if (e.CommandName == "edit")
        {
            ((Label)e.Item.FindControl("lblcompanyname")).Visible = false;

            ((TextBox)e.Item.FindControl("txtcompanyname")).Visible = true;

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
                using (var cmd = new SqlCommand("Delete from [company_name] where companyid=@c1 ", con))
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
                var companyname = ((TextBox)e.Item.FindControl("txtcompanyname"));
                using (var cmd = new SqlCommand("Update [company_name] SET companyname=@cn where companyid=@c1 ", con))
                {
                    cmd.Parameters.AddWithValue("@c1", e.CommandArgument);
                    cmd.Parameters.AddWithValue("@cn", companyname.Text);
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

            ((Label)e.Item.FindControl("lblcompanyname")).Visible = true;

            ((TextBox)e.Item.FindControl("txtcompanyname")).Visible = false;

            ((LinkButton)e.Item.FindControl("linkedit")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkdelete")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkupdate")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkcancel")).Visible = false;
        }

    }

protected void ddmain_SelectedIndexChanged(object sender, EventArgs e)
{
    selectsubcategory();
}

protected void ddsub_SelectedIndexChanged1(object sender, EventArgs e)
{
    selectchildcategory();
}

protected void btnaddcompany_Click(object sender, EventArgs e)
{
    
        insert();
}
}
