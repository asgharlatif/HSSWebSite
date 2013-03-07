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

public partial class admin_UserEdit : System.Web.UI.Page
{
    dsAdminTableAdapters.AdminTableAdapter taAdmin = new dsAdminTableAdapters.AdminTableAdapter();
    dsAdmin.AdminDataTable dtAdmin;
    dsSecurityTableAdapters.SecurityPageSectionsTableAdapter taSecurityPageSections = new dsSecurityTableAdapters.SecurityPageSectionsTableAdapter();
    dsSecurity.SecurityPageSectionsDataTable dtSecurityPageSections;
    dsSecurityTableAdapters.PermissionsTableAdapter taPermissions = new dsSecurityTableAdapters.PermissionsTableAdapter();
    dsSecurity.PermissionsDataTable dtPermissions;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Request.QueryString["ID"] != null)
        {
            if (Request.QueryString["ID"] == "True")
            {
                lblMsg.Text = "Successfully Added";
            }
        }

        HttpCookie cookie = Request.Cookies["DYL"];
        int AdminId = Convert.ToInt32(cookie["userid"]);

        dtAdmin = taAdmin.GetDataByAdminId(AdminId);

        if (dtAdmin[0].Type.ToString() != "admin")
            Response.Redirect("PermissionDenied.aspx");

        if (Request.QueryString["UserId"] != null)
        {
            int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            dtAdmin = taAdmin.GetDataByAdminId(UserId);
            if (dtAdmin.Rows.Count > 0)
            {
                lblLoginId.Text = dtAdmin[0].LoginId.ToString();
                SelectSecurityPageSections();
                MakeSectionsSelected(UserId);
            }
            else
                btnEdit.Visible = false;
        }
        else
            btnEdit.Visible = false;

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
        taPermissions.DeletePermissionsByUserId(UserId);  
        for (int i = 0; i < chkSecurityPageSections.Items.Count; i++)
        {
            if (chkSecurityPageSections.Items[i].Selected)
            {
                taPermissions.Insert(UserId,
                                     Convert.ToInt32(chkSecurityPageSections.Items[i].Value));
            }
        }
        Response.Redirect("Users.aspx?ID=True");
    }

    protected void SelectSecurityPageSections()
    {
        dtSecurityPageSections = taSecurityPageSections.GetData();
        chkSecurityPageSections.DataTextField = dtSecurityPageSections.Columns[1].ToString();
        chkSecurityPageSections.DataValueField = dtSecurityPageSections.Columns[0].ToString();
        chkSecurityPageSections.DataSource = dtSecurityPageSections;
        chkSecurityPageSections.DataBind();
    }

    protected void MakeSectionsSelected(int UserId)
    {
        dtPermissions = taPermissions.SelectPermissionsByUserId(UserId);
        for (int i = 0; i < dtPermissions.Rows.Count; i++)
        {
            for (int j = 0; j < chkSecurityPageSections.Items.Count; j++)
            {
                if (dtPermissions[i].SecurityPageSectionId.ToString() == chkSecurityPageSections.Items[j].Value)
                {
                    chkSecurityPageSections.Items[j].Selected = true;
                }
            }
        }
    }
}
