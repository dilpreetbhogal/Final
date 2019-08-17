using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class apply_job : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        connection();
        if (Session["email"] == null || Session["firstname"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            

            if (!Page.IsPostBack)
            {
                getData();
                getUserData();
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
            //lblerror.Text = cc.Message;
        }
    }
    void getData() {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand("select * from [add_job]  where jobid='" + Request.QueryString["jid"] + "'", con);
            
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                          {
                              j_title.Text = dr["jobtitle"].ToString();
                              TextBox6.Text = dr["lastdate"].ToString();
                              TextBox7.Text = dr["numberofposts"].ToString();
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
    void getUserData()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand("select * from [registertbl]  where regid='" + Session["u_id"] + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                   
                    TextBox1.Text = dr["fn"].ToString();
                    TextBox2.Text = dr["email"].ToString();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        insert();
    }
    void insert()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("insert into [apply_job] (userid,jobid,message,expected_days,status,apply_date) values(@c1,@c2,@c3,@c4,@c5,@c6)", con))
            {
                cmd.Parameters.AddWithValue("@c1", Session["u_id"].ToString());
                cmd.Parameters.AddWithValue("@c2", Request.QueryString["jid"].ToString());
                cmd.Parameters.AddWithValue("@c3", TextBox4.Text);
                cmd.Parameters.AddWithValue("@c4", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@c5", "Pending");
                cmd.Parameters.AddWithValue("@c6", System.DateTime.Now);

                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    lblerror.Text = "Thank you for applying this job, We will contact you soon.";
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
}