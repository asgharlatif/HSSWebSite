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

public partial class Admin_Signup : System.Web.UI.Page
{
    dsAdminTableAdapters.AdminTableAdapter ta = new dsAdminTableAdapters.AdminTableAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string HashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "sha1");
        //lblMsg.Text = HashedPassword.ToString();

        ta.Insert(txtLogin.Text.Trim(),
                  HashedPassword,
                  DateTime.Now,
                  "admin");
        Response.Redirect("Login.aspx");
    }
}
