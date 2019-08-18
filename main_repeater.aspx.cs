using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class main_repeater : System.Web.UI.Page
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

                selectmainrep();
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

    void selectmainrep()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select distinct(r.regid), r.fn,r.ln,r.fathersname,r.qual,r.gender,r.securityquestion,r.securityanswer,m.countryname,s.statename,c.cityname,r.address,r.pn,r.email,r.password,r.pin,r.resume from [registertbl] as r INNER JOIN [country] as m ON r.countryid=m.countryid INNER JOIN [state] as s ON r. stateid=s.stateid INNER JOIN [city] as c ON r. cityid=c.cityid Group By r.fn,r.ln,r.fathersname,r.qual,r.gender,r.qual,r.securityquestion,r.securityanswer,m.countryname,s.statename,c.cityname,r.address,r.pn,r.email,r.password,r.pin,r.resume,r.regid order by r.regid Desc", con)) 
            {
                mainrep.DataSource = cmd.ExecuteReader();
                mainrep.DataBind();
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


 }