using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Job_apply : System.Web.UI.Page
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
              //  ddcountry.DataSource = cmd.ExecuteReader();
              //  ddcountry.DataBind();
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
            using (var cmd = new SqlCommand("Select * from [city] where stateid='" + ddstate.SelectedValue + "' order by cityname asc", con))
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


    void viewprofile()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlCommand("select * from [job_apply] where email=@a1", con))
            {
                cmd.Parameters.AddWithValue("@a1", Session["email"]);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblfn.Text = dr["fn"].ToString();
                        lblln.Text = dr["ln"].ToString();
                        lblftn.Text = dr["ftn"].ToString();
                        lblqul.Text = dr["qul"].ToString();
                        lblgender.Text = dr["gender"].ToString();
                        lblquestion.Text = dr["question"].ToString();
                        lblanswer.Text = dr["answer"].ToString();
                        lblcountry.Text = dr["countryid"].ToString();
                        lblstate.Text = dr["stateid"].ToString();
                        lblcity.Text = dr["cityid"].ToString();
                        lbladdress.Text = dr["address"].ToString();
                        lblpn.Text = dr["pn"].ToString();
                        lblemail.Text = dr["email"].ToString();
                        lblpincode.Text = dr["pin"].ToString();
                        lblresume.Text = dr["resume"].ToString();
                        lblcategory.Text = dr["category"].ToString();
                        lblsubcategory.Text = dr["subcategory"].ToString();
                        lblchildcategory.Text = dr["childcategory"].ToString();
                        lbltittle.Text = dr["jobtittle"].ToString();
                        lbldescription.Text = dr["description"].ToString();
                        lblsalary.Text = dr["salary"].ToString();
                        lbldesignation.Text = dr["desigantion"].ToString();
                        lblposts.Text = dr["posts"].ToString();
                        lblkeyskills.Text = dr["keyskills"].ToString();
                        lblcompanyname.Text = dr["companyname"].ToString();
                        lbldate.Text = dr["date"].ToString();
                    }
                }
                else
                {
                    lblerror.Text = "incorrect email or password";
                }

            }
        }


        catch (Exception cc)
        {
            lblerror.Text = cc.Message;

        }
    }



    }
