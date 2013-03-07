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

public partial class admin_ChangePassword : System.Web.UI.Page
{
    dsAdminTableAdapters.AdminTableAdapter taAdmin = new dsAdminTableAdapters.AdminTableAdapter();
    dsAdmin.AdminDataTable dtAdmin;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["Id"] != null)
        {
            if (Request.QueryString["Id"] == "true")
            {
                lblChangePassword.Text = "Password Successfull changed";
                lblChangePassword.Visible = true;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {


    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["DYL"];
        int userId = Convert.ToInt32(cookie["userid"]);

        string HashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtoldpassword.Text.Trim(), "sha1");
        dtAdmin = taAdmin.SelectAdminDetailsbyAdminIdandPassword(userId,
                                                                 HashedPassword);

        if (dtAdmin.Rows.Count > 0)
        {
            string HashedPassword2 = FormsAuthentication.HashPasswordForStoringInConfigFile(txtnewpasword.Text.Trim(), "sha1");
            taAdmin.ChangeAdminPassword(Convert.ToInt32(cookie["AdminId"].ToString()),
                                    HashedPassword2);
            Response.Redirect("ChangePassword.aspx?Id=true");
        }
        else
        {
            lblChangePassword.Text = "Sorry the password could not be changed";
            return;
        }
    }
}
