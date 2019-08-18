using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class child_category : System.Web.UI.Page
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
            selectchildrep();
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

    void selectchildrep()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select c.childcategoryname,s.subcategoryname,m.maincategoryname,c.childcategoryid from[childcategory] as c INNER JOIN [subcategory] as s ON c.subcategoryid=s.subcategoryid INNER JOIN[maincategory1] as m on c.maincategoryid=m.maincategoryid group by c.childcategoryid,s.subcategoryname,m.maincategoryname,c.childcategoryname order by c.childcategoryid", con))
            {
                childrep.DataSource = cmd.ExecuteReader();
                childrep.DataBind();
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
            using (var cmd = new SqlCommand("insert into [childcategory] (maincategoryid,subcategoryid,childcategoryname) values(@c1,@c2,@c3)",con))
            {
                cmd.Parameters.AddWithValue("@c1", ddmain.SelectedValue);
                cmd.Parameters.AddWithValue("@c2", ddsub.SelectedValue);
                cmd.Parameters.AddWithValue("@c3", txtchild.Text);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    lblerror.Text = txtchild.Text + " is added successfully";
                }

                else
                    lblerror.Text = "error is in  insert command";
            }
        }
        catch (SqlException cc)
        {
            if (cc.Number == 2627)
            {
                lblerror.Text = txtchild.Text + " is already exist in our database";

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


    protected void  btnchild1_Click(object sender, EventArgs e)
{
          if (ddmain.SelectedValue == "-1")
        { lblerror.Text = "Please Select A maincategory"; }
        else
              if (ddsub.SelectedValue == "-1")
              { lblerror.Text = "Please Select A subcategory"; }
              else
              {
                  insert();
              }
       }
    protected void ddmain_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectsubcategory();
    }
    protected void childrep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
         
            if (e.CommandName == "edit")
        {
            ((Label)e.Item.FindControl("lblchildname")).Visible = false;

            ((TextBox)e.Item.FindControl("txtchildname")).Visible = true;

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
                using (var cmd = new SqlCommand("Delete from [childcategory] where childcategoryid=@c1 ", con))
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
                var childcategoryname = ((TextBox)e.Item.FindControl("txtchildname"));
                using (var cmd = new SqlCommand("Update [childcategory] SET childcategoryname=@cn where childcategoryid=@c1 ", con))
                {
                    cmd.Parameters.AddWithValue("@c1", e.CommandArgument);
                    cmd.Parameters.AddWithValue("@cn", childcategoryname.Text);
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

            ((Label)e.Item.FindControl("lblchildname")).Visible = true;

            ((TextBox)e.Item.FindControl("txtchildname")).Visible = false;

            ((LinkButton)e.Item.FindControl("linkedit")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkdelete")).Visible = true;
            ((LinkButton)e.Item.FindControl("linkupdate")).Visible = false;
            ((LinkButton)e.Item.FindControl("linkcancel")).Visible = false;
        }

    }
}

