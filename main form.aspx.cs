using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class main_form : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        connection();
        if (!Page.IsPostBack)
        {

            selectcountry();
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
            using (var cmd = new SqlCommand("Select * from [city] where stateid='"+ddstate.SelectedValue+"' order by cityname asc", con))
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
     void insert()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("insert into [registertbl] (fn,ln,fathersname,qual,gender,securityquestion,securityanswer,countryid,stateid,cityid,address,pn,email,password,pin,resume) values(@c1,@c2,@c3,@c4,@c5,@c6,@c7,@c8,@c9,@c10,@c11,@c12,@c13,@c14,@c15,@c16)", con))
            {
                cmd.Parameters.AddWithValue("@c1", txtfn.Text);
                cmd.Parameters.AddWithValue("@c2", txtln.Text);
                cmd.Parameters.AddWithValue("@c3", txtftn.Text);
                cmd.Parameters.AddWithValue("@c4", txtqul.Text);
                cmd.Parameters.AddWithValue("@c5", radiobtngender.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@c6", ddquestion.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@c7", txtanswer.Text);
                cmd.Parameters.AddWithValue("@c8", ddcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@c9", ddstate.SelectedValue);
                cmd.Parameters.AddWithValue("@c10", ddcity.SelectedValue);
                cmd.Parameters.AddWithValue("@c11", txtaddress.Text);
                cmd.Parameters.AddWithValue("@c12", txtpn.Text);
                cmd.Parameters.AddWithValue("@c13", txtemail.Text );
                cmd.Parameters.AddWithValue("@c14", txtpass.Text);
                cmd.Parameters.AddWithValue("@c15", txtpc.Text);
                cmd.Parameters.AddWithValue("@c16", txtresume.Text);
                
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    lblerror.Text = "Thank you";
                }
                else
                    lblerror.Text = "error in insert command";
            
            }
        }


        catch (SqlException cc)
        {
            if (cc.Number == 2627)
            {
                lblerror.Text = txtemail.Text + " already Exist in our db";

            }
        }


        catch (Exception cc)
        {


            lblerror.Text = cc.Message;
        }
       
    }


    protected void  ddcountry_SelectedIndexChanged(object sender, EventArgs e)
{
selectstate();
}

protected void  ddstate_SelectedIndexChanged(object sender, EventArgs e)
{
    selectcity();
}
protected void  Button1_Click(object sender, EventArgs e)
{
    if (ddcountry.SelectedValue == "-1")
    {
        lblerror.Text = "please select country";
    }
    else

        if (ddcountry.SelectedValue == "-1")
        {
            lblerror.Text = "please select state";
        }
        else

            if (ddcountry.SelectedValue == "-1")
            {
                lblerror.Text = "please select city";
            }
            else
    insert();

}
}

 