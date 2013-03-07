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

public partial class Admin_Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {      
        if (IsPostBack)
            return;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string ReturnURL = "";
        if (Request.QueryString["ReturnURL"] != null)
        {
            ReturnURL = Server.UrlDecode(Request.QueryString["ReturnURL"].ToString());
        }

        dsAdminTableAdapters.AdminTableAdapter taAdmin = new dsAdminTableAdapters.AdminTableAdapter();
        dsAdmin.AdminDataTable dtAdmin;
        string HashedPassword =txtPassword.Text.Trim();// FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "sha1");

		dtAdmin = taAdmin.AdminLogin(txtLogin.Text.Trim(), HashedPassword);
       
        if (dtAdmin.Rows.Count > 0)
        {
            HttpCookie cookie = Request.Cookies["DYL"];
            if (cookie == null)
            {
                cookie = new HttpCookie("DYL");
            }
            cookie["expiry"] = "" + DateTime.Now.AddDays(14);
            cookie["userid"] = dtAdmin[0].AdminId.ToString();
            cookie.Expires = DateTime.Now.AddDays(14);
            Response.Cookies.Add(cookie);
            
            //Session["AdminId"] = dtAdmin[0].AdminId.ToString();
            if (ReturnURL == "")
                Response.Redirect("home.aspx");
            else
                Response.Redirect(ReturnURL);
        }
        else
        {
            lblError.Text = "Invalid LoginId or Password";
            lblError.Visible = true;
            return;
        }
    }
  
   
}
