using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class feedback_repeater : System.Web.UI.Page
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

                selectfeedbackrep();
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

    void selectfeedbackrep()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("Select * from [feedback] order by feedbackid asc", con))
            {
                feedbackrep.DataSource = cmd.ExecuteReader();
                feedbackrep.DataBind();
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
