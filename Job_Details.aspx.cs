using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Job_Details : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        connection();
        
        if (!Page.IsPostBack)
        {
            selectmaindata();
            selectsidedata();
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
            //lblerror.Text = cc.Message;
        }
    }

    void selectmaindata()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlDataAdapter("select j.jobtitle,j.jobid,j.description,j.qualification,j.salary,j.designation,j.companyid,j.numberofposts,j.lastdate,j.keyskills,c.companyid,c.companyname,c.image  from [add_job] as j INNER JOIN [add_company] as c On j.companyid=c.companyid where j.jobid='" + Request.QueryString["jobid"] + "'", con))
            {
                using (var ds = new DataSet())
                {
                    cmd.Fill(ds);
                    repbind.DataSource = ds;
                    repbind.DataBind();
                }
            }
        }
        catch (Exception cc)
        {
            //lblerror.Text = cc.Message;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
    void selectsidedata()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlDataAdapter("select TOP 10 * from add_job where jobid!='" + Request.QueryString["jobid"] + "' order by (jobid) desc", con))
            {
                using (var ds = new DataSet())
                {
                    cmd.Fill(ds);
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
            }
        }
        catch (Exception cc)
        {
           // lblerror.Text = cc.Message;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

    public string GenerateMain2(object id)
    {

        string str = "apply_Job.aspx?jid=" + id ;
        return str;
    }
    public string GenerateMain(object id)
    {

        string str = "Job_Details.aspx?jobid=" + id;
        return str;
    }
   
}