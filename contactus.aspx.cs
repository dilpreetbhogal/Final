using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class contactus : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {

          connection();
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

    void insert()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (var cmd = new SqlCommand("insert into [contact us] (fn,email,phoneno,message) values(@c1,@c2,@c3,@c4)", con))
            {
                cmd.Parameters.AddWithValue("@c1", txtfn.Text);
                cmd.Parameters.AddWithValue("@c2", txtmail.Text);
                cmd.Parameters.AddWithValue("@c3", txtpn.Text);
                cmd.Parameters.AddWithValue("@c4", txtmessage.Text);

                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    lblerror.Text = "thank you";
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



   
    protected void  btncontact_Click(object sender, EventArgs e)
{
        insert();

}
}


    