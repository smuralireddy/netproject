using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;

public partial class home : System.Web.UI.Page
{
    int max_tickets;
    SQLiteConnection con;
    SQLiteDataReader reader;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        int flag,i;
        flag = 0;
        
        //bookdiv.Style.Value = "visibility:hidden";
        HttpCookieCollection cookiecollection=Request.Cookies;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        con = new SQLiteConnection("Data Source=e:\\db\\project.s3db");
        con.Open();
        SQLiteCommand command = new SQLiteCommand("Select * from train", con);
        reader = command.ExecuteReader();
        
        //SQLiteDataAdapter ad=new SQLiteDataAdapter(,con);
        
        //GridView gv = new GridView();
        String str = "<table><tr><th>train no</th><th>train name</th><th>train timing</th><th>avaliable tickets</th><th>total tickets</th><th>cost</th></tr>";
        while (reader.Read())
        {
            str += "</tr><td>" + reader.GetValue(0) + "</td>";
            str += "<td>" + reader.GetString(1) + "</td>";
            str += "<td>" + reader.GetString(2) + "</td>";
            str += "<td>" + reader.GetValue(3) + "</td>";
            str += "<td>" + reader.GetValue(4) + "</td>";
            str += "<td>" + reader.GetValue(5) + "</td></tr>";
        }
        str += "</table>";
        traindiv.InnerHtml = str;
        con.Close();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        con = new SQLiteConnection("Data Source=e:\\db\\project.s3db");
        con.Open();
        SQLiteCommand command = new SQLiteCommand("Select * from train", con);
        reader = command.ExecuteReader();
        //SQLiteDataAdapter ad=new SQLiteDataAdapter(,con);

        //GridView gv = new GridView();
        
        while (reader.Read())
        {
            trainno_list.Items.Add(reader.GetValue(0).ToString());
        }
        bookdiv.Style.Value = "visibility:visible";
        con.Close();
       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        con = new SQLiteConnection("Data Source=e:\\db\\project.s3db");
        con.Open();
        SQLiteCommand command= new SQLiteCommand("Select * from train where trainno="+trainno_list.SelectedValue,con);
        reader=command.ExecuteReader();
        String str;
        if(reader.Read())
        if (Int32.Parse(TextBox1.Text) <= reader.GetInt16(3))
        {
            str = "tickets.aspx?trainno=" + trainno_list.SelectedValue + "&type=" + type.SelectedValue + "&ticketno=" + TextBox1.Text;
            con.Close();
            Response.Redirect(str);
            
        }
        else
            err.InnerText = TextBox1.Text+" Tickets not avaliable. Please check and enter again";
        con.Close();
    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        con = new SQLiteConnection("Data Source=e:\\db\\project.s3db");
        con.Open();
        SQLiteCommand command = new SQLiteCommand("Select * from train where source='"+TextBox2.Text+"' and destination ='"+TextBox3.Text+"'", con);
        reader = command.ExecuteReader();

        //SQLiteDataAdapter ad=new SQLiteDataAdapter(,con);

        //GridView gv = new GridView();
        String str = "<table><tr><th>train no</th><th>train name</th><th>train timing</th><th>avaliable tickets</th><th>total tickets</th><th>cost</th></tr>";
        while (reader.Read())
        {
            str += "</tr><td>" + reader.GetValue(0) + "</td>";
            str += "<td>" + reader.GetString(1) + "</td>";
            str += "<td>" + reader.GetString(2) + "</td>";
            str += "<td>" + reader.GetValue(3) + "</td>";
            str += "<td>" + reader.GetValue(4) + "</td>";
            str += "<td>" + reader.GetValue(5) + "</td></tr>";
        }
        str += "</table>";
        traindiv.InnerHtml = str;
        con.Close();

    }
}