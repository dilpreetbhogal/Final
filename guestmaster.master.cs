using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class guestmaster : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        connection();
        if(!Page.IsPostBack)selectMain();
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

    void selectMain()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlDataAdapter("Select * from [maincategory1] order by maincategoryname asc", con))
            {
                using (var ds = new DataSet())
                {
                    cmd.Fill(ds);
                    mainrep.DataSource = ds;
                    mainrep.DataBind();
                }
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

    protected string GenerateURL(object mid,object mname)
    {
       string str = "main.aspx?mid=" + mid+" &mname="+mname;
        return str;
    }
    protected string GenerateSUBURL(object sid,object sname)
    {
        string str = "sub.aspx?sid=" + sid + "&sname=" + sname;
        return str;
    }
    protected string GenerateChildURL(object cid,object cname)
    {
        string str = "child.aspx?cid=" + cid + "&cname=" + cname;
        return str;
    }
    protected void mainrep_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var mainid = ((Literal) e.Item.FindControl("mainid"));
            using (var cmd = new SqlDataAdapter("Select * from [subcategory] where maincategoryid='"+mainid.Text+"' order by subcategoryname asc", con))
            {
                using (var ds = new DataSet())
                {
                    cmd.Fill(ds);
                    var subrep = ((Repeater) e.Item.FindControl("subrep"));
                    subrep.DataSource = ds;
                    subrep.DataBind();
                }
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

    protected void subrep_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var subid = ((Literal)e.Item.FindControl("subid"));
            using (var cmd = new SqlDataAdapter("Select * from [childcategory] where subcategoryid='" + subid.Text + "' order by childcategoryname asc", con))
            {
                using (var ds = new DataSet())
                {
                    cmd.Fill(ds);
                    var subrep = ((Repeater)e.Item.FindControl("subrep"));
                    subrep.DataSource = ds;
                    subrep.DataBind();
                }
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
