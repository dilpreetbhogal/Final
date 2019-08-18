using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Mainpage : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        connection();
        mainlbl.Text = Request.QueryString["cname"];
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
            lblerror.Text = cc.Message;
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
            using (var cmd = new SqlDataAdapter("select  * from add_job where childcategoryid='"+Request.QueryString["cid"]+"' order by (jobid) desc", con))
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
    void selectsidedata()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (var cmd = new SqlDataAdapter("select TOP 10 * from add_job where childcategoryid!='" + Request.QueryString["cid"] + "' order by (jobid) desc", con))
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
    protected void repbindData(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((Label)e.Item.FindControl("maincatlbl")).Text=mainlbl.Text;
        }
    }
    public string GenerateMain(object id)
    {

        string str = "Job_Details.aspx?jobid=" + id;
        return str;
    }
   
}