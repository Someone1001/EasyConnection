using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyConnection;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    string cs = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\yhy0152612\\Desktop\\WebSite1\\App_Data\\MyDatabase.mdf;Integrated Security=True;User Instance=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        target.InnerHtml += "<table><tr><th>ID</th><th>Name</th><th>Address</th></tr>";
        SqlConnection con = new SqlConnection(cs);
        for (int i = 1; i <= Sql.GetRowCount(con, "Usernames"); i++) {
            
            string[] row = Sql.GetRow(con, String.Format("Select * from Usernames where id={0};",i));
            target.InnerHtml += String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", row[0], row[1], row[2]);

        }
        target.InnerHtml+="</table>";
    }
}