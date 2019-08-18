using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Add_job : System.Web.UI.Page
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
                selectcompany();
                selectmaincategory();
                ddcategory.Items.Insert(0, (new ListItem("select A category", "-1")));
                ddcountry.Items.Insert(0, (new ListItem("Select A Country", "-1")));
                ddcompanyname.Items.Insert(0, (new ListItem("Select A Companyname", "-1")));
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
          void selectcompany()
          {
              try
              {
                  if (con.State == ConnectionState.Closed)
                  {
                      con.Open();
                  }

                  using (var cmd = new SqlCommand("Select * from [company_name] order by Companyname asc", con))
                  {
                      ddcompanyname.DataSource = cmd.ExecuteReader();
                      ddcompanyname.DataBind();
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
     void selectstate()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlCommand("Select * from [state] where Countryid="+ ddcountry.SelectedValue + "order by (Statename) asc", con))
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
    void selectcity()
    {
 try
 {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlCommand("Select * from [city] where Stateid=" + ddstate.SelectedValue + " and Countryid="+ddcountry.SelectedValue+" order by Cityname asc", con))
            {
                cmd.Parameters.AddWithValue("@1", ddstate.SelectedValue);
                ddcity.DataSource = cmd.ExecuteReader();
                ddcity.DataBind();
                ddcity.Items.Insert(0, (new ListItem("Select A City", "-1")));

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

    void selectmaincategory()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select * from [maincategory1] order by maincategoryname asc", con))
            {
                ddcategory.DataSource = cmd.ExecuteReader();
                ddcategory.DataBind();

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

 void selectsubcategory()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select * from [subcategory] where maincategoryid = '"+ddcategory.SelectedValue+"' order by subcategoryname asc", con))
            {
                ddsubcategory.DataSource = cmd.ExecuteReader();
                ddsubcategory.DataBind();
                ddsubcategory.Items.Insert(0, (new ListItem("select a subcategory", "-1")));
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

    void selectchildcategory()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select * from [childcategory] where subcategoryid ='"+ddsubcategory.SelectedValue+"' order by childcategoryname asc", con))
            {
                ddchildcategory.DataSource = cmd.ExecuteReader();
                ddchildcategory.DataBind();
                ddchildcategory.Items.Insert(0, (new ListItem("select a childcategory", "-1")));
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

            using (var cmd = new SqlCommand("insert into [add_job] (maincategoryid,subcategoryid,childcategoryid,jobtitle,description,qualification,salary,designation,companyid,numberofposts,keyskills,countryid,stateid,cityid,lastdate) values(@c1,@c2,@c3,@c4,@c5,@c6,@c7,@c8,@c9,@c10,@c11,@c12,@c13,@c14,@c15)", con))
            {
                cmd.Parameters.AddWithValue("@c1", ddcategory.SelectedValue);
                cmd.Parameters.AddWithValue("@c2", ddsubcategory.SelectedValue);
                cmd.Parameters.AddWithValue("@c3", ddchildcategory.SelectedValue);
                cmd.Parameters.AddWithValue("@c4", txttittle.Text);
                cmd.Parameters.AddWithValue("@c5", txtdescription.Text);
                cmd.Parameters.AddWithValue("@c6", txtqul.Text);
                cmd.Parameters.AddWithValue("@c7", txtsalary.Text);
                cmd.Parameters.AddWithValue("@c8", txtdesignation.Text);
                cmd.Parameters.AddWithValue("@c9", ddcompanyname.SelectedValue);
                cmd.Parameters.AddWithValue("@c10", txtposts.Text);
                cmd.Parameters.AddWithValue("@c11", txtkeyskills.Text);
                cmd.Parameters.AddWithValue("@c12", ddcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@c13", ddstate.SelectedValue);
                cmd.Parameters.AddWithValue("@c14", ddcity.SelectedValue);
                cmd.Parameters.AddWithValue("@c15", txtdate.Text);
           int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    lblerror.Text = "Thank you";
                }
                else
                    lblerror.Text = "error in insert command";
            
            }
        }

        catch (Exception cc)
        {


            lblerror.Text = cc.Message;
        }
       
    }

 protected void btnaddjob_Click(object sender, EventArgs e)
 {
     if (ddcountry.SelectedValue == "-1")
     {
         lblerror.Text = "please select country";
     }
     else

         if (ddstate.SelectedValue == "-1")
         {
             lblerror.Text = "please select state";
         }
         else

             if (ddcity.SelectedValue == "-1")
             {
                 lblerror.Text = "please select city";
             }
             else
                 insert();
     if (ddcompanyname.SelectedValue == "-1")
     {
         lblerror.Text = "please select companyname";
     }

     if (ddcategory.SelectedValue == "-1")
     { 
         lblerror.Text = "Please Select A maincategory"; 
     }
     else
         if (ddsubcategory.SelectedValue == "-1")
         {
             lblerror.Text = "Please Select A subcategory"; 
         }
     if (ddchildcategory.SelectedValue == "-1")
     {
         lblerror.Text = "Please Select A childcategory";
     }
     else
         insert();
 }
 
protected void ddcategory_SelectedIndexChanged(object sender, EventArgs e)
{
    selectsubcategory();
}

protected void ddsubcategory_SelectedIndexChanged(object sender, EventArgs e)
{
    selectchildcategory();
}
protected void ddcountry_SelectedIndexChanged(object sender, EventArgs e)
{
    selectstate();
}
protected void ddstate_SelectedIndexChanged(object sender, EventArgs e)
{
    selectcity();
}
}







    
