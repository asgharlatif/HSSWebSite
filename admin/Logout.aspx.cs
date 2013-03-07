using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] cookies = Request.Cookies.AllKeys;
        foreach (string cookie in cookies)
        {
            BulletedList1.Items.Add("Deleting " + cookie);
            Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
        }

        Session.Abandon();
        Response.Redirect("Login.aspx?msg=You have successfully logged");
    }
}
