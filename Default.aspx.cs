using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Data;
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SQLiteConnection sqlite = new SQLiteConnection("Data Source=e:\\db\\project.s3db");
        sqlite.Open();
        SQLiteCommand command = new SQLiteCommand("Select * from login where username='" + TextBox1.Text + "' and password='" + TextBox2.Value + "'", sqlite);
        
        SQLiteDataReader reader = command.ExecuteReader();        
        SQLiteDataAdapter DB;
        if (reader.Read())
        {
            Response.Write("Login success");
            HttpCookie cookie = new HttpCookie("logged", "true");
            Response.SetCookie(cookie);
            Response.Redirect("home.aspx");


        }
        else
            wrong.Style.Value = "visibility:visible";
        sqlite.Close();  
    }
}