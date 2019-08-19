using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        connection();
        if (!Page.IsPostBack)
        {
            getWallData();
            getWallData2();
            getWallData3();
        }

    }
    public string GenerateMain(object id)
    {

        string str = "Job_Details.aspx?jobid=" + id;
        return str;
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
    void getWallData()
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
        try
        {
            cmd = new SqlCommand("select Top 6 p.lastdate,p.jobid,p.jobtitle,p.salary,p.companyid,p.maincategoryid,j.companyid,j.companyname from add_job as p inner join add_company as j on p.companyid=j.companyid where p.maincategoryid=8", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();

        }
        catch (Exception cc)
        {
            Response.Write(cc.Message);
        }
    }
    void getWallData2()
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
        try
        {
            cmd = new SqlCommand("select Top 6 p.lastdate,p.jobid,p.jobtitle,p.salary,p.companyid,p.maincategoryid,j.companyid,j.companyname from add_job as p inner join add_company as j on p.companyid=j.companyid where p.maincategoryid=9", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater2.DataSource = ds;
            Repeater2.DataBind();

        }
        catch (Exception cc)
        {
            Response.Write(cc.Message);
        }
    }
    void getWallData3()
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
        try
        {
            cmd = new SqlCommand("select Top 6 p.lastdate,p.jobid,p.jobtitle,p.salary,p.companyid,p.maincategoryid,j.companyid,j.companyname from add_job as p inner join add_company as j on p.companyid=j.companyid where p.maincategoryid=10", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater3.DataSource = ds;
            Repeater3.DataBind();

        }
        catch (Exception cc)
        {
            Response.Write(cc.Message);
        }
    }
}