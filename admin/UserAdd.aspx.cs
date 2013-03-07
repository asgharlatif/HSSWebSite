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

public partial class admin_UserAdd : System.Web.UI.Page
{
    dsAdminTableAdapters.AdminTableAdapter taAdmin = new dsAdminTableAdapters.AdminTableAdapter();
    dsAdmin.AdminDataTable dtAdmin;
    dsSecurityTableAdapters.SecurityPageSectionsTableAdapter taSecurityPageSections = new dsSecurityTableAdapters.SecurityPageSectionsTableAdapter();
    dsSecurity.SecurityPageSectionsDataTable dtSecurityPageSections;
    dsSecurityTableAdapters.PermissionsTableAdapter taPermissions = new dsSecurityTableAdapters.PermissionsTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        //int AdminId = Convert.ToInt32(Session["AdminId"]);

        HttpCookie cookie = Request.Cookies["DYL"];
        int AdminId = Convert.ToInt32(cookie["userid"]);

        dtAdmin = taAdmin.GetDataByAdminId(AdminId);

        if (dtAdmin[0].Type.ToString() != "admin")
            Response.Redirect("PermissionDenied.aspx");

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Added";
            }
        }

        SelectSecurityPageSections();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string HashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "sha1");
        
        int UserId = Convert.ToInt32(taAdmin.AddUser(txtLoginId.Text.Trim(),
                                                     HashedPassword,
                                                     DateTime.Now,
                                                     "user"));
       
       for (int i = 0; i < chkSecurityPageSections.Items.Count; i++)
       {
           if (chkSecurityPageSections.Items[i].Selected)
           {
               taPermissions.Insert(UserId,
                                    Convert.ToInt32(chkSecurityPageSections.Items[i].Value));
           }
       }

       Response.Redirect("UserAdd.aspx?ID=True");
    }

    protected void SelectSecurityPageSections()
    {
        dtSecurityPageSections = taSecurityPageSections.GetData();
        chkSecurityPageSections.DataTextField = dtSecurityPageSections.Columns[1].ToString();
        chkSecurityPageSections.DataValueField = dtSecurityPageSections.Columns[0].ToString();
        chkSecurityPageSections.DataSource = dtSecurityPageSections;
        chkSecurityPageSections.DataBind();
    }
}
