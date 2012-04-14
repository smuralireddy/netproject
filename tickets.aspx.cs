using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
public partial class tickets : System.Web.UI.Page
{
    private void check()
    {
        int i, flag;
        flag = 0;
        HttpCookieCollection cookiecollection = Request.Cookies;
        for (i = 0; i < cookiecollection.Count; i++)
        {
            if (cookiecollection.Get(i).Name == "logged")
            {
                flag = 1;
                break;
            }
        }
        if (flag == 1)
        {
            //Response.Write("cookie found");
            HttpCookie cookie = cookiecollection.Get(i);
            if (cookie.Value != "true")
                flag = 0;
        }
        if (flag == 0)
        {
            Response.Redirect("default.aspx");
        }
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        check();
        int trainno = Int32.Parse(Request.Params[0]);
        int tickets = Int32.Parse(Request.Params[2]);
        int avail_tickets;
        String type = Request.Params[1];
        Response.Write("Booking tickets<br/>train no="+Request.Params[0] + " <br/> Type:" + Request.Params[1] + "<br/>No. of tickets " + Request.Params[2]);
        SQLiteConnection con = new SQLiteConnection("Data Source=e:\\db\\project.s3db");
        con.Open();
        SQLiteCommand command = new SQLiteCommand("Select * from train where trainno=" + trainno, con);
        SQLiteDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            avail_tickets = reader.GetInt16(3);
            Response.Write("<br/> <h2>Succefully booked</h2>");
            Response.Write("<br/> Total cost:" + reader.GetInt16(5) * tickets);
            Response.Write("<br/> Source" + reader.GetString(6) + "<br/>Destination" + reader.GetString(7));
            avail_tickets -= tickets;
            command = new SQLiteCommand("update train set available_tickets=" + avail_tickets + " where trainno=" + trainno,con);
            command.ExecuteNonQuery();
        }
        con.Close();
            

    }
}